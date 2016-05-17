namespace SFFBot.Dialogs
{
    partial class HotkeyFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyFrm));
            this.BotToggleGrpb = new System.Windows.Forms.GroupBox();
            this.ToggleBotStateHtkBox = new SFFBot.Components.SKoreLabelBox();
            this.PoisonHtkGrpb = new System.Windows.Forms.GroupBox();
            this.TogglePoisonStateHtkBox = new SFFBot.Components.SKoreLabelBox();
            this.DescriptionTxt = new Sulakore.Components.SKoreLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BotToggleGrpb.SuspendLayout();
            this.PoisonHtkGrpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // BotToggleGrpb
            // 
            this.BotToggleGrpb.Controls.Add(this.ToggleBotStateHtkBox);
            this.BotToggleGrpb.Location = new System.Drawing.Point(13, 41);
            this.BotToggleGrpb.Name = "BotToggleGrpb";
            this.BotToggleGrpb.Size = new System.Drawing.Size(167, 50);
            this.BotToggleGrpb.TabIndex = 9;
            this.BotToggleGrpb.TabStop = false;
            this.BotToggleGrpb.Text = "Toggle Bot State [NONE]";
            // 
            // ToggleBotStateHtkBox
            // 
            this.ToggleBotStateHtkBox.BackColor = System.Drawing.Color.DodgerBlue;
            this.ToggleBotStateHtkBox.Location = new System.Drawing.Point(9, 19);
            this.ToggleBotStateHtkBox.Name = "ToggleBotStateHtkBox";
            this.ToggleBotStateHtkBox.Size = new System.Drawing.Size(148, 20);
            this.ToggleBotStateHtkBox.TabIndex = 0;
            this.ToggleBotStateHtkBox.Text = "Hotkey";
            this.ToggleBotStateHtkBox.Value = "NONE";
            this.ToggleBotStateHtkBox.ValueAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToggleBotStateHtkBox.ValueReadOnly = true;
            // 
            // PoisonHtkGrpb
            // 
            this.PoisonHtkGrpb.Controls.Add(this.TogglePoisonStateHtkBox);
            this.PoisonHtkGrpb.Location = new System.Drawing.Point(188, 41);
            this.PoisonHtkGrpb.Name = "PoisonHtkGrpb";
            this.PoisonHtkGrpb.Size = new System.Drawing.Size(167, 50);
            this.PoisonHtkGrpb.TabIndex = 10;
            this.PoisonHtkGrpb.TabStop = false;
            this.PoisonHtkGrpb.Text = "Toggle Poison [NONE]";
            // 
            // TogglePoisonStateHtkBox
            // 
            this.TogglePoisonStateHtkBox.BackColor = System.Drawing.Color.DodgerBlue;
            this.TogglePoisonStateHtkBox.Location = new System.Drawing.Point(9, 19);
            this.TogglePoisonStateHtkBox.Name = "TogglePoisonStateHtkBox";
            this.TogglePoisonStateHtkBox.Size = new System.Drawing.Size(148, 20);
            this.TogglePoisonStateHtkBox.TabIndex = 1;
            this.TogglePoisonStateHtkBox.Text = "Hotkey";
            this.TogglePoisonStateHtkBox.Value = "NONE";
            this.TogglePoisonStateHtkBox.ValueAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TogglePoisonStateHtkBox.ValueReadOnly = true;
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.AutoSize = true;
            this.DescriptionTxt.Location = new System.Drawing.Point(9, 10);
            this.DescriptionTxt.MaximumSize = new System.Drawing.Size(360, 0);
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.Size = new System.Drawing.Size(360, 13);
            this.DescriptionTxt.TabIndex = 11;
            this.DescriptionTxt.Text = "Here you can edit and see your hotkeys. Changes are saved automatically.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(-4, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 2);
            this.panel1.TabIndex = 9;
            // 
            // HotkeyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 99);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DescriptionTxt);
            this.Controls.Add(this.PoisonHtkGrpb);
            this.Controls.Add(this.BotToggleGrpb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "HotkeyFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFFBot - Hotkeys";
            this.Load += new System.EventHandler(this.HotkeyFrm_Load);
            this.BotToggleGrpb.ResumeLayout(false);
            this.PoisonHtkGrpb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox BotToggleGrpb;
        private SFFBot.Components.SKoreLabelBox ToggleBotStateHtkBox;
        private System.Windows.Forms.GroupBox PoisonHtkGrpb;
        private SFFBot.Components.SKoreLabelBox TogglePoisonStateHtkBox;
        private Sulakore.Components.SKoreLabel DescriptionTxt;
        private System.Windows.Forms.Panel panel1;
    }
}