using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AC_Trainer
{
    public partial class Form1 : Form
    {
        FormOverlay frm = new FormOverlay();
        public Form1()
        {
            InitializeComponent();
        }
        
        public static int Base = 0x509B74;
        public static int EntityList = 0x10F4F8;
        public static int Health = 0xf8;
        public static int AmmoR = 0x150;
        public static int AmmoP = 0x13C; 
        public int AmmoAddress = 0x04DF73C;
        public int AutoFireO = 0x218;
        public int AutoFireAddress = 0x04DF73C;
        public int PrimaryAmmo = 0x0FEA890;
        public int PistolAmmo = 0x0FEA87C;
        public int PlayerName = 0x225;
        public int RecoilP = 0x4EE444;
        public int ShootP = 0x224;
        public int Jump = 0x69;
        public int SpeedP = 0x80;
        public int MouseX = 0x40;
        public int MouseY = 0x44;
        public int PlayerY = 0xC;
        public int PlayerX = 0x4;
        public int PlayerZ = 0x8;
        public int ViewMatrix = 0x501AE8;
        public int POS_HEAD_X = 0x4;
        public int POS_HEAD_Z = 0x8;
        public int POS_HEAD_Y =  0xC;
        public int players = 0x10F500;
        public int team = 0x32C;






        VAMemory vam = new VAMemory("ac_client");

        
        
        public void DrawRectangle(PaintEventArgs e) 
        {
            


            Pen GreenPen = new Pen(Color.Green, 3);
            Rectangle rect = new Rectangle(0, 0, 200, 200);
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            VAMemory vam = new VAMemory("ac_client");



            int LocalPlayer = vam.ReadInt32((IntPtr)Base);

            int address = LocalPlayer + Health;

            vam.WriteInt32((IntPtr)address, 9999);

            

              
        }

        public void button5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                frm.Show();

            }
            else
            {
                frm.Hide();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            vam.WriteInt32((IntPtr)RecoilP, 999);
        }

        public void button6_Click(object sender, EventArgs e)
        {
            int LocalPlayer = vam.ReadInt32((IntPtr)Base);
            int AmmoAddressR = LocalPlayer + AmmoR;
            int AmmoAddressP = LocalPlayer + AmmoP;
            vam.WriteInt32((IntPtr)AmmoAddressR, 9999);
            vam.WriteInt32((IntPtr)AmmoAddressP, 9999);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            vam.ReadInt32((IntPtr)ViewMatrix);
        }
    }

}