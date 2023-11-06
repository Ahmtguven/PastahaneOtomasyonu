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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=CafeProject ;Integrated Security=true;");
        public void Liste(string liste)
        {
            SqlDataAdapter adp = new SqlDataAdapter(liste, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Liste("select * from Urunler");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ekle = new SqlCommand ("insert into Urunler (Adı,Fiyatı,StokDurumu,StokGüncellemeTarihi) values (@Adı,@Fiyatı,@StokDurumu,@StokGüncellemeTarihi",con);

            ekle.Parameters.AddWithValue("@Adı", textBox2.Text);
            ekle.Parameters.AddWithValue("@Fiyatı", Convert.ToInt32(textBox3.Text));
            ekle.Parameters.AddWithValue("@StokDurumu", Convert.ToInt32(textBox4.Text));
            ekle.Parameters.AddWithValue("@StokGüncellenmeTarihi", dateTimePicker1.Text);
            con.Open();
            Liste("select * from Urunler");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sil = new SqlCommand("delete from Urunler where UrunNo=@UrunNo", con);
            sil.Parameters.AddWithValue("UrunNo", Convert.ToInt32(textBox1.Text));
            con.Close();
            Liste("select * from Urunler");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand Düzenle = new SqlCommand("Update Urunler set Adı=@Adı,Fiyat=@Fiyat,StokDurumu=@StokDurumu,StokGüncellemeTarihi=@StokGüncellemeTarihi where UrunNo=@UrunNo", con);
            Düzenle.Parameters.AddWithValue("@UrunNo", Convert.ToInt32(textBox1.Text));
            Düzenle.Parameters.AddWithValue("@Adı", textBox2.Text);
            Düzenle.Parameters.AddWithValue("@Fiyatı", Convert.ToInt32(textBox3.Text));
            Düzenle.Parameters.AddWithValue("@StokDurumu",Convert.ToInt32(textBox4.Text));
            Düzenle.Parameters.AddWithValue("@StokGüncellemeTarihi", dateTimePicker1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Liste("select * from Urunler");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 go = new Form1(); go.Show(); this.Hide();            
        }
    }
}
