using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OSKRGB
{

    public partial class Main : Form
    {
        // Fields
        bool rgbState = true;
        bool capState = false;
        int r = 0, g = 0, b = 0;
        List<Button> buttonList;
        Random random = new Random();
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private const int WM_NCHITTEST = 0x84;

        // RGB
        private void timerRGB_Tick(object sender, EventArgs e)
        {
            var rgbMinThreshold = 1;
            var rgbMaxThreshold = 16;

            if (rgbState)
            {
                r += random.Next(rgbMinThreshold, rgbMaxThreshold);
                g += random.Next(rgbMinThreshold, rgbMaxThreshold);
                b += random.Next(rgbMinThreshold, rgbMaxThreshold);
            }
            else if (!rgbState)
            {
                r -= random.Next(rgbMinThreshold, rgbMaxThreshold);
                g -= random.Next(rgbMinThreshold, rgbMaxThreshold);
                b -= random.Next(rgbMinThreshold, rgbMaxThreshold);
            }

            if (r > 255 || g > 255 || b > 255)
            { r = 255; g = 255; b = 255; rgbState = false; }

            else if (r < 25 || g < 25 || b < 25)
            { r = 25; g = 25; b = 25; rgbState = true; }

            var currentColor = Color.FromArgb(255, r, g, b);

            foreach (var item in buttonList)
            { 
                item.ForeColor = currentColor;
                item.FlatStyle = FlatStyle.Flat;
                item.FlatAppearance.BorderSize = 1;
                item.FlatAppearance.BorderColor = currentColor; 
                item.TabStop = false;
            }
        }

        // Entry
        public Main()
        {
            InitializeComponent();
            labelCaps.Visible = false;
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            timerRGB.Enabled = true;
            timerRGB.Interval = 60;
            buttonList = Controls.OfType<Button>().ToList();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        // Buttons
        #region Keystrokes
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonESC_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ESC}");
        }

        private void buttonF1_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F1}");
        }

        private void buttonF2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F2}");
        }

        private void buttonF3_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F3}");
        }

        private void buttonF4_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void buttonF5_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F5}");
        }

        private void buttonF6_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F6}");
        }

        private void buttonF7_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F7}");
        }

        private void buttonF8_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F8}");
        }

        private void buttonF9_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F9}");
        }

        private void buttonF10_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F10}");
        }

        private void buttonF11_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F11}");
        }

        private void buttonF12_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{F12}");
        }

        private void buttonPRTSCR_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PRTSC}");
        }

        private void buttonSCRLK_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{SCROLLLOCK}");
        }

        private void buttonBREAK_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BREAK}");
        }

        private void buttonTilde_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{`}" : "{~}");
        }

        private void buttonNum1_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{1}" : "{!}");
        }

        private void buttonNum2_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{2}" : "{@}");
        }

        private void buttonNum3_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{3}" : "{#}");
        }

        private void buttonNum4_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{4}" : "{$}");
        }

        private void buttonNum5_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{5}" : "{%}");
        }

        private void buttonNum6_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{6}" : "{^}");
        }

        private void buttonNum7_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{7}" : "{&}");
        }

        private void buttonNum8_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{8}" : "{*}");
        }

        private void buttonNum9_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{9}" : "{(}");
        }

        private void buttonNum0_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{0}" : "{)}");
        }

        private void buttonNumMin_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{-}" : "{_}");
        }

        private void buttonNumPlus_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{=}" : "{+}");
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BACKSPACE}");
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{INSERT}");
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}");
        }

        private void buttonPageUp_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PGUP}");
        }

        private void buttonPageDown_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{PGDN}");
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{END}");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DELETE}");
        }

        private void buttonTab_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void buttonQ_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{q}" : "{Q}");
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{w}" : "{W}");
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{e}" : "{E}");
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{r}" : "{R}");
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{t}" : "{T}");
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{y}" : "{Y}");
        }

        private void buttonU_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{u}" : "{U}");
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{i}" : "{I}");
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{o}" : "{O}");
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{p}" : "{P}");
        }

        private void buttonLeftBrace_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{[}" : "{{}");
        }

        private void buttonRightBrace_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{]}" : "{}}");
        }

        private void buttonBackSlash_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? @"{\}" : @"{|}");
        }

        private void buttonCapsLock_Click(object sender, EventArgs e)
        {
            capState = !capState;
            if (capState.Equals(true))
                labelCaps.Visible = true;
            else
                labelCaps.Visible = false;
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{a}" : "{A}");
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{s}" : "{S}");
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{d}" : "{D}");
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{f}" : "{F}");
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{g}" : "{G}");
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{h}" : "{H}");
        }

        private void buttonJ_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{j}" : "{J}");

        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{k}" : "{K}");
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{l}" : "{L}");
        }

        private void buttonSemiColon_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? @"{;}" : @"{:}");
        }

        private void buttonQuote_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{\'}" : "{\"}");
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void buttonLShift_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("+");
        }

        private void buttonRShift_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("+");
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{z}" : "{Z}");
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{x}" : "{X}");
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{c}" : "{C}");
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{v}" : "{V}");
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{b}" : "{B}");
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{n}" : "{N}");
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? "{m}" : "{M}");
        }

        private void buttonGT_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? @"{,}" : @"{<}");
        }

        private void buttonLT_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? @"{.}" : @"{>}");
        }

        private void buttonForwardSlash_Click(object sender, EventArgs e)
        {
            SendKeys.Send(capState.Equals(false) ? @"{/}" : @"{?}");
        }

        private void buttonLCtrl_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^");
        }

        private void buttonWin_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^({ESC})");
        }

        private void buttonLAlt_Click(object sender, EventArgs e)
        {
            SendKeys.Send("%");
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
        }

        private void buttonRAlt_Click(object sender, EventArgs e)
        {
            SendKeys.Send("%");
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet! Coming Soon™.");
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            SendKeys.Send("+({F10})");
        }

        private void buttonRCtrl_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^");
        }

        private void buttonArrowUp_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{UP}");
        }

        private void buttonArrowRight_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{RIGHT}");
        }

        private void buttonArrowDown_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DOWN}");
        }

        private void buttonArrowLeft_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{LEFT}");
        }
        #endregion

        // Active window
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }

        // Movable window
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
    }
}
