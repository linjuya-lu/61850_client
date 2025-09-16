﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEDExplorer
{
    public class MMSCaptureDb
    {
        Iec61850State iecs;
        public delegate void NewPacket(MMSCapture cap);
        public event NewPacket OnNewPacket;
        int PacketNr;

        public MMSCaptureDb(Iec61850State _iecs)
        {
            iecs = _iecs;
        }
        /// <summary>
        /// List of captured MMS packets (PDUs)
        /// </summary>
        List<MMSCapture> CapturedData = new List<MMSCapture>();
        /// <summary>
        /// Capture of MMS packets (PDUs) active
        /// </summary>
        public bool CaptureActive = false;

        public void AddPacket(MMSCapture cap)
        {
            CapturedData.Add(cap);
            cap.PacketNr = PacketNr++;
            if (OnNewPacket != null) OnNewPacket(cap);
        }

        public void Clear()
        {
            CapturedData.Clear();
            PacketNr = 0;
        }
    }
}
