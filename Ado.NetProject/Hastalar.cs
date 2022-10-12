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
    public partial class Hastalar : Form
    {
        public Hastalar()
        {
            InitializeComponent();
        }

        private void Hastalar_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Server=10.22.0.23;Database=M04;Integrated Security=true;");

        public void Listele2() //metot listelemek için
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HListele";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e) //listele butonu
        {
            Listele2();
        }

        private void button2_Click(object sender, EventArgs e) //EKLE
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HEkle"; 
            cmd.Parameters.AddWithValue("HastaAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("HastaTcNo", textBox3.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", textBox4.Text);
            cmd.Parameters.AddWithValue("Boy", textBox5.Text);
            cmd.Parameters.AddWithValue("Yas", textBox6.Text);
            cmd.Parameters.AddWithValue("Recete", textBox7.Text);
            cmd.Parameters.AddWithValue("RaporDurumu", textBox8.Text);
            cmd.Parameters.AddWithValue("RandevuTarihi", textBox9.Text);
            cmd.Parameters.AddWithValue("DoktorNo", comboBox1.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele2();
        }

        private void button3_Click(object sender, EventArgs e) //GÜNCELLE
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HYenile";
            cmd.Parameters.AddWithValue("HastaNo", textBox1.Text);
            cmd.Parameters.AddWithValue("HastaAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("HastaTcNo", textBox3.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", textBox4.Text);
            cmd.Parameters.AddWithValue("Boy", textBox5.Text);
            cmd.Parameters.AddWithValue("Yas", textBox6.Text);
            cmd.Parameters.AddWithValue("Recete", textBox7.Text);
            cmd.Parameters.AddWithValue("RaporDurumu", textBox8.Text);
            cmd.Parameters.AddWithValue("RandevuTarihi", textBox9.Text);
            cmd.Parameters.AddWithValue("DoktorNo", comboBox1.SelectedItem);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele2();
        }

        private void button4_Click(object sender, EventArgs e) //ARA
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HAra";
            cmd.Parameters.AddWithValue("HastaNo", textBox10.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            Listele2();
        }

        private void button5_Click(object sender, EventArgs e) //SİL
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "HSil";
            cmd.Parameters.AddWithValue("HastaNo", textBox11.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele2();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //DATA GRİD
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.Rows[sec].Cells[9].Value.ToString();
        }
    }
}
