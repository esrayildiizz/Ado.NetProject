using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ado.NetProject
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Server=10.22.0.23;Database=M04;Integrated Security=true;");

        private void Kayıt_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //kayıt ol
        {
            if (radioButton1.Checked)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e) //login butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LGiris";
            cmd.Parameters.AddWithValue("KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("Sifre", textBox2.Text);
         
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı....");
                Form1 GO = new Form1();//GİRİŞ YAPTIĞINDA FORM1 SAYFASINAA YÖNLENDİRİCEK.
                GO.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz hatalı.Lütfen tekrar deneyiniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
           
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e) //kayıt ol ekranı kaydet butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KKayıt"; //İLK ÖNCE LOGİN İÇİN PROSEDUR OLUŞTUR SQL DE.
            cmd.Parameters.AddWithValue("KullaniciAdi", textBox3.Text);
            cmd.Parameters.AddWithValue("Sifre", textBox4.Text);
            cmd.Parameters.AddWithValue("Email", textBox5.Text);
            cmd.Parameters.AddWithValue("Telefon", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            Form1 GO = new Form1();
            GO.Show();
            this.Hide();
        }
    }
}
