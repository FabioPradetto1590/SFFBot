using SFFBot.Classes;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Transitions;

namespace SFFBot.Dialogs
{
    public partial class AboutFrm : Form
    {
        private List<Control> _rightControls;

        public AboutFrm()
        {
            InitializeComponent();
            _rightControls = new List<Control>{ TitleTxt, SFFVersionTxt,
                Sep1, SFFDescriptionTxt, Sep2, ThanksTxt };
        }

        private void AboutFrm_Load(object sender, System.EventArgs e)
        {
            SFFLogo.Location = new Point(-123, SFFLogo.Location.Y);
            SFFVersionTxt.Text = $"v{Program.Version} | 2016";

            _rightControls.ForEach(c => c.Location = new Point(c.Location.X + 170, c.Location.Y));

            var t = new Transition(new TransitionType_Linear(1000));
            _rightControls.ForEach(c => t.add(c, "Left", c.Location.X - 170));
            t.run();

            SFFLogo.RunTransition(1000, "Left", -4);
        }
    }
}
