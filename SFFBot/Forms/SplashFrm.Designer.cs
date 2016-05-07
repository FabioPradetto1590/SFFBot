namespace SFFBot.Dialogs
{
    partial class SplashFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashFrm));
            this.SplashTmr1 = new System.Windows.Forms.Timer(this.components);
            this.SplashTmr2 = new System.Windows.Forms.Timer(this.components);
            this.SplashImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SplashImg)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashTmr1
            // 
            this.SplashTmr1.Interval = 50;
            this.SplashTmr1.Tick += new System.EventHandler(this.SplashTmr1_Tick);
            // 
            // SplashTmr2
            // 
            this.SplashTmr2.Interval = 50;
            this.SplashTmr2.Tick += new System.EventHandler(this.SplashTmr2_Tick);
            // 
            // SplashImg
            // 
            this.SplashImg.Image = global::SFFBot.Properties.Resources.SplashFrmImg;
            this.SplashImg.Location = new System.Drawing.Point(0, 0);
            this.SplashImg.Name = "SplashImg";
            this.SplashImg.Size = new System.Drawing.Size(342, 202);
            this.SplashImg.TabIndex = 0;
            this.SplashImg.TabStop = false;
            // 
            // SplashFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 202);
            this.Controls.Add(this.SplashImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashFrm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFFBot v0.1.0 - Initializing";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SplashFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SplashImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer SplashTmr1;
        private System.Windows.Forms.Timer SplashTmr2;
        private System.Windows.Forms.PictureBox SplashImg;
    }
}