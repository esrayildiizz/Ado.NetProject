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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 GO = new Form1();
            GO.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kayıt go = new Kayıt();
             go.Show();
            this.Hide();
        }
    }
}
