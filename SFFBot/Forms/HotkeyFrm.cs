using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static SFFBot.Properties.Settings;

namespace SFFBot.Dialogs
{
    public partial class HotkeyFrm : Form
    {
        private MainFrm _main;
        private HotkeyManager _htkMngr;

        public HotkeyFrm(MainFrm main)
        {
            InitializeComponent();
            _main = main;
            _htkMngr = new HotkeyManager(main);

            ToggleBotStateHtkBox.Box.KeyDown += ToggleBotStateHtkBox_KeyDown;
            TogglePoisonStateHtkBox.Box.KeyDown += TogglePoisonStateHtkBox_KeyDown;
        }

        private void HotkeyFrm_Load(object sender, EventArgs e)
        {
            var args = new KeyEventArgs(Default.ToggleBotStateHtk);
            ToggleBotStateHtkBox.Value = KeyToString(args);
            BotToggleGrpb.Text = $"Toggle Bot State [{KeyToString(args)}]";

            var argss = new KeyEventArgs(Default.TogglePoisonStateHtk);
            TogglePoisonStateHtkBox.Value = KeyToString(argss);
            PoisonHtkGrpb.Text = $"Toggle Poison State[{KeyToString(argss)}]";
        }

        public string KeyToString(KeyEventArgs e)
        { 
            string returnData = string.Empty;

            if (e.Modifiers != Keys.None)
                returnData += e.Modifiers;

            if (returnData != string.Empty && e.KeyCode != Keys.None
                                            && e.KeyCode != Keys.Menu
                                             && e.KeyCode != Keys.ControlKey)
                returnData += " + ";

            if(e.KeyCode != Keys.Menu && e.KeyCode != Keys.ControlKey)
                returnData += e.KeyCode;

            return returnData.ToUpper();
        }
    
        private void ToggleBotStateHtkBox_KeyDown(object sender, KeyEventArgs e)
        {
            Default.ToggleBotStateHtk = e.KeyData;
            Default.Save();

            _htkMngr.SetHotkey(e, _main.ToggleBotState);
            
            ToggleBotStateHtkBox.Value = KeyToString(e);
            BotToggleGrpb.Text = $"Toggle Bot State [{KeyToString(e)}]";
        }

        private void TogglePoisonStateHtkBox_KeyDown(object sender, KeyEventArgs e)
        {
            Default.TogglePoisonStateHtk = e.KeyData;
            Default.Save();

            _htkMngr.SetHotkey(e, _main.TogglePoisonState);

            TogglePoisonStateHtkBox.Value = KeyToString(e);
            PoisonHtkGrpb.Text = $"Toggle Poison State [{KeyToString(e)}]";
        }
    }
}
