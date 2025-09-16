﻿namespace IEDExplorer.Views
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin2 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient4 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient8 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient9 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient10 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient11 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient12 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient6 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient13 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient14 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Run = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox_Hostname = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxLoggingLevel = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonConnParam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartupRead = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonOpenSCL = new System.Windows.Forms.ToolStripSplitButton();
            this.GooseSender = new System.Windows.Forms.ToolStripButton();
            this.GooseExplorer = new System.Windows.Forms.ToolStripButton();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Run,
            this.toolStripButton_Stop,
            this.toolStripComboBox_Hostname,
            this.toolStripButtonAbout,
            this.toolStripComboBoxLoggingLevel,
            this.toolStripLabel1,
            this.toolStripButtonConnParam,
            this.toolStripButtonStartupRead,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripButtonOpenSCL,
            this.GooseSender,
            this.GooseExplorer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(920, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Run
            // 
            this.toolStripButton_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Run.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Run.Image")));
            this.toolStripButton_Run.Name = "toolStripButton_Run";
            this.toolStripButton_Run.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Run.Text = "Run";
            this.toolStripButton_Run.Click += new System.EventHandler(this.toolStripButton_Run_Click);
            // 
            // toolStripButton_Stop
            // 
            this.toolStripButton_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Stop.Enabled = false;
            this.toolStripButton_Stop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Stop.Image")));
            this.toolStripButton_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Stop.Name = "toolStripButton_Stop";
            this.toolStripButton_Stop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Stop.Text = "Stop";
            this.toolStripButton_Stop.Click += new System.EventHandler(this.toolStripButton_Stop_Click);
            // 
            // toolStripComboBox_Hostname
            // 
            this.toolStripComboBox_Hostname.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolStripComboBox_Hostname.Name = "toolStripComboBox_Hostname";
            this.toolStripComboBox_Hostname.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox_Hostname.ToolTipText = "IP Address of Server";
            this.toolStripComboBox_Hostname.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_Hostname_SelectedIndexChanged);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAbout.Text = "toolStripButton1";
            this.toolStripButtonAbout.ToolTipText = "Info";
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // toolStripComboBoxLoggingLevel
            // 
            this.toolStripComboBoxLoggingLevel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxLoggingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxLoggingLevel.Name = "toolStripComboBoxLoggingLevel";
            this.toolStripComboBoxLoggingLevel.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBoxLoggingLevel.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxLoggingLevel_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "日志等级: ";
            // 
            // toolStripButtonConnParam
            // 
            this.toolStripButtonConnParam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConnParam.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonConnParam.Image")));
            this.toolStripButtonConnParam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConnParam.Name = "toolStripButtonConnParam";
            this.toolStripButtonConnParam.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonConnParam.Text = "toolStripButton1";
            this.toolStripButtonConnParam.Click += new System.EventHandler(this.toolStripButtonConnParam_Click);
            // 
            // toolStripButtonStartupRead
            // 
            this.toolStripButtonStartupRead.Checked = true;
            this.toolStripButtonStartupRead.CheckOnClick = true;
            this.toolStripButtonStartupRead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonStartupRead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartupRead.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStartupRead.Image")));
            this.toolStripButtonStartupRead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartupRead.Name = "toolStripButtonStartupRead";
            this.toolStripButtonStartupRead.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStartupRead.Text = "toolStripButtonStartupRead";
            this.toolStripButtonStartupRead.ToolTipText = "Read Data Values from IED on startup (time consuming, but useful)";
            this.toolStripButtonStartupRead.Click += new System.EventHandler(this.toolStripButtonStartupRead_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel2.Text = "SCL文本";
            // 
            // toolStripButtonOpenSCL
            // 
            this.toolStripButtonOpenSCL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenSCL.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpenSCL.Image")));
            this.toolStripButtonOpenSCL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenSCL.Name = "toolStripButtonOpenSCL";
            this.toolStripButtonOpenSCL.Size = new System.Drawing.Size(32, 22);
            this.toolStripButtonOpenSCL.Text = "toolStripButton1";
            this.toolStripButtonOpenSCL.ToolTipText = "Open SCL file";
            this.toolStripButtonOpenSCL.ButtonClick += new System.EventHandler(this.toolStripButtonOpenSCL_Click);
            // 
            // GooseSender
            // 
            this.GooseSender.Image = ((System.Drawing.Image)(resources.GetObject("GooseSender.Image")));
            this.GooseSender.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GooseSender.Name = "GooseSender";
            this.GooseSender.Size = new System.Drawing.Size(107, 22);
            this.GooseSender.Text = "GooseSender";
            this.GooseSender.Click += new System.EventHandler(this.GooseSender_Click);
            // 
            // GooseExplorer
            // 
            this.GooseExplorer.Image = ((System.Drawing.Image)(resources.GetObject("GooseExplorer.Image")));
            this.GooseExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GooseExplorer.Name = "GooseExplorer";
            this.GooseExplorer.Size = new System.Drawing.Size(115, 22);
            this.GooseExplorer.Text = "GooseExplorer";
            this.GooseExplorer.Click += new System.EventHandler(this.GooseExplorer_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(920, 473);
            dockPanelGradient4.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient4.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin2.DockStripGradient = dockPanelGradient4;
            tabGradient8.EndColor = System.Drawing.SystemColors.Control;
            tabGradient8.StartColor = System.Drawing.SystemColors.Control;
            tabGradient8.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin2.TabGradient = tabGradient8;
            autoHideStripSkin2.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin2.AutoHideStripSkin = autoHideStripSkin2;
            tabGradient9.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient9.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.ActiveTabGradient = tabGradient9;
            dockPanelGradient5.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient5.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient2.DockStripGradient = dockPanelGradient5;
            tabGradient10.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient10.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient2.InactiveTabGradient = tabGradient10;
            dockPaneStripSkin2.DocumentGradient = dockPaneStripGradient2;
            dockPaneStripSkin2.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient11.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient11.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient11.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient11.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient2.ActiveCaptionGradient = tabGradient11;
            tabGradient12.EndColor = System.Drawing.SystemColors.Control;
            tabGradient12.StartColor = System.Drawing.SystemColors.Control;
            tabGradient12.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient2.ActiveTabGradient = tabGradient12;
            dockPanelGradient6.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient6.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient2.DockStripGradient = dockPanelGradient6;
            tabGradient13.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient13.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient13.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient13.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient2.InactiveCaptionGradient = tabGradient13;
            tabGradient14.EndColor = System.Drawing.Color.Transparent;
            tabGradient14.StartColor = System.Drawing.Color.Transparent;
            tabGradient14.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient2.InactiveTabGradient = tabGradient14;
            dockPaneStripSkin2.ToolWindowGradient = dockPaneStripToolWindowGradient2;
            dockPanelSkin2.DockPaneStripSkin = dockPaneStripSkin2;
            this.dockPanel1.Skin = dockPanelSkin2;
            this.dockPanel1.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 498);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainWindow";
            this.Text = "模拟客户端工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Run;
        private System.Windows.Forms.ToolStripButton toolStripButton_Stop;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Hostname;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLoggingLevel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSplitButton toolStripButtonOpenSCL;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripButton toolStripButtonConnParam;
        private System.Windows.Forms.ToolStripButton GooseSender;
        private System.Windows.Forms.ToolStripButton GooseExplorer;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartupRead;
    }
}