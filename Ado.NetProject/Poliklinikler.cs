using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ado.NetProject
{
    public partial class Poliklinikler : Form
    {
        public Poliklinikler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=10.22.0.23;Database=M04;Integrated Security=true;");

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e) // poliklinik için ekle butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PEkle"; //İLK ÖNCE LOGİN İÇİN PROSEDUR OLUŞTUR SQL DE.
            cmd.Parameters.AddWithValue("PoliklinikAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("PoliklinikUzmanSayisi", textBox3.Text);
            cmd.Parameters.AddWithValue("PoliklinikBaskani", textBox4.Text);
            cmd.Parameters.AddWithValue("PoliklinikBasHemsire", textBox5.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
        }

        public void Listele() //metot listelemek için
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PListele";
            SqlDataAdapter da =new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;  
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //poliklinik data grid ekranı. 
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();

        } 

        private void button3_Click(object sender, EventArgs e) //poliklinik güncelle botonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PYenile"; 
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox1.Text);
            cmd.Parameters.AddWithValue("PoliklinikAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("PoliklinikUzmanSayisi", textBox3.Text);
            cmd.Parameters.AddWithValue("PoliklinikBaskani", textBox4.Text);
            cmd.Parameters.AddWithValue("PoliklinikBasHemsire", textBox5.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e) //sil butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PSil";
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox8.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();

        }

        private void button4_Click(object sender, EventArgs e) //arama butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PAra";
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox9.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
        }

        private void button6_Click(object sender, EventArgs e) //listele butonu
        {
            Listele();
        }

        private void button7_Click(object sender, EventArgs e) //geri butonu
        {
            Form1 GO = new Form1();
            GO.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e) //çıkış butonu
        {
            Form2 GO = new Form2();
            GO.Show();
            this.Hide();
        }
    }
}
