﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AC_Trainer
{
    public partial class FormOverlay : Form
    {
        public FormOverlay()
        {
            InitializeComponent();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;

            
        }
    }
}