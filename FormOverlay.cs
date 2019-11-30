using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AC_Trainer
{
    public partial class FormOverlay : Form


    {

        public static int EntityList = 0x10F4F8;
        public int team = 0x32C;
        public int POS_HEAD_X = 0x4;
        public int POS_HEAD_Z = 0x8;
        public int POS_HEAD_Y = 0xC;
        public int health = 0xF8;
        public int ViewMatrix = 0x501AE8;

        public struct RECT 
        {

            public int left, top, right, bottom;
        
        }
        public int players = 0x10F500;

        Graphics g;
        Pen mypp = new Pen(Color.Red);
        Pen Bros = new Pen(Color.Blue);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName,string lpwindowname);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lprect);

        [DllImport("user32.dll")]

        public static extern int SetWindowLong(IntPtr hwnd, int nindex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hwnd, int nindex);

        RECT rect;
        public const string WINDOW_NAME = "AssaultCube";
        IntPtr handle = FindWindow(null,WINDOW_NAME);

        

        public FormOverlay()
        {
            InitializeComponent();
        }


        

        public void FormOverlay_Load(object sender, EventArgs e)
        {

            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;
            this.TopMost = true;
            // this.FormBorderStyle = FormBorderStyle.None

            int InitalStyle = GetWindowLong(this.Handle,-20);
            SetWindowLong(this.Handle, -20, InitalStyle | 0x00000 | 0x20);

            GetWindowRect(handle, out rect);
            this.Size = new Size(rect.right - rect.left,rect.bottom - rect.top);
            this.Top = rect.top;
            this.Left = rect.left;
            this.Location = new Point(rect.left + 10,rect.top + 10);


        }

        private void FormOverlay_Paint(object sender, PaintEventArgs e)
        {
            VAMemory vam = new VAMemory("ac_client");
            g = e.Graphics;

            for (int x = 0x4; x <= (0x4 * (players - 1)); x += 0x4) 
            {

                int enemybase = vam.ReadInt32((IntPtr)EntityList + x);
                int TEAM = vam.ReadInt32((IntPtr)enemybase + team);
                int enemyhealth = vam.ReadInt32((IntPtr)enemybase + health);

                int enemyPosX = vam.ReadInt32((IntPtr)enemybase + POS_HEAD_X);
                int enemyPosY = vam.ReadInt32((IntPtr)enemybase + POS_HEAD_Y);
                int enemyPosZ = vam.ReadInt32((IntPtr)enemybase + POS_HEAD_Z);

                g.DrawRectangle(mypp,enemyPosX,enemyPosY,enemyPosZ,enemyhealth);

            }
        }
    }
}
