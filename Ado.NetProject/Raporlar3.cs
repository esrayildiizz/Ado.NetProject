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
    public partial class Raporlar3 : Form
    {
        public Raporlar3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Server=10.22.0.23;Database=M04;Integrated Security=true;");
        private void button7_Click(object sender, EventArgs e) //geri
        {
            Form1 GO = new Form1();
            GO.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e) //çıkış
        {
            Form2 GO = new Form2();
            GO.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //uzman sayısına göre sırala
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uzmansirala";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e) //yatak sayısına göre sırala
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "yataksirala";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
