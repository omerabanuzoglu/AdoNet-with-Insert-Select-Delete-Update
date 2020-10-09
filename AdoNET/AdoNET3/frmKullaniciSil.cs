using System;
using System.CodeDom;
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
    public partial class frmKullaniciSil : Form
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString);

        public frmKullaniciSil()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = KullanicilariGetir();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int kulId = Convert.ToInt32(textBox1.Text);
            KullaniciSil(kulId);

            dataGridView1.DataSource = KullanicilariGetir();
        }


        void KullaniciSil(int kullaniciId)
        {
            if (kullaniciId > 0)
            {
                try
                {
                    using (conn)
                    {
                        SqlCommand cmd = new SqlCommand("pr_KullaniciSil", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "KullaniciId";
                        param.SqlDbType = SqlDbType.Int;
                        param.SqlValue = kullaniciId;

                        cmd.Parameters.Add(param);
                        cmd.Connection.Open();
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            MessageBox.Show("Başarıyla Silindi.");
                        }
                        else
                        {
                            MessageBox.Show("Bir Sorun Oluştu.");
                        }
                    }

                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Geçerli Bir Değer Giriniz.");
            }
        }




        List<Kullanici> KullanicilariGetir()
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "pr_KullanicilariGetir";

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    var user = new Kullanici(
                            kulId: dr.GetInt32(0),
                            ad: dr.GetString(1),
                            soyad: dr.GetString(2),
                            kullaniciAd: dr.GetString(3),
                            email: dr.GetString(4),
                            sifre: dr.GetString(5)
                        );
                    kullanicilar.Add(user);
                }
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
            return kullanicilar;
        }
    }
}
