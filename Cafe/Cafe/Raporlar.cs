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
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=AHMET\\SQLKODLAB ; Database=CafeProject ;Integrated Security=true;");

        private void Raporlar_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select SatıcıAdı,ilçe,UrunNo from Satıcılar group by SatıcıAdı,ilçe,UrunNo order by ilçe asc", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select SatıcıAdı from Satıcılar where ilçe='Çankaya'", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select SatıcıAdı,Katogori,Fiyatı,StokDurumu,StokGüncellemeTarihi from Satıcılar st join Urunler urn on st.UrunNo=urn.UrunNo group by SatıcıAdı, Katogori,Fiyatı,StokDurumu,StokGüncellemeTarihi order by Katogori", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select * from Urunler where Adı='Pasta' and Fiyatı<20", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select * from Urunler where StokGüncellemeTarihi between  like '%"+dateTimePicker1+"%' and '%"+dateTimePicker2+"%'", con);
            DataTable dt = new DataTable(); // Kontrol et
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select * from Urunler where StokDurumu<50", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select AdıSoyadı,COUNT(sp.MusteriNo) as [Toplam Sipariş] from Siparis sp join Musteri ms on sp.MusteriNo=ms.MusteriNo group by AdıSoyadı order by AdıSoyadı asc", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select Adı, SUM(Fiyatı) as [Toplam Kazanç] from Siparis sp join Urunler urn on sp.UrunNo=urn.UrunNo group by Adı order by Adı asc", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select Adı, Count(sp.UrunNo) as [Toplam Kazanç] from Siparis sp join Urunler urn on sp.UrunNo=urn.UrunNo group by Adı order by Adı asc", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select * from Musteri order by AdıSoyadı asc", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            con.Open();
            SqlDataAdapter rapor = new SqlDataAdapter("select top 5 * from Musteri order by AdıSoyadı asc", con);
            DataTable dt = new DataTable();
            rapor.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;

        }
    }
}
