namespace SFFBot
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.SBMenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionsMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoStopCkbx = new System.Windows.Forms.ToolStripMenuItem();
            this.AlwaysOnTopCkbx = new System.Windows.Forms.ToolStripMenuItem();
            this.UseSelectedTileCkbx = new System.Windows.Forms.ToolStripMenuItem();
            this.SBPoisonCkbx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SBHeadersMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DropMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DropTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.WalkMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.WalkTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.Walk2MenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Walk2Txt = new System.Windows.Forms.ToolStripMenuItem();
            this.SBDelayMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SB100Ckbx = new System.Windows.Forms.ToolStripMenuItem();
            this.SB200Ckbx = new System.Windows.Forms.ToolStripMenuItem();
            this.SB400Ckbx = new System.Windows.Forms.ToolStripMenuItem();
            this.SB600Ckbx = new System.Windows.Forms.ToolStripMenuItem();
            this.SB800Ckbx = new System.Windows.Forms.ToolStripMenuItem();
            this.SB1000Ckbx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SBCustomDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomDelayOpenDlg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectTileBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearPoisonBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenHotkeysBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSettingsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SBHelpMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SBAboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartBtn = new Sulakore.Components.SKoreButton();
            this.PoisonGrp = new System.Windows.Forms.GroupBox();
            this.AddPoisonBtn = new Sulakore.Components.SKoreButton();
            this.PoisonListCbbx = new System.Windows.Forms.ComboBox();
            this.StartGrp = new System.Windows.Forms.GroupBox();
            this.StatusBtn = new System.Windows.Forms.TextBox();
            this.BluePanelBottom = new System.Windows.Forms.Panel();
            this.VersionTxt = new System.Windows.Forms.LinkLabel();
            this.Sep = new System.Windows.Forms.Panel();
            this.GithubLnk = new System.Windows.Forms.LinkLabel();
            this.MessageTxt = new System.Windows.Forms.Label();
            this.FixPanel = new System.Windows.Forms.Panel();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SBMenuStrip.SuspendLayout();
            this.PoisonGrp.SuspendLayout();
            this.StartGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // SBMenuStrip
            // 
            this.SBMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.SBMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsMenuStrip,
            this.SBHelpMenuStrip});
            this.SBMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.SBMenuStrip.Name = "SBMenuStrip";
            this.SBMenuStrip.Size = new System.Drawing.Size(261, 24);
            this.SBMenuStrip.TabIndex = 0;
            this.SBMenuStrip.Text = "menuStrip1";
            // 
            // OptionsMenuStrip
            // 
            this.OptionsMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoStopCkbx,
            this.AlwaysOnTopCkbx,
            this.UseSelectedTileCkbx,
            this.SBPoisonCkbx,
            this.toolStripSeparator1,
            this.SBHeadersMenuStrip,
            this.SBDelayMenuStrip,
            this.toolStripSeparator3,
            this.SelectTileBtn,
            this.ClearPoisonBtn,
            this.toolStripSeparator2,
            this.OpenHotkeysBtn,
            this.OpenSettingsBtn});
            this.OptionsMenuStrip.ForeColor = System.Drawing.Color.Black;
            this.OptionsMenuStrip.Name = "OptionsMenuStrip";
            this.OptionsMenuStrip.Size = new System.Drawing.Size(61, 20);
            this.OptionsMenuStrip.Text = "Options";
            // 
            // AutoStopCkbx
            // 
            this.AutoStopCkbx.Name = "AutoStopCkbx";
            this.AutoStopCkbx.Size = new System.Drawing.Size(162, 22);
            this.AutoStopCkbx.Text = "AutoStop";
            this.AutoStopCkbx.Click += new System.EventHandler(this.AutoStopCkbx_Click);
            // 
            // AlwaysOnTopCkbx
            // 
            this.AlwaysOnTopCkbx.CheckOnClick = true;
            this.AlwaysOnTopCkbx.Name = "AlwaysOnTopCkbx";
            this.AlwaysOnTopCkbx.Size = new System.Drawing.Size(162, 22);
            this.AlwaysOnTopCkbx.Text = "Always On Top";
            this.AlwaysOnTopCkbx.Click += new System.EventHandler(this.SBAlwaysOnTopCkbx_Click);
            // 
            // UseSelectedTileCkbx
            // 
            this.UseSelectedTileCkbx.CheckOnClick = true;
            this.UseSelectedTileCkbx.Enabled = false;
            this.UseSelectedTileCkbx.Name = "UseSelectedTileCkbx";
            this.UseSelectedTileCkbx.Size = new System.Drawing.Size(162, 22);
            this.UseSelectedTileCkbx.Text = "Use Selected Tile";
            // 
            // SBPoisonCkbx
            // 
            this.SBPoisonCkbx.CheckOnClick = true;
            this.SBPoisonCkbx.Name = "SBPoisonCkbx";
            this.SBPoisonCkbx.Size = new System.Drawing.Size(162, 22);
            this.SBPoisonCkbx.Text = "Poison";
            this.SBPoisonCkbx.Click += new System.EventHandler(this.SBPoisonCkbx_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // SBHeadersMenuStrip
            // 
            this.SBHeadersMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropMenuStrip,
            this.MoveMenuStrip,
            this.WalkMenuStrip,
            this.Walk2MenuStrip});
            this.SBHeadersMenuStrip.Name = "SBHeadersMenuStrip";
            this.SBHeadersMenuStrip.Size = new System.Drawing.Size(162, 22);
            this.SBHeadersMenuStrip.Text = "Headers";
            // 
            // DropMenuStrip
            // 
            this.DropMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropTxt});
            this.DropMenuStrip.Name = "DropMenuStrip";
            this.DropMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.DropMenuStrip.Text = "[CS] Drop Furniture";
            // 
            // DropTxt
            // 
            this.DropTxt.Name = "DropTxt";
            this.DropTxt.Size = new System.Drawing.Size(80, 22);
            this.DropTxt.Text = "0";
            // 
            // MoveMenuStrip
            // 
            this.MoveMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveTxt});
            this.MoveMenuStrip.Name = "MoveMenuStrip";
            this.MoveMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.MoveMenuStrip.Text = "[CS] Move Furniture";
            // 
            // MoveTxt
            // 
            this.MoveTxt.Name = "MoveTxt";
            this.MoveTxt.Size = new System.Drawing.Size(80, 22);
            this.MoveTxt.Text = "0";
            // 
            // WalkMenuStrip
            // 
            this.WalkMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WalkTxt});
            this.WalkMenuStrip.Name = "WalkMenuStrip";
            this.WalkMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.WalkMenuStrip.Text = "[SS] Player Walk";
            // 
            // WalkTxt
            // 
            this.WalkTxt.Name = "WalkTxt";
            this.WalkTxt.Size = new System.Drawing.Size(80, 22);
            this.WalkTxt.Text = "0";
            // 
            // Walk2MenuStrip
            // 
            this.Walk2MenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Walk2Txt});
            this.Walk2MenuStrip.Name = "Walk2MenuStrip";
            this.Walk2MenuStrip.Size = new System.Drawing.Size(180, 22);
            this.Walk2MenuStrip.Text = "[CS] Player Walk";
            // 
            // Walk2Txt
            // 
            this.Walk2Txt.Name = "Walk2Txt";
            this.Walk2Txt.Size = new System.Drawing.Size(80, 22);
            this.Walk2Txt.Text = "0";
            // 
            // SBDelayMenuStrip
            // 
            this.SBDelayMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SB100Ckbx,
            this.SB200Ckbx,
            this.SB400Ckbx,
            this.SB600Ckbx,
            this.SB800Ckbx,
            this.SB1000Ckbx,
            this.toolStripSeparator4,
            this.SBCustomDelay,
            this.CustomDelayOpenDlg});
            this.SBDelayMenuStrip.Name = "SBDelayMenuStrip";
            this.SBDelayMenuStrip.Size = new System.Drawing.Size(162, 22);
            this.SBDelayMenuStrip.Text = "Delay";
            // 
            // SB100Ckbx
            // 
            this.SB100Ckbx.Name = "SB100Ckbx";
            this.SB100Ckbx.Size = new System.Drawing.Size(153, 22);
            this.SB100Ckbx.Text = "100 (ms)";
            this.SB100Ckbx.Click += new System.EventHandler(this.SB100Ckbx_Click);
            // 
            // SB200Ckbx
            // 
            this.SB200Ckbx.Name = "SB200Ckbx";
            this.SB200Ckbx.Size = new System.Drawing.Size(153, 22);
            this.SB200Ckbx.Text = "200 (ms)";
            this.SB200Ckbx.Click += new System.EventHandler(this.SB200Ckbx_Click);
            // 
            // SB400Ckbx
            // 
            this.SB400Ckbx.Name = "SB400Ckbx";
            this.SB400Ckbx.Size = new System.Drawing.Size(153, 22);
            this.SB400Ckbx.Text = "400 (ms)";
            this.SB400Ckbx.Click += new System.EventHandler(this.SB400Ckbx_Click);
            // 
            // SB600Ckbx
            // 
            this.SB600Ckbx.Name = "SB600Ckbx";
            this.SB600Ckbx.Size = new System.Drawing.Size(153, 22);
            this.SB600Ckbx.Text = "600 (ms)";
            this.SB600Ckbx.Click += new System.EventHandler(this.SB600Ckbx_Click);
            // 
            // SB800Ckbx
            // 
            this.SB800Ckbx.Name = "SB800Ckbx";
            this.SB800Ckbx.Size = new System.Drawing.Size(153, 22);
            this.SB800Ckbx.Text = "800 (ms)";
            this.SB800Ckbx.Click += new System.EventHandler(this.SB800Ckbx_Click);
            // 
            // SB1000Ckbx
            // 
            this.SB1000Ckbx.Name = "SB1000Ckbx";
            this.SB1000Ckbx.Size = new System.Drawing.Size(153, 22);
            this.SB1000Ckbx.Text = "1000 (ms)";
            this.SB1000Ckbx.Click += new System.EventHandler(this.SB1000Ckbx_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(150, 6);
            // 
            // SBCustomDelay
            // 
            this.SBCustomDelay.Name = "SBCustomDelay";
            this.SBCustomDelay.Size = new System.Drawing.Size(153, 22);
            this.SBCustomDelay.Text = "0 (ms)";
            this.SBCustomDelay.Visible = false;
            this.SBCustomDelay.Click += new System.EventHandler(this.SBCustomDelay_Click);
            // 
            // CustomDelayOpenDlg
            // 
            this.CustomDelayOpenDlg.Name = "CustomDelayOpenDlg";
            this.CustomDelayOpenDlg.Size = new System.Drawing.Size(153, 22);
            this.CustomDelayOpenDlg.Text = "Custom delay..";
            this.CustomDelayOpenDlg.Click += new System.EventHandler(this.CustomDelayOpenDlg_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(159, 6);
            // 
            // SelectTileBtn
            // 
            this.SelectTileBtn.Name = "SelectTileBtn";
            this.SelectTileBtn.Size = new System.Drawing.Size(162, 22);
            this.SelectTileBtn.Text = "Select Tile";
            this.SelectTileBtn.Click += new System.EventHandler(this.SelectTileBtn_Click);
            // 
            // ClearPoisonBtn
            // 
            this.ClearPoisonBtn.Name = "ClearPoisonBtn";
            this.ClearPoisonBtn.Size = new System.Drawing.Size(162, 22);
            this.ClearPoisonBtn.Text = "Clear Poison List";
            this.ClearPoisonBtn.Click += new System.EventHandler(this.SBClearPoisonBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // OpenHotkeysBtn
            // 
            this.OpenHotkeysBtn.Name = "OpenHotkeysBtn";
            this.OpenHotkeysBtn.Size = new System.Drawing.Size(162, 22);
            this.OpenHotkeysBtn.Text = "Hotkeys..";
            this.OpenHotkeysBtn.Click += new System.EventHandler(this.OpenHotkeysBtn_Click);
            // 
            // OpenSettingsBtn
            // 
            this.OpenSettingsBtn.Name = "OpenSettingsBtn";
            this.OpenSettingsBtn.Size = new System.Drawing.Size(162, 22);
            this.OpenSettingsBtn.Text = "Settings..";
            this.OpenSettingsBtn.Click += new System.EventHandler(this.OpenSettingsBtn_Click);
            // 
            // SBHelpMenuStrip
            // 
            this.SBHelpMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SBAboutButton,
            this.ReportMenuItem});
            this.SBHelpMenuStrip.Name = "SBHelpMenuStrip";
            this.SBHelpMenuStrip.Size = new System.Drawing.Size(44, 20);
            this.SBHelpMenuStrip.Text = "Help";
            // 
            // SBAboutButton
            // 
            this.SBAboutButton.Name = "SBAboutButton";
            this.SBAboutButton.Size = new System.Drawing.Size(133, 22);
            this.SBAboutButton.Text = "Help";
            this.SBAboutButton.Click += new System.EventHandler(this.SBAboutButton_Click);
            // 
            // ReportMenuItem
            // 
            this.ReportMenuItem.Name = "ReportMenuItem";
            this.ReportMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ReportMenuItem.Text = "Bug Report";
            this.ReportMenuItem.Click += new System.EventHandler(this.ReportMenuItem_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.Transparent;
            this.StartBtn.Location = new System.Drawing.Point(6, 17);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(74, 22);
            this.StartBtn.Skin = System.Drawing.Color.DodgerBlue;
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.Click += new System.EventHandler(this.SBStartBotBtn_Click);
            // 
            // PoisonGrp
            // 
            this.PoisonGrp.Controls.Add(this.AddPoisonBtn);
            this.PoisonGrp.Controls.Add(this.PoisonListCbbx);
            this.PoisonGrp.Location = new System.Drawing.Point(11, 28);
            this.PoisonGrp.Name = "PoisonGrp";
            this.PoisonGrp.Size = new System.Drawing.Size(242, 46);
            this.PoisonGrp.TabIndex = 2;
            this.PoisonGrp.TabStop = false;
            this.PoisonGrp.Text = "Poison List (0)";
            // 
            // AddPoisonBtn
            // 
            this.AddPoisonBtn.BackColor = System.Drawing.Color.Transparent;
            this.AddPoisonBtn.Location = new System.Drawing.Point(178, 17);
            this.AddPoisonBtn.Name = "AddPoisonBtn";
            this.AddPoisonBtn.Size = new System.Drawing.Size(58, 22);
            this.AddPoisonBtn.Skin = System.Drawing.Color.DodgerBlue;
            this.AddPoisonBtn.TabIndex = 5;
            this.AddPoisonBtn.Text = "Add";
            this.AddPoisonBtn.Click += new System.EventHandler(this.SBAddPoisonBtn_Click);
            // 
            // PoisonListCbbx
            // 
            this.PoisonListCbbx.Enabled = false;
            this.PoisonListCbbx.FormattingEnabled = true;
            this.PoisonListCbbx.Location = new System.Drawing.Point(6, 17);
            this.PoisonListCbbx.Name = "PoisonListCbbx";
            this.PoisonListCbbx.Size = new System.Drawing.Size(166, 21);
            this.PoisonListCbbx.TabIndex = 0;
            this.PoisonListCbbx.Text = "Loading furnidata..";
            this.PoisonListCbbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PoisonListCbbx_KeyPress);
            // 
            // StartGrp
            // 
            this.StartGrp.Controls.Add(this.StatusBtn);
            this.StartGrp.Controls.Add(this.StartBtn);
            this.StartGrp.Location = new System.Drawing.Point(10, 79);
            this.StartGrp.Name = "StartGrp";
            this.StartGrp.Size = new System.Drawing.Size(242, 45);
            this.StartGrp.TabIndex = 5;
            this.StartGrp.TabStop = false;
            this.StartGrp.Text = "Start Options (Stopped)";
            // 
            // StatusBtn
            // 
            this.StatusBtn.Location = new System.Drawing.Point(86, 18);
            this.StatusBtn.Name = "StatusBtn";
            this.StatusBtn.ReadOnly = true;
            this.StatusBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StatusBtn.Size = new System.Drawing.Size(150, 20);
            this.StatusBtn.TabIndex = 2;
            this.StatusBtn.Text = "Waiting...";
            this.StatusBtn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BluePanelBottom
            // 
            this.BluePanelBottom.BackColor = System.Drawing.Color.DodgerBlue;
            this.BluePanelBottom.Location = new System.Drawing.Point(-14, 133);
            this.BluePanelBottom.Name = "BluePanelBottom";
            this.BluePanelBottom.Size = new System.Drawing.Size(300, 2);
            this.BluePanelBottom.TabIndex = 7;
            // 
            // VersionTxt
            // 
            this.VersionTxt.ActiveLinkColor = System.Drawing.Color.Indigo;
            this.VersionTxt.AutoSize = true;
            this.VersionTxt.LinkColor = System.Drawing.Color.DodgerBlue;
            this.VersionTxt.Location = new System.Drawing.Point(3, 141);
            this.VersionTxt.Name = "VersionTxt";
            this.VersionTxt.Size = new System.Drawing.Size(37, 13);
            this.VersionTxt.TabIndex = 8;
            this.VersionTxt.TabStop = true;
            this.VersionTxt.Text = "v4.2.0";
            this.VersionTxt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.VersionTxt_LinkClicked);
            // 
            // Sep
            // 
            this.Sep.BackColor = System.Drawing.Color.DodgerBlue;
            this.Sep.Location = new System.Drawing.Point(44, 138);
            this.Sep.Name = "Sep";
            this.Sep.Size = new System.Drawing.Size(2, 20);
            this.Sep.TabIndex = 9;
            // 
            // GithubLnk
            // 
            this.GithubLnk.ActiveLinkColor = System.Drawing.Color.Indigo;
            this.GithubLnk.AutoSize = true;
            this.GithubLnk.LinkColor = System.Drawing.Color.DodgerBlue;
            this.GithubLnk.Location = new System.Drawing.Point(55, 141);
            this.GithubLnk.Name = "GithubLnk";
            this.GithubLnk.Size = new System.Drawing.Size(80, 13);
            this.GithubLnk.TabIndex = 10;
            this.GithubLnk.TabStop = true;
            this.GithubLnk.Text = "GitHub/SFFBot";
            this.GithubLnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLnk_LinkClicked);
            // 
            // MessageTxt
            // 
            this.MessageTxt.AutoSize = true;
            this.MessageTxt.Location = new System.Drawing.Point(10, 177);
            this.MessageTxt.Name = "MessageTxt";
            this.MessageTxt.Size = new System.Drawing.Size(0, 13);
            this.MessageTxt.TabIndex = 12;
            // 
            // FixPanel
            // 
            this.FixPanel.Location = new System.Drawing.Point(0, -32);
            this.FixPanel.Name = "FixPanel";
            this.FixPanel.Size = new System.Drawing.Size(272, 167);
            this.FixPanel.TabIndex = 13;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(261, 159);
            this.Controls.Add(this.BluePanelBottom);
            this.Controls.Add(this.StartGrp);
            this.Controls.Add(this.SBMenuStrip);
            this.Controls.Add(this.PoisonGrp);
            this.Controls.Add(this.FixPanel);
            this.Controls.Add(this.GithubLnk);
            this.Controls.Add(this.MessageTxt);
            this.Controls.Add(this.Sep);
            this.Controls.Add(this.VersionTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.SBMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFFBot - v4.2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SBMain_FormClosing);
            this.Load += new System.EventHandler(this.SBMain_Load);
            this.SBMenuStrip.ResumeLayout(false);
            this.SBMenuStrip.PerformLayout();
            this.PoisonGrp.ResumeLayout(false);
            this.StartGrp.ResumeLayout(false);
            this.StartGrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip SBMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SBHeadersMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AlwaysOnTopCkbx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem DropMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MoveMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem WalkMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SBHelpMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SBAboutButton;
        private Sulakore.Components.SKoreButton StartBtn;
        private System.Windows.Forms.GroupBox PoisonGrp;
        private System.Windows.Forms.ComboBox PoisonListCbbx;
        private Sulakore.Components.SKoreButton AddPoisonBtn;
        private System.Windows.Forms.GroupBox StartGrp;
        private System.Windows.Forms.TextBox StatusBtn;
        private System.Windows.Forms.ToolStripMenuItem SBPoisonCkbx;
        private System.Windows.Forms.ToolStripMenuItem SBDelayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SB100Ckbx;
        private System.Windows.Forms.ToolStripMenuItem SB400Ckbx;
        private System.Windows.Forms.ToolStripMenuItem SB600Ckbx;
        private System.Windows.Forms.ToolStripMenuItem SB800Ckbx;
        private System.Windows.Forms.ToolStripMenuItem SB1000Ckbx;
        private System.Windows.Forms.ToolStripMenuItem DropTxt;
        private System.Windows.Forms.ToolStripMenuItem MoveTxt;
        private System.Windows.Forms.ToolStripMenuItem WalkTxt;
        private System.Windows.Forms.ToolStripMenuItem Walk2MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Walk2Txt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ClearPoisonBtn;
        private System.Windows.Forms.ToolStripMenuItem ReportMenuItem;
        private System.Windows.Forms.Panel BluePanelBottom;
        private System.Windows.Forms.LinkLabel VersionTxt;
        private System.Windows.Forms.Panel Sep;
        private System.Windows.Forms.LinkLabel GithubLnk;
        private System.Windows.Forms.Label MessageTxt;
        private System.Windows.Forms.Panel FixPanel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectTileBtn;
        private System.Windows.Forms.ToolStripMenuItem UseSelectedTileCkbx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem OpenSettingsBtn;
        private System.Windows.Forms.ToolStripMenuItem OpenHotkeysBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem CustomDelayOpenDlg;
        private System.Windows.Forms.ToolStripMenuItem SBCustomDelay;
        private System.Windows.Forms.ToolStripMenuItem AutoStopCkbx;
        private System.Windows.Forms.ToolStripMenuItem SB200Ckbx;
    }
}

