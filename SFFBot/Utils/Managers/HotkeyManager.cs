using SFFBot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static SFFBot.Properties.Settings;

namespace SFFBot
{
    public class HotkeyManager
    {
        MainFrm _main;
        public HotkeyManager(MainFrm main)
        {
            _main = main;
        }

        public void Init()
        {
            _main.HotkeyHook = new KeyboardHook();
            _main.HotkeyHook.HotkeyActivated += _main.HotkeyActivated;
            LoadHotkeys();
        }

        public void LoadHotkeys()
        {
            SetHotkey(new KeyEventArgs(Default.ToggleBotStateHtk), _main.ToggleBotState);
            SetHotkey(new KeyEventArgs(Default.TogglePoisonStateHtk), _main.TogglePoisonState);
        }

        public void SetHotkey(KeyEventArgs e, Action act)
        {
            if (_main.Hotkeys.ContainsKey(act))
            {
                _main.HotkeyHook.UnregisterHotkey(e.KeyData);
                _main.HotkeyHook.RegisterHotkey(e.KeyData);
                _main.Hotkeys[act] = e.KeyData;
            }
            else
            {
                _main.HotkeyHook.RegisterHotkey(e.KeyData);
                _main.Hotkeys.Add(act, e.KeyData);
            }
        }
    }
}
