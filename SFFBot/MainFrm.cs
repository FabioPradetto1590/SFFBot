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
using System.IO;
using Sulakore.Habbo.Headers;
using System.Text;

namespace SFFBot
{
    public partial class MainFrm : Form
    {
        //public override bool IsRemoteModule { get; } = true;

        private List<SFurni> _placedFurnitures = new List<SFurni>();
        private List<SStatus> _currStatuses = new List<SStatus>();
        private List<SFurni> _furnitureList = new List<SFurni>();
        private List<ToolStripMenuItem> _delayCheckeds;
        private List<Control> _bottomControls;
        private HotkeyManager _htkManager;
        private SFurni _selFurni;
        private SplashFrm _main;
        private int _delay, _ourIndex = -1;

        private bool _autoStopEnabled, _isSelectingTile,
            _canGo, _isPoisonRunning, _isRunning, _isHtkNoticeShowed;

        private HPoint _selectedTile, _ourLocation = null;
        
        public readonly Dictionary<Action, Keys> Hotkeys = new Dictionary<Action, Keys>();
        public KeyboardHook HotkeyHook { get; set; }
        public int CustomDelay = 0;

        public MainFrm(SplashFrm main)
        {
            InitializeComponent();
            _main = main;

            #region Control Lists
            _delayCheckeds = new List<ToolStripMenuItem>{
                SB100Ckbx, SB200Ckbx, SB400Ckbx, SB600Ckbx, SB800Ckbx,
                SB1000Ckbx, SBCustomDelay };

            _bottomControls = new List<Control>{
                VersionTxt, Sep, GithubLnk };
            #endregion

            _main.Triggers.InAttach(Incoming.Global.HeightMap, HandleNewRoom);
            _main.Triggers.InAttach(Incoming.Global.UserUpdate, HandlePlayerWalk);
            _main.Triggers.InAttach(Incoming.Global.ObjectRemove, HandlePickUp);

            _htkManager = new HotkeyManager(this);
            _htkManager.Init();
        }

        public void HotkeyActivated(object sender, KeyEventArgs e)
        {
            if (Hotkeys.ContainsValue(e.KeyData))
                Hotkeys.FirstOrDefault(s => s.Value == e.KeyData).Key();
        }

        #region Bot functions

        private void HandlePlayerWalk(DataInterceptedEventArgs e)
        {
            var walks = HEntityAction.Parse(e.Packet);

            foreach (var walk in walks)
            {
                if (!_autoStopEnabled) return;

                if (walk.Index != _ourIndex && _placedFurnitures.Count > 0)
                {
                    Predicate<SFurni> p = a => a.Location.IsSame(walk.MovingTo);

                    if (walk.MovingTo.IsSame(_selFurni.Location))
                    {
                        _placedFurnitures.RemoveAll(a => a.Location.IsSame(_selFurni.Location));
                        _selFurni = null;
                        
                        ShowNotificationAsync(1, "Another Habbo got in our selected furniture!\rWaiting for new..");
                    }
                    else if(_placedFurnitures.Exists(p))
                        _placedFurnitures.Remove(_placedFurnitures.Find(p));
                }

                if (walk.MovingTo != null)
                    _ourLocation = walk.MovingTo;

                if (_placedFurnitures.Count < 1)
                    return;

                if (_ourLocation.IsSame(_selFurni.Location))
                {
                    _selFurni = null;
                    ShowNotificationAsync(1, "We reached our furni!");

                    _placedFurnitures.Clear();
                    ToggleBotState(false);
                }
            }
        }

