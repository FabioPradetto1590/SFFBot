namespace SFFBot.Dialogs
{
    partial class AboutFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutFrm));
            this.BotLogoPbx = new System.Windows.Forms.PictureBox();
            this.SFFLogo = new System.Windows.Forms.PictureBox();
            this.TitleTxt = new System.Windows.Forms.Label();
            this.SFFVersionTxt = new System.Windows.Forms.Label();
            this.Sep1 = new System.Windows.Forms.Panel();
            this.SFFDescriptionTxt = new System.Windows.Forms.Label();
            this.Sep2 = new System.Windows.Forms.Panel();
            this.ThanksTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BotLogoPbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFFLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BotLogoPbx
            // 
            this.BotLogoPbx.Location = new System.Drawing.Point(-5, 4);
            this.BotLogoPbx.Name = "BotLogoPbx";
            this.BotLogoPbx.Size = new System.Drawing.Size(128, 128);
            this.BotLogoPbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BotLogoPbx.TabIndex = 0;
            this.BotLogoPbx.TabStop = false;
            // 
            // SFFLogo
            // 
            this.SFFLogo.Image = global::SFFBot.Properties.Resources.BotLogo;
            this.SFFLogo.Location = new System.Drawing.Point(-4, 5);
            this.SFFLogo.Name = "SFFLogo";
            this.SFFLogo.Size = new System.Drawing.Size(118, 128);
            this.SFFLogo.TabIndex = 0;
            this.SFFLogo.TabStop = false;
            // 
            // TitleTxt
            // 
            this.TitleTxt.AutoSize = true;
            this.TitleTxt.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.TitleTxt.Location = new System.Drawing.Point(114, 15);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(82, 26);
            this.TitleTxt.TabIndex = 1;
            this.TitleTxt.Text = "SFFBot";
            // 
            // SFFVersionTxt
            // 
            this.SFFVersionTxt.AutoSize = true;
            this.SFFVersionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFFVersionTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.SFFVersionTxt.Location = new System.Drawing.Point(192, 24);
            this.SFFVersionTxt.Name = "SFFVersionTxt";
            this.SFFVersionTxt.Size = new System.Drawing.Size(75, 13);
            this.SFFVersionTxt.TabIndex = 2;
            this.SFFVersionTxt.Text = "v1.33.7 | 2016";
            // 
            // Sep1
            // 
            this.Sep1.BackColor = System.Drawing.Color.Gainsboro;
            this.Sep1.Location = new System.Drawing.Point(115, 40);
            this.Sep1.Name = "Sep1";
            this.Sep1.Size = new System.Drawing.Size(145, 1);
            this.Sep1.TabIndex = 3;
            // 
            // SFFDescriptionTxt
            // 
            this.SFFDescriptionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SFFDescriptionTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.SFFDescriptionTxt.Location = new System.Drawing.Point(116, 46);
            this.SFFDescriptionTxt.Name = "SFFDescriptionTxt";
            this.SFFDescriptionTxt.Size = new System.Drawing.Size(135, 44);
            this.SFFDescriptionTxt.TabIndex = 4;
            this.SFFDescriptionTxt.Text = "SFFBot is extension to cheat in Falling Furniture Game. By Speaqer";
            // 
            // Sep2
            // 
            this.Sep2.BackColor = System.Drawing.Color.Gainsboro;
            this.Sep2.Location = new System.Drawing.Point(115, 90);
            this.Sep2.Name = "Sep2";
            this.Sep2.Size = new System.Drawing.Size(80, 1);
            this.Sep2.TabIndex = 4;
            // 
            // ThanksTxt
            // 
            this.ThanksTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThanksTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(83)))), ((int)(((byte)(91)))));
            this.ThanksTxt.Location = new System.Drawing.Point(114, 95);
            this.ThanksTxt.Name = "ThanksTxt";
            this.ThanksTxt.Size = new System.Drawing.Size(154, 36);
            this.ThanksTxt.TabIndex = 5;
            this.ThanksTxt.Text = "Big thanks to Arachis, ScottStamp, Mika, Adversities";
            // 
            // AboutFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(273, 131);
            this.Controls.Add(this.ThanksTxt);
            this.Controls.Add(this.Sep2);
            this.Controls.Add(this.SFFDescriptionTxt);
            this.Controls.Add(this.Sep1);
            this.Controls.Add(this.SFFVersionTxt);
            this.Controls.Add(this.TitleTxt);
            this.Controls.Add(this.SFFLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About SFFBot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AboutFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BotLogoPbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SFFLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox BotLogoPbx;
        private System.Windows.Forms.PictureBox SFFLogo;
        private System.Windows.Forms.Label TitleTxt;
        private System.Windows.Forms.Label SFFVersionTxt;
        private System.Windows.Forms.Panel Sep1;
        private System.Windows.Forms.Label SFFDescriptionTxt;
        private System.Windows.Forms.Panel Sep2;
        private System.Windows.Forms.Label ThanksTxt;
    }
}