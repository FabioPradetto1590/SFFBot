using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SFFBot.Properties.Settings;

namespace SFFBot.Dialogs
{
    public partial class SettingsFrm : Form
    {
        public SettingsFrm()
        {
            InitializeComponent();
            ShowSplashChck.Checked = Default.ShowSplash;
        }

        private void ShowSplashChck_CheckedChanged(object sender, EventArgs e)
        {
            Default.ShowSplash = ShowSplashChck.Checked;
            Default.Save();
        }
    }
}