        private async void HandleFurnitureAsync(DataInterceptedEventArgs e)
        {
            SFurni furni = new SFurni(e.Packet.ReadInteger(), e.Packet.ReadInteger(),
                new HPoint(e.Packet.ReadInteger(), e.Packet.ReadInteger()), false);

            CheckTool(furni.TypeId);

            if (!_canGo)
                return;

            if (UseSelectedTileCkbx.Checked)
            {
                if (!_selectedTile.IsSame(furni.Location))
                    return;
                else
                    ShowNotificationAsync(1, "Furniture placed to selected Tile!");
            }

            if (_selFurni == null && _autoStopEnabled)
            {
                _selFurni = furni;
                ShowNotificationAsync(1, $"Selected: {furni.UniqueId}");
            }

            HandleFurni(furni);

            if (_autoStopEnabled && (_selFurni.UniqueId != furni.UniqueId && _selFurni != null) || !_isRunning)
                return;

            if(_delayCheckeds.Exists(a => a.Checked))
                await Task.Delay(_delay);

            await _main.Connection.SendToServerAsync(Outgoing.Global.MoveAvatar, furni.Location.X, furni.Location.Y);
        }
        private void HandleTileSelecting(DataInterceptedEventArgs e)
        {
            if (!_isSelectingTile) return;

            int X = e.Packet.ReadInteger(),
                Y = e.Packet.ReadInteger();

            _selectedTile = new HPoint(X, Y);

            ShowNotificationAsync(1, $"Tile selected!\rX: {X} Y: {Y}");

            e.IsBlocked = true;
            _isSelectingTile = false;

            Invoke(new MethodInvoker(() =>
            {
                SelectTileBtn.Text = "Select Tile";
                UseSelectedTileCkbx.Enabled = true;
            }));
        }

        private void HandleNewRoom(DataInterceptedEventArgs e)
        {
            _ourIndex = -1;
            _placedFurnitures.Clear();

            if (_autoStopEnabled)
                GetOurIndexAsync();
        }

        private async void GetOurIndexAsync()
        {
            _main.Triggers.InAttach(Incoming.Global.Whisper, HandleWhisper);
            
            await _main.Connection.SendToServerAsync(Outgoing.Global.Whisper, " ‹‹ SFFBot - Getting user index.. ››", 0);
        }

        private async void HandleWhisper(DataInterceptedEventArgs e)
        {
            await Task.Delay(500);
            _ourIndex = e.Packet.ReadInteger();
            _main.Triggers.InDetach(Incoming.Global.Whisper);

            await _main.Connection.SendToServerAsync(Outgoing.Global.Whisper, " ‹‹ SFFBot - Done! ››", 0);
        }

        private void HandlePickUp(DataInterceptedEventArgs e)
        {
            _placedFurnitures.RemoveAll(a => a.UniqueId == int.Parse(e.Packet.ReadString()));
        }

        public async void ShowNotificationAsync(int Type, string message)
        {
            switch (Type)
            {
                case 1:
                    await _main.Connection.SendToClientAsync(Incoming.Global.RoomNotification, "furni_placement_error", 1, "message", message);
                    break;
                case 2:
                    Invoke(new MethodInvoker(() => { StatusBtn.Text = message; }));
                    break;
            }
        }
        #endregion

        #region Form Actions
        private async void SBMain_Load(object sender, EventArgs e)
        {
            Task loadFurniTask = LoadFurniDataAsync();

            Text = $"SFFBot - v{Program.Version}";
            VersionTxt.Text = $"v{Program.Version}";

            StartGrp.Location = new Point(-252, 79);
            PoisonGrp.Location = new Point(11, -23);

            AlwaysOnTopCkbx.Checked = TopMost = Default.TopMost;
            ShowHeaders();

            STransition.Run(1200, new TArgument(PoisonGrp, "Top", 27),
                                  new TArgument(StartGrp, "Left", 11));

            ShowNotificationAsync(new SStatus(0, 1250, 3000,
               $"Welcome to SFFBot v{Program.Version}! ", SystemColors.ControlText));

            await loadFurniTask;
        }
        private void SBMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Default.TopMost = AlwaysOnTopCkbx.Checked;
            Default.Save();
            _main.Close();
        }

