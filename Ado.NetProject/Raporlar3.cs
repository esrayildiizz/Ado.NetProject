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
    public partial class Raporlar3 : Form
    {
        public Raporlar3()
        {
            InitializeComponent();
        }

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
    }
}
