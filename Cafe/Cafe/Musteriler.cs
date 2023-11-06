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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=CafeProject ;Integrated Security=true;");

        public void Liste(string code)
        {
            
            SqlDataAdapter da = new SqlDataAdapter(code,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Musteriler_Load(object sender, EventArgs e)
        {
            Liste("select * from Musteri");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Liste("select * from Musteri");   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand listele = new SqlCommand("Select * From Musteri where AdıSoyadı like '%" + textBox2.Text + "%'");
            //listele.ExecuteNonQuery();
            //con.Close();
            //Liste("select  from Musteri");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into Musteri (AdıSoyAdı,Telefon) values(@AdıSoyadı,@Telefon)", con);
            ekle.Parameters.AddWithValue("@AdıSoyadı", textBox2.Text);
            ekle.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
            ekle.ExecuteNonQuery();
            con.Close();
            Liste("Select * From Musteri");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand duzenle = new SqlCommand("Update Musteri set AdıSoyadı=@AdıSoyadı,Telefon=@Telefon where MusteriNo=@MusteriNo", con);

            duzenle.Parameters.AddWithValue("@MusteriNo", Convert.ToInt32(textBox1.Text));
            duzenle.Parameters.AddWithValue("@AdıSoyadı", textBox2.Text);
            duzenle.Parameters.AddWithValue("@Telefon", maskedTextBox1.Text);
            duzenle.ExecuteNonQuery();
            con.Close();
            Liste("select * from Musteri");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sil = new SqlCommand("Delete From Musteri where MusteriNo=@MusteriNo",con);
            sil.Parameters.AddWithValue("@MusteriNo", Convert.ToInt32(textBox1.Text));
            sil.ExecuteNonQuery();
            con.Close();
            Liste("Select * From Musteri");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1(); go.Show(); this.Hide();
        }
    }
}