        private void SelectTileBtn_Click(object sender, EventArgs e)
        {
            if (_isSelectingTile)
            {
                _isSelectingTile = false;
                SelectTileBtn.Text = "Select Tile";
                ShowNotificationAsync(1, "Tile selecting cancelled!");

                _main.Triggers.OutDetach(Outgoing.Global.MoveAvatar);
            }
            else
            {
                _isSelectingTile = true;
                SelectTileBtn.Text = "Cancel Tile Selecting";
                ShowNotificationAsync(1, "Select a tile!");

                _main.Triggers.OutAttach(Outgoing.Global.MoveAvatar, HandleTileSelecting);
            }
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
            _isPoisonRunning = !_isPoisonRunning;
        }
        private void OpenSettingsBtn_Click(object sender, EventArgs e)
        {
            var frm = new SettingsFrm();
            frm.Show();
        }
        private void CustomDelayOpenDlg_Click(object sender, EventArgs e)
        {
            var frm = new SelectDelayFrm(this);
            frm.Show();
        }
        private void OpenHotkeysBtn_Click(object sender, EventArgs e)
        {
            if(!_isHtkNoticeShowed)
                MessageBox.Show("It is recommended to set hotkeys to keys that you're not using or there may come problems!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            _isHtkNoticeShowed = true;

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
                ShowNotificationAsync(new SStatus(2, 3000, 2500,
                        "You need to select furni to from list first to poison it!", Color.DarkRed));
                return;
            }

            var poisonFurni = _furnitureList.First(p => p.TypeId == selTxt.ToPoisonFurni().TypeId);

            if (poisonFurni == null) return;

            if (!poisonFurni.IsPoisoned)
            {
                ShowNotificationAsync(new SStatus(2, 3000, 2000, $"Furniture \"{poisonFurni.Name}\" is poisoned!", Color.MediumVioletRed));
                poisonFurni.IsPoisoned = true;
                PoisonListCbbx.ResetText();
            }
            else
                ShowNotificationAsync(new SStatus(2, 4000, 3000, "Sorry you already have poisoned this furniture..", Color.DarkRed));

            PoisonGrp.Text = $"Poison List ({_furnitureList.FindAll(s => s.IsPoisoned).Count})";
        }
        private void ReportMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clyde waz here.", "Info - Nothing here yet.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void AutoStopCkbx_Click(object sender, EventArgs e)
        {
            AutoStopCkbx.Checked = !AutoStopCkbx.Checked;
            _autoStopEnabled = !_autoStopEnabled;

            if (_autoStopEnabled)
                HandleNewRoom(null);
        }

        List<string> list;
        private void PoisonListCbbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selTxt = PoisonListCbbx.Text;
            int i;

            if (string.IsNullOrWhiteSpace(selTxt))
            {
                if (e.KeyChar == (char)Keys.Enter)
                    PoisonListCbbx.DataSource = _furnitureList.Cast<SFurni>().Select(s => s.ToString()).ToList();
                return;
            }

            List<string> furnitures = _furnitureList.Cast<SFurni>().Select(s => s.ToString()).ToList();

            if (char.IsNumber(selTxt[0]) && int.TryParse(selTxt, out i))
                list = furnitures.Where(s => s.ToPoisonFurni().TypeId == i).ToList();

            if (char.IsLetter(selTxt[0]))
                list = furnitures.Where(s => s.ToPoisonFurni().Name.Contains(selTxt)).ToList();

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
            _delayCheckeds.ForEach(a => a.Checked = false);

