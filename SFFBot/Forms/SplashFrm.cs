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

using static SFFBot.Properties.Settings;
using System.IO;
using Sulakore.Habbo.Headers;
using Tangine.Habbo;

namespace SFFBot.Dialogs
{
    [GitHub("Speaqer", "SFFBot")]
    [Module("SFFBot", "Bot for Falling Furniture game.")]
    [Author("Speaqer", HabboName = "Speaqer-VIII", Hotel = HHotel.Fi)]
    [Author("Speaqer", HabboName = "TBH-Speaqer", Hotel = HHotel.Com)]
    [Author("Speaqer", HabboName = "TBH-Speaqer", Hotel = HHotel.Nl)]
    [Author("Adversities", HabboName ="Sulakore", Hotel = HHotel.Es)]

    public partial class SplashFrm : ExtensionForm
    {
        private bool _hasHeaders;
        private TaskCompletionSource<bool> _gotHeadersAwaitable;

        public override bool IsRemoteModule { get; } = true;

        public SplashFrm()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();

            _gotHeadersAwaitable = new TaskCompletionSource<bool>();

            if (_hasHeaders = (Game != null))
                _gotHeadersAwaitable.SetResult(true);

            TransparencyKey = BackColor;
            Text = $"SFFBot v{Program.Version}- Initializing";

            string transitionsName = @"Installed Modules\Dependencies\Transitions.dll"; 

            if (File.Exists(transitionsName) && !File.Exists("Transitions.dll"))
                File.Move(transitionsName, "Transitions.dll");
        }
        private void SplashFrm_Load(object sender, EventArgs e)
        {
            if (!Default.ShowSplash)
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

        public override void ModifyGame(HGame game)
        {
            if (!_hasHeaders)
                _gotHeadersAwaitable.SetResult(true);

            base.ModifyGame(game);
        }

        private void CloseForm()
        {
            bool continuee = _gotHeadersAwaitable.Task.Result;
            if (!continuee) return;

            Outgoing.Global.MoveAvatar = Game.GetHeader("5dec6a7881d4a598d5b15d0e743bcdcb");
            Outgoing.Global.Chat = Game.GetHeader("0112c940712e9061bdaa2b9581216551");
            Incoming.Global.Chat = Game.GetHeader("4c310dd04b5f13450d02d224ba31580d");
            Incoming.Global.HeightMap = Game.GetHeader("28b93d64f5126a5b304f088c384c974e");
            Incoming.Global.UserUpdate = Game.GetHeader("45d53173f4bf410c6f0d57f0fb0edca3");
            Incoming.Global.ObjectAdd = Game.GetHeader("e4e3bc19857c5495fcdcff4f36d17d3d");
            Incoming.Global.ObjectUpdate = Game.GetHeader("e76f17ac4a9202cf49c2778fc2438654");
            Incoming.Global.ObjectRemove = Game.GetHeader("3e9e6a414018cd45c2464e65cc5731f6");
            Incoming.Global.RoomNotification = Game.GetHeader("823973d6a28dcd0da8954c594b62c54b");
            Hide();

            _gotHeadersAwaitable.Task.Dispose();
            var frm = new MainFrm(this);
            frm.Show();
        }
    }
}