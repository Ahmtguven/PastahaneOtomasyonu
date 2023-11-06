using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Satıcılar : Form
    {
        public Satıcılar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("\"server=AHMET\\\\SQLKODLAB ; Database=CafeProject ;Integrated Security=true;\"");

        public void Listele(string listele)
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource= dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Listele("select * from Satıcılar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Ekle = new SqlCommand("insert into Satıcılar (SatıcıAdı,Katogori,İl,ilçe,Adres,UrunNo) values (@SatıcıAdı,@Katogori,@İl,@ilçe,@Adres,@UrunNo)", con);
            Ekle.Parameters.AddWithValue("@SatıcıAdı", textBox1.Text);
            Ekle.Parameters.AddWithValue("@Katogori", textBox2.Text);
            Ekle.Parameters.AddWithValue("@İl", textBox3.Text);
            Ekle.Parameters.AddWithValue("@ilçe", textBox4.Text);
            Ekle.Parameters.AddWithValue("@Adres", richTextBox1.Text);
            Ekle.Parameters.AddWithValue("@UrunNo", Convert.ToInt32(comboBox2.Text));
            con.Close();
            Listele("select * from Satıcılar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Düzenle = new SqlCommand("update Satıcılar set SatıcıAdı=@SatıcıAdı,Katogori=@Katogori,İl=@İl,ilçe=@ilçe,Adres=@Adres,UrunNo=@UrunNo where SatıcıNo=@SatıcıNo", con);
            Düzenle.Parameters.AddWithValue("SatıcıNo", Convert.ToInt32(comboBox1.Text));
            Düzenle.Parameters.AddWithValue("@SatıcıAdı", textBox1.Text);
            Düzenle.Parameters.AddWithValue("@Katogori", textBox2.Text);
            Düzenle.Parameters.AddWithValue("@İl", textBox3.Text);
            Düzenle.Parameters.AddWithValue("@ilçe", textBox4.Text);
            Düzenle.Parameters.AddWithValue("@Adres", richTextBox1.Text);
            Düzenle.Parameters.AddWithValue("@UrunNo", Convert.ToInt32(comboBox2.Text));
            con.Close();
            Listele("select * from Satıcılar");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sil = new SqlCommand("delete satıcılar where SatıcıNo=@SatıcıNo",con);
            sil.Parameters.AddWithValue("@SatıcıNo", Convert.ToInt32(comboBox1.Text));
            con.Close();
            Listele("select * from Satıcılar");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1(); go.Show(); this.Hide();
        }
    }
}
