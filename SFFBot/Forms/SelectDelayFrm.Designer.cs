namespace SFFBot
{
    partial class SelectDelayFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDelayFrm));
            this.SetDelayBtn = new Sulakore.Components.SKoreButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DelayTBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayTBar)).BeginInit();
            this.SuspendLayout();
            // 
            // SetDelayBtn
            // 
            this.SetDelayBtn.BackColor = System.Drawing.Color.Transparent;
            this.SetDelayBtn.Location = new System.Drawing.Point(96, 89);
            this.SetDelayBtn.Name = "SetDelayBtn";
            this.SetDelayBtn.Size = new System.Drawing.Size(128, 20);
            this.SetDelayBtn.Skin = System.Drawing.Color.DodgerBlue;
            this.SetDelayBtn.TabIndex = 0;
            this.SetDelayBtn.Text = "Save (0ms)";
            this.SetDelayBtn.Click += new System.EventHandler(this.SetDelayBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DelayTBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 67);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Delay Time (ms)";
            // 
            // DelayTBar
            // 
            this.DelayTBar.LargeChange = 200;
            this.DelayTBar.Location = new System.Drawing.Point(6, 20);
            this.DelayTBar.Maximum = 1000;
            this.DelayTBar.Name = "DelayTBar";
            this.DelayTBar.Size = new System.Drawing.Size(281, 45);
            this.DelayTBar.TabIndex = 0;
            this.DelayTBar.TickFrequency = 50;
            this.DelayTBar.Scroll += new System.EventHandler(this.DelayTBar_Scroll);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(-7, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 2);
            this.panel1.TabIndex = 10;
            // 
            // SelectDelayFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 111);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SetDelayBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectDelayFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFFBot - Select Delay";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DelayTBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sulakore.Components.SKoreButton SetDelayBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar DelayTBar;
    }
}