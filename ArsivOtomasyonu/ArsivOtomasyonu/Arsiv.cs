﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ArsivOtomasyonu
{
    public partial class Arsiv : DevExpress.XtraEditors.XtraForm
    {
        public Arsiv()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr1 = new Form1();
            fr1.Show();
        }

        private void Arsiv_Load(object sender, EventArgs e)
        {

        }
    }
}