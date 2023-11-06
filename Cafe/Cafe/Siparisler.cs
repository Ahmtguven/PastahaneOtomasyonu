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
    public partial class Siparisler : Form
    {
        public Siparisler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=CafeProject ;Integrated Security=true;");

        public void Listele(string listele)
        {
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ekle = new SqlCommand("insert into Siparisler (MusteriNo,UrunNo,SiparisTarihi) values (@MusteriNo,@UrunNo,@SiparisTarihi)", con);
            ekle.Parameters.AddWithValue("@MusteriNo", Convert.ToInt32(textBox2));
            ekle.Parameters.AddWithValue("@UrunNo", Convert.ToInt32(textBox3));
            ekle.Parameters.AddWithValue("@SiparisTarihi", dateTimePicker1.Text);
            con.Close();
            Listele("select * from Siparisler"); // Kontrol  et
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sil = new SqlCommand("delete from Siparisler where SiparisNo=@SiparisNo",con);
            sil.Parameters.AddWithValue("@SiparisNo", Convert.ToInt32(textBox1));
            con.Close();
            Listele("select * from Siparisler");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Düzenle = new SqlCommand("Update Sipqrisler set MusteriNo=@MusteriNo,UrunNo=@UrunNo,SiparisTarihi=@SiparisTarihi where SiparisNo=qSiparisNo", con);
            Düzenle.Parameters.AddWithValue("@SiparisNo", Convert.ToInt32(textBox1));
            Düzenle.Parameters.AddWithValue("@MusteriNo", Convert.ToInt32(textBox2));
            Düzenle.Parameters.AddWithValue("@UrunNo",Convert.ToInt32(textBox3));
            Düzenle.Parameters.AddWithValue("@SiparisTarihi", dateTimePicker1.Text);
            con.Close();
            Listele("select * from Siparisler");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listele("Select * from Siparisler");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1(); go.Show(); this.Hide();
        }
    }
}
