using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFFBot
{
    public partial class SelectDelayFrm : Form
    {
        private MainFrm _main;

        public SelectDelayFrm(MainFrm main)
        {
            InitializeComponent();
            _main = main;

            DelayTBar.Value = _main.CustomDelay;
        }

        private void DelayTBar_Scroll(object sender, EventArgs e)
        {
            SetDelayBtn.Text = $"Save ({DelayTBar.Value}ms)";
        }

        private void SetDelayBtn_Click(object sender, EventArgs e)
        {
            _main.SetCustomDelay(DelayTBar.Value);
            Close();
        }
    }
}
