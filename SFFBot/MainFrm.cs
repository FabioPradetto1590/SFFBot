using System;
using System.Xml;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using SFFBot.Utils;
using SFFBot.Classes;
using SFFBot.Dialogs;
using static SFFBot.Properties.Settings;

using Tangine;
using Transitions;
using Sulakore.Habbo;
using Sulakore.Communication;
using Sulakore;

namespace SFFBot
{
    public partial class MainFrm : ExtensionForm
    {
        public readonly Dictionary<Action, Keys> Hotkeys = new Dictionary<Action, Keys>();
        public KeyboardHook HotkeyHook { get; }
        public bool isPoisonRunning, isRunning;

        private List<SPoisonFurni> _furnitureList = new List<SPoisonFurni>();
        private List<SStatus> _currStatuses = new List<SStatus>();
        private List<ToolStripMenuItem> _delayCheckeds;
        private List<Control> _bottomControls;
        private HotkeyManager _htkManager;
       
        private SplashFrm _main;

        private bool _isSelectingTile;
        private HPoint _selectedTile = null;
        private bool _canGo;
        private int _delay;

        public MainFrm(SplashFrm main)
        {
            InitializeComponent();
            _main = main;

            _delayCheckeds = new List<ToolStripMenuItem>{
                SB100Ckbx, SB400Ckbx, SB600Ckbx,SB800Ckbx,
                SB1000Ckbx };

            _bottomControls = new List<Control>{
                VersionTxt, Sep, GithubLnk };

            HotkeyHook = new KeyboardHook();
            HotkeyHook.HotkeyActivated += HotkeyActivated;

            _htkManager = new HotkeyManager(this);
            _htkManager.LoadHotkeys();
        }

        private void HotkeyActivated(object sender, KeyEventArgs e)
        {
            if (Hotkeys.ContainsValue(e.KeyData))
                Hotkeys.FirstOrDefault(s => s.Value == e.KeyData).Key();
        }

        #region Bot functions

        public async void HandleFurniture(DataInterceptedEventArgs e)
        {
            if (!isRunning) return;

            CheckTool(e.Packet.ReadInteger(4));

            if (!_canGo) return;

            int X = e.Packet.ReadInteger(8), Y = e.Packet.ReadInteger(12);

            if (UseSelectedTileCkbx.Checked)
            {
                if (_selectedTile.X != X || _selectedTile.Y != Y) return;
                else
                    ShowNotification(1, "Furniture placed to selected Tile!");
            }
            
            foreach (var checkeds in _delayCheckeds.Where(c => c.Checked))
                await Task.Delay(_delay);

            await _main.Connection.SendToServerAsync(HeaderManager.OutPlayerWalk, X, Y);
        }

        public void HandleTileSelecting(DataInterceptedEventArgs e)
        {
            if (!_isSelectingTile) return;

            int X = e.Packet.ReadInteger(), Y = e.Packet.ReadInteger();

            _selectedTile = new HPoint(X, Y);

            ShowNotification(1, $"Tile selected!\rX: {X} Y: {Y}");

            e.IsBlocked = true;
            _isSelectingTile = false;

            Invoke(new MethodInvoker(() =>
            {
                SelectTileBtn.Text = "Select Tile";
                UseSelectedTileCkbx.Enabled = true;
            }));
        }

        public async void ShowNotification(int Type, string message)
        {
            switch (Type)
            {
                case 1:
                    await _main.Connection.SendToClientAsync(HeaderManager.InShowNotification, "furni_placement_error", 1, "message", message);
                    break;
                case 2:
                    Invoke(new MethodInvoker(() =>
                    {
                        StatusBtn.Text = message;
                    }));
                    break;
            }
        }

        #endregion

        public void ShowNotification(SStatus status)
        {
            Transition t1 = new Transition(new TransitionType_Linear(750));
            t1.add(MessageTxt, "Top", 141);

            if (_currStatuses.Any(a => a.IsShowed))
            {
                _currStatuses.Where(a => a.IsShowed).ToList().ForEach(statuz =>
                    {
                        if (statuz.TypeID == status.TypeID)
                        {
                            statuz.Times++;
                            MessageTxt.Text = $"{statuz.Message} ({statuz.Times}x)";
                            t1.add(MessageTxt, "ForeColor", statuz.TextColor);
                        }
                        else
                        {
                            status.IsShowed = true;
                            _currStatuses.Add(status);
                            MessageTxt.Text += $" | {status.Message}";
                        }
                    });
            }
            else
            {
                status.IsShowed = true;
                MessageTxt.Text = status.Message;
                _currStatuses.Add(status);
                t1.add(MessageTxt, "ForeColor", status.TextColor);

                if (Sep.Location.Y > 108)
                    _bottomControls.RunTransition(750, "Top", Sep.Location.Y, false);
            }

            t1.run();

            t1.TransitionCompletedEvent += async (s, e) =>
            {
                await Task.Delay(_currStatuses.Sum(x => x.Time));

                Transition t2 = new Transition(new TransitionType_Linear(status.ScrollTime));
                t2.add(MessageTxt, "Left", MessageTxt.Location.X - (MessageTxt.Width + 10));
                t2.run();

                t2.TransitionCompletedEvent += (a, b) =>
                {
                    _currStatuses.Clear();

                    Invoke(new MethodInvoker(() =>
                    {
                        MessageTxt.Location = new Point(10, 177); 
                        MessageTxt.ForeColor = SystemColors.ControlText;
                    }));

                    _bottomControls.RunTransition(750, "Top", 138 - Sep.Location.Y, true);

                    if (!_currStatuses.Any())
                        MessageTxt.Text = string.Empty;
                };
            };
        }

