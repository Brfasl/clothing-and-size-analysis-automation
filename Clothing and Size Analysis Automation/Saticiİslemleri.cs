using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_And_Register_Page
{
    public partial class Saticiİslemleri : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berfin\\source\\repos\\Login And Register Page\\Clothing and Size Analysis Automation\\Database1.mdf;Integrated Security=True");
        public Saticiİslemleri()
        {
            InitializeComponent();
        }

        private void ekleButton_Click(object sender, EventArgs e)
        {
            Ekle();

        }
        public void Ekle()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into urun (UrunAdi,Beden,Gogus,Bel,Basen,Adet,Fiyat,Aciklama)" + "values (@urunAdi,@beden,@gogus,@bel,@basen,@adet,@fiyat,@aciklama)",con);
            cmd.Parameters.AddWithValue("@urunAdi", urunAdi1.Text);
            cmd.Parameters.AddWithValue("@beden", beden1.SelectedItem);
            cmd.Parameters.AddWithValue("@gogus", gogus1.Text);
            cmd.Parameters.AddWithValue("@bel", bel1.Text);
            cmd.Parameters.AddWithValue("@basen", basen1.Text);
            cmd.Parameters.AddWithValue("@adet", adet1.Text);
            cmd.Parameters.AddWithValue("@fiyat", fiyat1.Text);
            cmd.Parameters.AddWithValue("@aciklama", aciklama1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // OpenFileDialog nesnesi oluşturuyoruz
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Kullanıcıya sadece resim dosyalarını gösteriyoruz
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            // Kullanıcı dosya seçerse işlemi başlatıyoruz
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi PictureBox'ta gösteriyoruz
                resim1.Image = Image.FromFile(openFileDialog.FileName);

                
            }
        }

        private void Saticiİslemleri_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            string komut = "select * from urun ";
            SqlDataAdapter db = new SqlDataAdapter(komut, con);
            DataSet ds = new DataSet();
            db.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void güncellemeButton_Click(object sender, EventArgs e)
        {

        }

        private void silButton_Click(object sender, EventArgs e)
        {
            Sil();

        }
        public void Sil()
        {
            con.Open();
            string id = gridView1.GetFocusedRowCellValue("Id").ToString();
            SqlCommand cmd = new SqlCommand("delete from urun where Id='" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
        }
    }
}
