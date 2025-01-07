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
using System.IO; // MemoryStream için gerekli

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
            if (resim1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    resim1.Image.Save(ms, resim1.Image.RawFormat); // Resmi MemoryStream'e kaydet
                    byte[] imageBytes = ms.ToArray(); // Binary formatına çevir

                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO urun (UrunAdi, Beden, Kategori, Cinsiyet, Gogus, Bel, Basen, Adet, Fiyat, Aciklama, Resim)" +
                                                    "VALUES (@urunAdi, @beden, @kategori, @cinsiyet, @gogus, @bel, @basen, @adet, @fiyat, @aciklama, @resim)", con);
                    cmd.Parameters.AddWithValue("@urunAdi", urunAdi1.Text);
                    cmd.Parameters.AddWithValue("@beden", beden1.SelectedItem);
                    cmd.Parameters.AddWithValue("@kategori", beden1.SelectedItem);
                    cmd.Parameters.AddWithValue("@cinsiyet", beden1.SelectedItem);
                    cmd.Parameters.AddWithValue("@gogus", gogus1.Text);
                    cmd.Parameters.AddWithValue("@bel", bel1.Text);
                    cmd.Parameters.AddWithValue("@basen", basen1.Text);
                    cmd.Parameters.AddWithValue("@adet", adet1.Text);
                    cmd.Parameters.AddWithValue("@fiyat", fiyat1.Text);
                    cmd.Parameters.AddWithValue("@aciklama", aciklama1.Text);
                    cmd.Parameters.AddWithValue("@resim", imageBytes); // Resim verisini ekledik
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Listele();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir resim seçin.");
            }
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
            string komut = "SELECT * FROM urun";
            SqlDataAdapter db = new SqlDataAdapter(komut, con);
            DataSet ds = new DataSet();
            db.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void güncellemeButton_Click(object sender, EventArgs e)
        {
            Güncelle();
        }

        public void Güncelle()
        {
            if (resim1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    resim1.Image.Save(ms, resim1.Image.RawFormat);
                    byte[] imageBytes = ms.ToArray();

                    con.Open();
                    string id = gridView1.GetFocusedRowCellValue("Id").ToString();
                    SqlCommand cmd = new SqlCommand("UPDATE urun SET UrunAdi=@urunAdi, Beden=@beden, GiyimSecenekleri=@giyimSecenekleri, Kategori=@kategori, Gogus=@gogus, Bel=@bel, Basen=@basen, Adet=@adet, Fiyat=@fiyat, Aciklama=@aciklama, Resim=@resim WHERE Id=@id", con);
                    cmd.Parameters.AddWithValue("@urunAdi", urunAdi1.Text);
                    cmd.Parameters.AddWithValue("@beden", beden1.SelectedItem);
                    cmd.Parameters.AddWithValue("@giyimSecenekleri", giyimSecenekleri1.SelectedItem);
                    cmd.Parameters.AddWithValue("@kategori", kategori1.SelectedItem);
                    cmd.Parameters.AddWithValue("@gogus", gogus1.Text);
                    cmd.Parameters.AddWithValue("@bel", bel1.Text);
                    cmd.Parameters.AddWithValue("@basen", basen1.Text);
                    cmd.Parameters.AddWithValue("@adet", adet1.Text);
                    cmd.Parameters.AddWithValue("@fiyat", fiyat1.Text);
                    cmd.Parameters.AddWithValue("@aciklama", aciklama1.Text);
                    cmd.Parameters.AddWithValue("@resim", imageBytes);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Listele();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir resim seçin.");
            }
        }

        public void BilgiCek()
        {
            urunAdi1.Text = gridView1.GetFocusedRowCellValue("UrunAdi").ToString();
            beden1.Text = gridView1.GetFocusedRowCellValue("Beden").ToString();
            gogus1.Text = gridView1.GetFocusedRowCellValue("Gogus").ToString();
            bel1.Text = gridView1.GetFocusedRowCellValue("Bel").ToString();
            basen1.Text = gridView1.GetFocusedRowCellValue("Basen").ToString();
            adet1.Text = gridView1.GetFocusedRowCellValue("Adet").ToString();
            aciklama1.Text = gridView1.GetFocusedRowCellValue("Aciklama").ToString();

            byte[] imageBytes = gridView1.GetFocusedRowCellValue("Resim") as byte[];
            if (imageBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    resim1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                resim1.Image = null;
            }
        }

        private void silButton_Click(object sender, EventArgs e)
        {
            Sil();
        }

        public void Sil()
        {
            DialogResult onay = MessageBox.Show("Kaydı Silmek İstediğinize Emin Misiniz", "Onay Kutusu", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (onay == DialogResult.Yes)
            {
                con.Open();
                string id = gridView1.GetFocusedRowCellValue("Id").ToString();
                SqlCommand cmd = new SqlCommand("DELETE FROM urun WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                Listele();
            }
        }
    }
}
