﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNET3
{
    public partial class frmKullaniciGuncelle : Form
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString);

        public frmKullaniciGuncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(textBox6.Text);
            var ad = textBox1.Text;
            var soyad = textBox2.Text;
            var kullaniciAd = textBox3.Text;
            var email = textBox4.Text;
            var sifre = textBox5.Text;

            KullaniciGuncelle(
                    kulId: Id,
                    ad: ad,
                    soyad: soyad,
                    kullaniciAd: kullaniciAd,
                    email: email,
                    sifre: sifre
                );
        }

        void KullaniciGuncelle(int kulId, string ad, string soyad, string kullaniciAd, string email, string sifre)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("pr_KullaniciGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Ad", ad),
                    new SqlParameter("@Soyad", soyad),
                    new SqlParameter("@KullaniciAd", kullaniciAd),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Sifre", sifre),
                    new SqlParameter("@KullaniciId", kulId)
                };

                cmd.Parameters.AddRange(parameters);
                cmd.Connection.Open();

                String mesaj = string.Empty;
                int etkilenenKayitSayisi = cmd.ExecuteNonQuery();

                if (etkilenenKayitSayisi > 0)
                {
                    mesaj = "İşlem başarılı" + etkilenenKayitSayisi;
                }
                else
                {
                    mesaj = "İşlem başarısız" + etkilenenKayitSayisi;
                }
                MessageBox.Show(mesaj);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
