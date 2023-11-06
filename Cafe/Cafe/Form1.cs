using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
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

        private void label1_Click(object sender, EventArgs e)
        {
            Musteriler go = new Musteriler();
            go.Show();
            this.Hide();
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
            Urunler go = new Urunler();
            go.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Siparisler go = new Siparisler();
            go.Show(); this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Satıcılar go = new Satıcılar();
            go.Show(); this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Raporlar go = new Raporlar();
            go.Show(); this.Hide();
        }


    }
}
