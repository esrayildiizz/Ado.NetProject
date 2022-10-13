using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ado.NetProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Poliklinikler go = new Poliklinikler();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doktorlar go = new Doktorlar();
            go.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hastalar go = new Hastalar();
            go.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) //geri dön butonu
        {
            Kayıt GO = new Kayıt();
            GO.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e) //çıkış butonu
        {
            Form2 GO = new Form2();
            GO.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Raporlar go=new Raporlar();
            go.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Raporlar2 go=new Raporlar2();
            go.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Raporlar3 go =new Raporlar3();
            go.Show();
            this.Hide();
        }
    }
}
