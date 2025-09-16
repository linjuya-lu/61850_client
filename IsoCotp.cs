﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace IEDExplorer
{
    public class IsoCotp
    {
        private const int COTP_HDR_CR_SIZEOF = 6; //18;
        public const int COTP_HDR_DT_SIZEOF = 3;

        private const int COTP_HDR_IDX_HDRLEN = 0;
        private const int COTP_HDR_IDX_CODE = 1;
        private const int COTP_HDR_IDX_DSTREF = 2;
        private const int COTP_HDR_IDX_SRCREF = 4;
        private const int COTP_HDR_IDX_OPTION = 6;

        private const byte COTP_CODE_CR = 0xe0;
        private const byte COTP_CODE_CC = 0xd0;
        public const byte COTP_CODE_DT = 0xf0;
        public const byte COTP_CODE_DR = 0x80;

        private const byte COTP_PCODE_TSIZ = 0xc0;
        private const byte COTP_PCODE_DSAP = 0xc2;
        private const byte COTP_PCODE_SSAP = 0xc1;

        private const byte COTP_PACKET_FRAGMENT = 0x00;
        private const byte COTP_PACKET_COMPLETE = 0x80;

        private short m_COTP_srcref;
        private short m_COTP_dstref;
        private byte m_COTP_option;

        private byte[] dataReserveBuffer = new byte[TcpState.sendBufferSize];

        public struct TSelector
        {
            public byte size; /** 0 .. 4 - 0 means T-selector is not present */
            public int value;
            public TSelector(byte sz, int val) { size = sz; value = val; }
            public byte[] GetBytes()
            {
                byte[] b = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value));
                byte[] ret = new byte[size];
                for (int i = 0; i < size; i++) ret[i] = b[i + 4 - size];
                return ret;
            }
        }

        public enum CotpReceiveResult
        {
            ERROR,
            INIT,
            DATA,
            WAIT
        }

        class CotpOptions
        {
            public TSelector tSelDst;
            public TSelector tSelSrc;
            public byte tpduSize;
            public CotpOptions(IsoConnectionParameters cp)
            {
                if (cp == null)
                {
                    tSelDst = new TSelector(2, 0x0001);
                    tSelSrc = new TSelector(2, 0x0000);
                    tpduSize = 0x0a;	// 1024 byte max PDU size
                }
                else
                {
                    tSelDst = cp.remoteTSelector;
                    tSelSrc = cp.localTSelector;
                    tpduSize = 0x0a;	// 1024 byte max PDU size
                }
            }
            public int getSize()
            {
                int size = tSelDst.size + tSelSrc.size + 7;
                return size;
            }
        }

        CotpOptions options;

        public IsoCotp(IsoConnectionParameters cp)
        {
            Reset(cp);
        }

        void Reset(IsoConnectionParameters cp)
        {
            m_COTP_dstref = 0x0000;
            m_COTP_srcref = 0x0008;
            m_COTP_option = 0x00;
            options = new CotpOptions(cp);
        }

        public CotpReceiveResult Receive(Iec61850State iecs)
        {
            CotpReceiveResult res = CotpReceiveResult.ERROR;
            int ret;

            iecs.logger.LogDebug("IsoCotp.Receive");
            if (iecs.dataBuffer[1] == COTP_CODE_DT)         // Data Transfer
            {
                iecs.msMMS.Write(iecs.dataBuffer, 3, iecs.dataBufferIndex - 3);

                if ((iecs.dataBuffer[2] & COTP_PACKET_COMPLETE) == 0)
                {
                    return CotpReceiveResult.WAIT;			// waiting for the rest of the datagram from other COTP frames
                }
                //iecs.logger.LogDebug(String.Format("Calling IsoSess.Receive with data len {0}", iecs.msMMS.Length));
                return res = CotpReceiveResult.DATA;
            }
            else if (iecs.dataBuffer[1] == COTP_CODE_CC)    // Connect Confirmation
            {
                iecs.msMMS.Write(iecs.dataBuffer, 0, iecs.dataBufferIndex);
                iecs.logger.LogDebug(String.Format("Calling ParseCOTPSessionInit with data len {0}", iecs.msMMS.Length));
                ret = ParseCOTPSessionInit(iecs);
                if (ret == 0)
                {
                    res = CotpReceiveResult.INIT;
                }
                else
                {
                    res = CotpReceiveResult.ERROR;
                }
            }
            else if (iecs.dataBuffer[1] == COTP_CODE_DR)    // DisConnect Request
            {
                iecs.logger.LogDebug(String.Format("COTP Disconnect Request received, error"));
                res = CotpReceiveResult.ERROR;
            }

            // Reset the stream
            iecs.msMMS = new MemoryStream();
            return res;
        }

        public int Send(Iec61850State iecs)
        {
            // Make COTP data telegramm
            int offs = IsoTpkt.TPKT_SIZEOF;
            int maxLen = 1 << options.tpduSize; // max COTP len
            int maxDataLen = maxLen - COTP_HDR_DT_SIZEOF; // max DATA len

            if (iecs.sendBytes <= maxDataLen)
            {
                // Original handling, same as before / short datagram without fragmenting
                iecs.sendBuffer[offs++] = COTP_HDR_DT_SIZEOF - 1; // cotp.hdrlen wihout this field
                iecs.sendBuffer[offs++] = COTP_CODE_DT; // code
                iecs.sendBuffer[offs++] = COTP_PACKET_COMPLETE; // number "complete" for "short" datagrams

                iecs.sendBytes += offs;
                IsoTpkt.Send(iecs);
            }
            else
            {
                // Long data, need to fragment to TPKT + COTP fragments
                // Technique: allocate a new buffer. Keep the original data.
                // Copy original data "per partes" to the new buffer, adding TPKT and COTP headers
                // and sending the fragments via TCP.
                // Last COTP fragments must be marked 0x80, others 0x00
                // Possible optimization: for the first fragment use the original buffer (spare 1 copy operation) NOT IMPLEMENTED
                int dLen = iecs.sendBytes;  // Actual data length
                int sLen = 0;               // Actual sent data length
                byte[] originalData = iecs.sendBuffer;
                iecs.sendBuffer = dataReserveBuffer;    // Use saved / recycled buffer
                dataReserveBuffer = originalData;       // Save original buffer to reserve for future use / recycling saves allocation oper.
                const int dOffs = IsoTpkt.TPKT_SIZEOF + COTP_HDR_DT_SIZEOF;

                while (dLen > 0)
                {
                    iecs.sendBytes = Math.Min(dLen, maxDataLen);
                    Array.Copy(originalData, dOffs + sLen, iecs.sendBuffer, dOffs, iecs.sendBytes);
                    dLen -= iecs.sendBytes;
                    sLen += iecs.sendBytes;

                    offs = IsoTpkt.TPKT_SIZEOF; // reinit offset
                    iecs.sendBuffer[offs++] = COTP_HDR_DT_SIZEOF - 1; // cotp.hdrlen wihout this field
                    iecs.sendBuffer[offs++] = COTP_CODE_DT; // code
                    iecs.sendBuffer[offs++] = (byte)((dLen > 0) ? COTP_PACKET_FRAGMENT : COTP_PACKET_COMPLETE); // number "fragment" or "complete"

                    iecs.sendBytes += offs;
                    IsoTpkt.Send(iecs);
                }
            }
            return 0;
        }

        int ParseCOTPSessionInit(Iec61850State iecs)
        {
            // Read COTP init response

            iecs.msMMS.Seek(1, SeekOrigin.Begin); // skip hdrlen
            if (iecs.msMMS.ReadByte() != COTP_CODE_CC) return -1;    // code NOK
            iecs.msMMS.Seek(2, SeekOrigin.Current);  // skip dstref
            Byte[] b = new Byte[2];
            iecs.msMMS.Read(b, 0, 2);
            m_COTP_dstref = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(b, 0));    // srcref
            iecs.msMMS.Seek(1, SeekOrigin.Current);  // skip option
            // Parameters
            while (iecs.msMMS.Position < iecs.msMMS.Length - 1)
            {
                int code = iecs.msMMS.ReadByte();
                if (code == COTP_PCODE_TSIZ)    // option size
                {
                    iecs.msMMS.Seek(1, SeekOrigin.Current);  // skip len always 1
                    options.tpduSize = (byte)iecs.msMMS.ReadByte();
                }
                else if (code == COTP_PCODE_DSAP)   // Destination SAP = locally source SAP
                {
                    options.tSelSrc.size = (byte)iecs.msMMS.ReadByte();  // len
                    Byte[] b2 = new Byte[4];
                    iecs.msMMS.Read(b2, 0, options.tSelSrc.size);
                    options.tSelSrc.value = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(b2, 0));    // srcref
                }
                else if (code == COTP_PCODE_SSAP)   // Source SAP = locally destination SAP
                {
                    options.tSelDst.size = (byte)iecs.msMMS.ReadByte();  // len
                    Byte[] b2 = new Byte[4];
                    iecs.msMMS.Read(b2, 0, options.tSelDst.size);
                    options.tSelDst.value = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(b2, 0));    // dstref
                }
            }
            return 0;	//O.K.
        }

        public int SendInit(Iec61850State iecs)
        {
            //Reset dstref
            Reset(iecs.cp);

            // Make COTP init telegramm
            int offs = IsoTpkt.TPKT_SIZEOF;
            int optof = COTP_HDR_IDX_OPTION;

            iecs.sendBuffer[offs + COTP_HDR_IDX_HDRLEN] = (byte)(COTP_HDR_CR_SIZEOF + options.getSize());

            iecs.sendBuffer[offs + COTP_HDR_IDX_CODE] = COTP_CODE_CR;
            Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(m_COTP_dstref)), 0, iecs.sendBuffer, offs + COTP_HDR_IDX_DSTREF, 2);
            Array.Copy(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(m_COTP_srcref)), 0, iecs.sendBuffer, offs + COTP_HDR_IDX_SRCREF, 2);
            iecs.sendBuffer[offs + optof++] = m_COTP_option;

            // Parameters
            iecs.sendBuffer[offs + optof++] = COTP_PCODE_TSIZ;
            iecs.sendBuffer[offs + optof++] = 1;
            iecs.sendBuffer[offs + optof++] = options.tpduSize;
            if (options.tSelDst.size > 0)
            {
                iecs.sendBuffer[offs + optof++] = COTP_PCODE_DSAP;
                iecs.sendBuffer[offs + optof++] = options.tSelDst.size;
                byte[] bt = options.tSelDst.GetBytes();
                Array.Copy(bt, 0, iecs.sendBuffer, offs + optof, options.tSelDst.size);
                optof += options.tSelDst.size;
            }

            if (options.tSelSrc.size > 0)
            {
                iecs.sendBuffer[offs + optof++] = COTP_PCODE_SSAP;
                iecs.sendBuffer[offs + optof++] = options.tSelSrc.size;
                Array.Copy(options.tSelSrc.GetBytes(), 0, iecs.sendBuffer, offs + optof, options.tSelSrc.size);
            }

            iecs.sendBytes = offs + COTP_HDR_CR_SIZEOF + 1 + options.getSize();

            IsoTpkt.Send(iecs);
            return 0;
        }

    }
}
