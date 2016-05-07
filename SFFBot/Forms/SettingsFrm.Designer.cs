namespace SFFBot.Dialogs
{
    partial class SettingsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsFrm));
            this.ShowSplashChck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ShowSplashChck
            // 
            this.ShowSplashChck.AutoSize = true;
            this.ShowSplashChck.Checked = true;
            this.ShowSplashChck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowSplashChck.Location = new System.Drawing.Point(16, 13);
            this.ShowSplashChck.Name = "ShowSplashChck";
            this.ShowSplashChck.Size = new System.Drawing.Size(88, 17);
            this.ShowSplashChck.TabIndex = 0;
            this.ShowSplashChck.Text = "Show Splash";
            this.ShowSplashChck.UseVisualStyleBackColor = true;
            this.ShowSplashChck.CheckedChanged += new System.EventHandler(this.ShowSplashChck_CheckedChanged);
            // 
            // SettingsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(218, 38);
            this.Controls.Add(this.ShowSplashChck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SettingsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFFBot - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ShowSplashChck;
    }
}