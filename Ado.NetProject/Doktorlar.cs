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
    public partial class Doktorlar : Form
    {
        public Doktorlar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=10.22.0.23;Database=M04;Integrated Security=true;");

        public void Listele3() //metot listelemek için
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DListele";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button6_Click(object sender, EventArgs e) //listele butonu
        {
            Listele3();
        }

        private void button3_Click(object sender, EventArgs e) //EKLE BUTONU
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DEkle";
            cmd.Parameters.AddWithValue("DoktorAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("DoktorTcNo", textBox3.Text);
            cmd.Parameters.AddWithValue("UzmanlikAlani", textBox4.Text);
            cmd.Parameters.AddWithValue("Unvani", textBox5.Text);
            cmd.Parameters.AddWithValue("Telefon", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("Adres", textBox6.Text);
            cmd.Parameters.AddWithValue("DogumTarihi ", textBox7.Text);
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox8.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele3();
        }

        private void button4_Click(object sender, EventArgs e) //GÜNCELLE
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DYenile";
            cmd.Parameters.AddWithValue("DoktorNo", textBox1.Text);
            cmd.Parameters.AddWithValue("DoktorAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("DoktorTcNo", textBox3.Text);
            cmd.Parameters.AddWithValue("UzmanlikAlani", textBox4.Text);
            cmd.Parameters.AddWithValue("Unvani", textBox5.Text);
            cmd.Parameters.AddWithValue("Telefon", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("Adres", textBox6.Text);
            cmd.Parameters.AddWithValue("DogumTarihi ", textBox7.Text);
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox8.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele3();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //data grid ekranı
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
            
             
        }

        private void button2_Click(object sender, EventArgs e) //ara butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DAra";
            cmd.Parameters.AddWithValue("DoktorNo", textBox9.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            Listele3();
        }

        private void button5_Click(object sender, EventArgs e) //sil butonu
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DSil";
            cmd.Parameters.AddWithValue("HastaNo", textBox10.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele3();
        }

        private void Doktorlar_Load(object sender, EventArgs e) //poliklinik no kendiğinden otomatik gelsin
        {
            //poliklinik no combobox olarak değiştirilip yapılablir. Textbox olduğu için her yerde duzenlenmesi gerekir.
            //ornek olarak hastalarda var.
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
