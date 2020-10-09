using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNET3
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKullaniciEkle frmEkle = new frmKullaniciEkle();
            frmEkle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmKullaniciGuncelle frmGuncele = new frmKullaniciGuncelle();
            frmGuncele.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmKullaniciSil frmSil = new frmKullaniciSil();
            frmSil.Show();
        }
    }
}
