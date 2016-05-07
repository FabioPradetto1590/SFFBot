using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tangine;

using Sulakore.Modules;
using Sulakore.Habbo;
using Sulakore.Communication;

using SFFBot.Utils;
using static SFFBot.Properties.Settings;

namespace SFFBot.Dialogs
{
    [GitHub("Speaqer", "SFFBot")]
    [Module("SFFBot", "Bot for Falling Furniture game.")]
    [Author("Speaqer", ResourceName = "SFFBot's webpage", ResourceUrl = "http://sffbot.speaqer.eu", HabboName = "TBH-Speaqer", Hotel = HHotel.Com)]
    [Author("Speaqer", ResourceName = "SFFBot's webpage", ResourceUrl = "http://sffbot.speaqer.eu", HabboName = "TBH-Speaqer", Hotel = HHotel.Nl)]
    [Author("Speaqer", ResourceName = "SFFBot's webpage", ResourceUrl = "http://sffbot.speaqer.eu", HabboName = "Speaqer-V", Hotel = HHotel.Fi)]
    [Author("Adversities", ResourceName ="Adversities Sulakore", ResourceUrl = "http://sulakore.com/member.php?action=profile&uid=23", HabboName ="Sulakore", Hotel = HHotel.Es)]

    public partial class SplashFrm : ExtensionForm
    {
        public SplashFrm()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            TransparencyKey = BackColor;
        }

        
        private void SplashFrm_Load(object sender, EventArgs e)
        {
            if (Default.ShowSplash)
                SplashTmr1.Start();
            else
                CloseForm();
        }

        #region Animation
        private void SplashTmr1_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                SplashTmr1.Stop();
                Thread.Sleep(3000);
                SplashTmr2.Start();
            }
            else
                Opacity += 0.05;
        }

        private void SplashTmr2_Tick(object sender, EventArgs e)
        {
            if (Opacity <= 0.00)
            {
                SplashTmr2.Stop();
                CloseForm();
            }
            else
                Opacity -= 0.05;
        }
        #endregion

        public ushort GetHdr(string hash) => 
            Game.GetMessageHeader(Game.GetMessages(hash)[0]);

        private void CloseForm()
        {
            if(Game == null)
            {
                MessageBox.Show("Error occurred! Please restart your Tanji, if it doesn't fix it, contact Speaqer.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HeaderManager.OutPlayerWalk = GetHdr("5dec6a7881d4a598d5b15d0e743bcdcb");
            HeaderManager.InPlayerWalk = GetHdr("45d53173f4bf410c6f0d57f0fb0edca3");
            HeaderManager.InDropFurniture = GetHdr("e4e3bc19857c5495fcdcff4f36d17d3d");
            HeaderManager.InMoveFurniture = GetHdr("e76f17ac4a9202cf49c2778fc2438654");
            HeaderManager.InEntitiesLoad = GetHdr("4edb850e832ac9873c9650d68779fc4d");
            HeaderManager.InShowNotification = GetHdr("823973d6a28dcd0da8954c594b62c54b");
            Hide();

            var frm = new MainFrm(this);
            frm.Show();
        }
    }
}