        #region Form Actions

        private void SelectTileBtn_Click(object sender, EventArgs e)
        {
            if (_isSelectingTile)
            {
                _isSelectingTile = false;
                SelectTileBtn.Text = "Select Tile";
                ShowNotification(1, "Tile selecting cancelled!");

                _main.Triggers.OutDetach(HeaderManager.OutPlayerWalk);
            }
            else
            {
                _isSelectingTile = true;
                SelectTileBtn.Text = "Cancel Tile Selecting";
                ShowNotification(1, "Select a tile!");

                _main.Triggers.OutAttach(HeaderManager.OutPlayerWalk, HandleTileSelecting);
            }
        }

        private async void SBMain_Load(object sender, EventArgs e)
        {
            Task loadFurniTask = LoadFurniDataAsync();

            Text = $"SFFBot - v{Program.Version}";

            StartGrp.Location = new Point(-252, 79);
            PoisonGrp.Location = new Point(11, -23);

            AlwaysOnTopCkbx.Checked = TopMost = Default.TopMost;
            ShowHeaders();

            STransition.Run(1300, new TArgument[]{
                new TArgument(PoisonGrp, "Top", 27),
                new TArgument(StartGrp, "Left", 11)});

            ShowNotification(new SStatus(0, 1500, 3000,
               $"Welcome to SFFBot v{Program.Version}! ", SystemColors.ControlText));

            await loadFurniTask;
        }

        private void SBMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Default.TopMost = AlwaysOnTopCkbx.Checked;
            Default.Save();
            _main.Close();
        }

        private void SBAboutButton_Click(object sender, EventArgs e)
        {
            var frm = new AboutFrm();
            frm.ShowDialog();
        }

        private void SBAlwaysOnTopCkbx_Click(object sender, EventArgs e)
        {
            TopMost = AlwaysOnTopCkbx.Checked;
        }

        public void SBPoisonCkbx_Click(object sender, EventArgs e)
        {
            isPoisonRunning = !isPoisonRunning;
        }

        private void OpenSettingsBtn_Click(object sender, EventArgs e)
        {
            var frm = new SettingsFrm();
            frm.ShowDialog();
        }