            if (!item.Checked)
            {
                item.Checked = true;
                ShowNotificationAsync(1, $"Delay time set to {delay}ms");
            }
            _delay = delay;
        }

        private void SB100Ckbx_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SB100Ckbx, 100);
        }
        private void SB200Ckbx_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SB200Ckbx, 200);
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
        private void SBCustomDelay_Click(object sender, EventArgs e)
        {
            SelectDelayTime(SBCustomDelay, CustomDelay);
        }
        #endregion

        #region Functions
        public void ToggleBotState()
        {
            ToggleBotState(_isRunning ? false : true);
        }

        public void ToggleBotState(bool toRunning, bool showNotif = true)
        {
            Invoke((MethodInvoker)delegate
            {
                if (toRunning)
                {
                    _isRunning = true;
                    StartBtn.Text = "Stop";
                    StartGrp.Text = "Start Options (Running)";
                    if(showNotif)
                        ShowNotificationAsync(1, "SFFBot is running!");

                    _main.Triggers.InAttach(Incoming.Global.ObjectAdd, HandleFurnitureAsync);
                    _main.Triggers.InAttach(Incoming.Global.ObjectUpdate, HandleFurnitureAsync);
                }
                else
                {
                    _isRunning = false;
                    StartBtn.Text = "Start";
                    StartGrp.Text = "Start Options (Stopped)";
                    if (showNotif)
                        ShowNotificationAsync(1, "SFFBot is stopped!");

                    _main.Triggers.InDetach(Incoming.Global.ObjectAdd);
                    _main.Triggers.InDetach(Incoming.Global.ObjectUpdate);
                }
            });
        }
        public void TogglePoisonState()
        {
            _isPoisonRunning = SBPoisonCkbx.Checked = (_isPoisonRunning ? false : true);
        }
        public void SetCustomDelay(int delay)
        {
            SBCustomDelay.Visible = (delay == 0 ? false : true);

            SBCustomDelay.Text = $"{delay} (ms)";
            CustomDelay = delay;
        }

        public void ShowNotificationAsync(SStatus status)
        {
            Transition t1 = new Transition(new TransitionType_Linear(750));
            t1.add(MessageTxt, "Top", 141);

            if (_currStatuses.Any(a => a.IsShowed))
            {
                _currStatuses.FindAll(a => a.IsShowed).ForEach(statuz =>
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

        private void ShowHeaders()
        {
            WalkTxt.Text = Outgoing.Global.MoveAvatar.ToString();
            Walk2Txt.Text = Incoming.Global.UserUpdate.ToString();
            DropTxt.Text = Incoming.Global.ObjectAdd.ToString();
            MoveTxt.Text = Incoming.Global.ObjectUpdate.ToString();
        }
        private void HandleFurni(SFurni furni)
        {
            bool exists = _placedFurnitures.Exists(a => a.UniqueId == furni.UniqueId);

            if (exists) _placedFurnitures.First(a => a.UniqueId == furni.UniqueId).Location = furni.Location;
            else
                _placedFurnitures.Add(furni);    
        }
        private void CheckTool(int id)
        {
            bool canadd = true;

            if (SBPoisonCkbx.Checked)
                canadd = !_furnitureList.Any(s => s.TypeId == id && s.IsPoisoned);

            ShowNotificationAsync(2, $"{id}: {(canadd ? "Clean!" : "Poisoned")}");

            _canGo = canadd;
        }

        private async Task LoadFurniDataAsync()
        {
            var furni = new XmlDocument();
            using (var wc = new WebClient())
            {
                wc.Headers.Add("User-Agent", SKore.ChromeAgent);
                wc.Encoding = Encoding.UTF8;
                furni.LoadXml(await wc.DownloadStringTaskAsync(new Uri($"{_main.Hotel.ToUrl(true)}/gamedata/furnidata_xml/1")));
            }

            var itemNodes = furni.GetElementsByTagName("furnitype");

            foreach (XmlNode item in itemNodes)
            {
                var id = item.Attributes["id"]?.InnerText;
                var name = item["name"]?.InnerText;
                var canGo = (item["cansiton"]?.InnerText == "1") ||
                            (item["canstandon"]?.InnerText == "1") ||
                            (item["canlayon"]?.InnerText == "1");
                if (canGo)
                    _furnitureList.Add(new SFurni(int.Parse(id), name, false));
            }
            PoisonListCbbx.Items.AddRange(_furnitureList?.ToArray());
            PoisonListCbbx.Enabled = true;
            PoisonListCbbx.ResetText();
        }
        #endregion
    }
}