        private void OpenHotkeysBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It is recommended to set hotkeys to keys that you're not using, otherwise there may come problems!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var frm = new HotkeyFrm(this);
            frm.Show();
            frm.Activate();
        }

        private void SBStartBotBtn_Click(object sender, EventArgs e)
        {
            ToggleBotState();
        }

        private void SBAddPoisonBtn_Click(object sender, EventArgs e)
        {
            string selTxt = PoisonListCbbx?.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selTxt))
            {
                ShowNotification(new SStatus(2, 3000, 2500,
                        "You need to select furni to from list first to poison it!", Color.DarkRed));
                return;
            }

            var poisonFurni = _furnitureList.Find(p => p.FurniId == selTxt.ToPoisonFurni().FurniId);

            if (poisonFurni.IsPoisoned)
                ShowNotification(new SStatus(2, 4000, 3000, "Sorry you already have poisoned this furniture..", Color.DarkRed));
            else
            {
                ShowNotification(new SStatus(2, 3000, 2000, $"Furniture \"{poisonFurni.Name}\" is poisoned!", Color.MediumVioletRed));
                poisonFurni.IsPoisoned = true;
                PoisonListCbbx.ResetText();
            }

            PoisonGrp.Text = $"Poison List ({_furnitureList.FindAll(s => s.IsPoisoned).Count})";
        }

        List<string> list;
        private void PoisonListCbbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selTxt = PoisonListCbbx.Text;
            int i;

            if (string.IsNullOrWhiteSpace(selTxt))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    PoisonListCbbx.DataSource = _furnitureList.Cast<SPoisonFurni>().Select(s => s.ToString()).ToList();
                return;
            }

            List<string> furnitures = _furnitureList.Cast<SPoisonFurni>().Select(s => s.ToString()).ToList();

            if (char.IsNumber(selTxt[0]) && int.TryParse(selTxt, out i))
                list = furnitures.FindAll(s => s.ToPoisonFurni().FurniId == i).ToList();

            if (char.IsLetter(selTxt[0]))
                list = furnitures.FindAll(s => s.ToPoisonFurni().Name.Contains(selTxt)).ToList();

            if (e.KeyChar == (char)Keys.Enter)
                PoisonListCbbx.DataSource = list;
        }

        private void SBClearPoisonBtn_Click(object sender, EventArgs e)
        {
            PoisonGrp.Text = "Poison List (0)";
            _furnitureList.ForEach(p => p.IsPoisoned = false);
        }

        private void GithubLnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Speaqer/SFFBot");
        }

        private void VersionTxt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Speaqer/SFFBot/releases/tag/v" + Program.Version);
        }

        #region Thread-Safe
        public new void Show()
        {
            if (!InvokeRequired)
            {
                base.Show();
                base.Activate();
            }
            else
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    base.Show();
                    base.Activate();
                }));
            }
        }
        public new void Activate()
        {
            if (!InvokeRequired) base.Activate();
            else this.Invoke((MethodInvoker)(() => base.Activate()));
        }
        public new void Hide()
        {
            if (!InvokeRequired) base.Hide();
            else this.Invoke((MethodInvoker)(() => base.Hide()));
        }
        #endregion

        #endregion

        #region DelayCheckings
        private void SelectDelayTime(ToolStripMenuItem item, int delay)
        {
            if (item.Checked)
            {
                foreach (var checkeds in _delayCheckeds)
                    checkeds.Checked = false;
                item.Checked = false;
            }
            else
            {
                foreach (var checkeds in _delayCheckeds)
                    checkeds.Checked = false;
                item.Checked = true;
            }
            ShowNotification(1, $"Delay time set to {delay}ms");
            _delay = delay;
        }

        private void SB100Ckbx_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SB100Ckbx, 100);
        }
        private void SB400Ckbx_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SB400Ckbx, 400);
        }
        private void SB600Ckbx_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SB600Ckbx, 600);
        }
        private void SB800Ckbx_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SB800Ckbx, 800);
        }
        private void SB1000Ckbx_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SB1000Ckbx, 1000);
        }
        #endregion

        #region Functions

        public void ToggleBotState()
        {
            if (!isRunning)
            {
                isRunning = true;
                StartBtn.Text = "Stop";
                StartGrp.Text = "Start Options (Running)";

                _main.Triggers.InAttach(HeaderManager.InDropFurniture, HandleFurniture);
                _main.Triggers.InAttach(HeaderManager.InMoveFurniture, HandleFurniture);
            }
            else
            {
                isRunning = false;
                StartBtn.Text = "Start";
                StartGrp.Text = "Start Options (Stopped)";

                _main.Triggers.InDetach(HeaderManager.InDropFurniture);
                _main.Triggers.InDetach(HeaderManager.InMoveFurniture);
            }
        }

        public void TogglePoisonState()
        {
            if (isPoisonRunning)
            {
                isPoisonRunning = false;
                SBPoisonCkbx.Checked = false;
            }
            else
            {
                isPoisonRunning = true;
                SBPoisonCkbx.Checked = true;
            }
        }

        private void ShowHeaders()
        {
            WalkTxt.Text = HeaderManager.OutPlayerWalk.ToString();
            Walk2Txt.Text = HeaderManager.InPlayerWalk.ToString();
            DropTxt.Text = HeaderManager.InDropFurniture.ToString();
            MoveTxt.Text = HeaderManager.InMoveFurniture.ToString();
            LoadEntitiesTxt.Text = HeaderManager.InEntitiesLoad.ToString();
        }

        private void CheckTool(int id)
        {
            bool canadd = true;

            if (SBPoisonCkbx.Checked)
                if (_furnitureList.Any(s => s.FurniId == id && s.IsPoisoned)) canadd = false;

            ShowNotification(2, canadd ? $"{id}: Clean!" : $"{id}: Poisoned!");

            _canGo = canadd;
        }

        private void glitchBugReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clyde waz here.", "Info - Nothing here yet.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private async Task LoadFurniDataAsync()
        {
            XmlDocument furni = new XmlDocument();

            using (var wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", SKore.ChromeAgent);
                Uri url = new Uri($"http://habbo.{_main.Hotel}/gamedata/furnidata_xml/1");
                furni.LoadXml(await wc.DownloadStringTaskAsync(url));
            }

            XmlNodeList itemNodes = furni.GetElementsByTagName("furnitype");

            foreach (XmlNode item in itemNodes)
            {
                var id = item.Attributes["id"]?.InnerText;
                var name = item["name"]?.InnerText;

                var canGo = (item["cansiton"]?.InnerText == "1") ||
                            (item["canstandon"]?.InnerText == "1") ||
                            (item["canlayon"]?.InnerText == "1");

                if (canGo)
                    _furnitureList.Add(new SPoisonFurni(int.Parse(id), name, false));
            }

            PoisonListCbbx.Items.AddRange(_furnitureList.ToArray());
            PoisonListCbbx.Enabled = true;
            PoisonListCbbx.ResetText();
        }
        #endregion
    }
}