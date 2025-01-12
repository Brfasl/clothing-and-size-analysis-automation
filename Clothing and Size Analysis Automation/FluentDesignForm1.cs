using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Login_And_Register_Page
{
    public partial class Musteriİslemleri : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berfin\\source\\repos\\Login And Register Page\\Clothing and Size Analysis Automation\\Database1.mdf;Integrated Security=True");

        public Musteriİslemleri()
        {
            InitializeComponent();
        }

        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            KullaniciAdlariniYukle();
        }

        private void KullaniciAdlariniYukle()
        {
            try
            {
                con.Open();
                string query = "SELECT Name FROM girilenBilgi";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                bilgiGoster.Items.Clear(); // ComboBox içeriğini temizleyin
                while (reader.Read())
                {
                    string name = reader["Name"].ToString();
                    bilgiGoster.Items.Add(name); // Kullanıcı isimlerini ekleyin
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void UrunleriListele(int gogus, int bel, int basen, string kategori)
        {
            flowLayoutPanel1.Controls.Clear();

            try
            {
                con.Open();
                string query = "SELECT UrunAdi, Beden, Fiyat, Resim, Aciklama FROM urun WHERE Gogus <= @Gogus AND Bel <= @Bel AND Basen <= @Basen AND Kategori = @Kategori";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@Gogus", gogus);
                da.SelectCommand.Parameters.AddWithValue("@Bel", bel);
                da.SelectCommand.Parameters.AddWithValue("@Basen", basen);
                da.SelectCommand.Parameters.AddWithValue("@Kategori", kategori); // Kategoriyi sorguya ekledik

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Ürün Yoktur.");
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    Panel panel = new Panel
                    {
                        Width = 200,
                        Height = 300,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Label lblUrunAdi = new Label
                    {
                        Text = row["UrunAdi"].ToString(),
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panel.Controls.Add(lblUrunAdi);

                    Label lblFiyat = new Label
                    {
                        Text = "Fiyat: " + row["Fiyat"].ToString() + " TL",
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    panel.Controls.Add(lblFiyat);

                    Label lblBeden = new Label
                    {
                        Text = "Beden: " + row["Beden"].ToString(),
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    panel.Controls.Add(lblBeden);

                    Label lblAciklama = new Label
                    {
                        Text = "Açıklama: " + row["Aciklama"].ToString(),
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = true
                    };
                    panel.Controls.Add(lblAciklama);

                    PictureBox pictureBox = new PictureBox
                    {
                        Width = 150,
                        Height = 150,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Dock = DockStyle.Top
                    };

                    if (row["Resim"] != DBNull.Value)
                    {
                        byte[] resimByte = (byte[])row["Resim"];
                        pictureBox.Image = ByteToResim(resimByte);
                    }
                    else
                    {
                        pictureBox.Image = null;
                    }

                    panel.Controls.Add(pictureBox);
                    flowLayoutPanel1.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private Image ByteToResim(byte[] resimByte)
        {
            using (MemoryStream ms = new MemoryStream(resimByte))
            {
                return Image.FromStream(ms);
            }
        }

        // ComboBox'taki seçim değiştiğinde çalışacak metod
        private void bilgiGoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = bilgiGoster.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedName))
            {
                MessageBox.Show("Lütfen bir kullanıcı seçiniz.");
                return;
            }

            try
            {
                con.Open();
                string query = "SELECT Gogus, Bel, Basen, Kategori FROM girilenBilgi WHERE Name = @Name";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", selectedName);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int gogusValue = Convert.ToInt32(reader["Gogus"]);
                    int belValue = Convert.ToInt32(reader["Bel"]);
                    int basenValue = Convert.ToInt32(reader["Basen"]);
                    string kategori = reader["Kategori"].ToString(); // Kategori bilgisi

                    // Kategoriyi kullanarak beden önerisini yap
                    string recommendedSize = BedeniOner(kategori, gogusValue, belValue, basenValue);
                    MessageBox.Show($"Beden önerisi: {recommendedSize}");

                    UrunleriListele(gogusValue, belValue, basenValue, kategori);
                }
                else
                {
                    MessageBox.Show("Kullanıcı bilgisi bulunamadı.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Kategoriye göre beden önerisi yapacak fonksiyon
        private string BedeniOner(string kategori, int gogus, int bel, int basen)
        {
            if (kategori == "Kadın")
            {
                if (gogus <= 90 && bel <= 70 && basen <= 95)
                {
                    return "Small (S)";
                }
                else if (gogus <= 100 && bel <= 80 && basen <= 105)
                {
                    return "Medium (M)";
                }
                else if (gogus <= 110 && bel <= 90 && basen <= 115)
                {
                    return "Large (L)";
                }
                else
                {
                    return "Beden bulunamadı";
                }
            }
            else if (kategori == "Erkek")
            {
                if (gogus <= 100 && bel <= 85 && basen <= 105)
                {
                    return "Small (S)";
                }
                else if (gogus <= 110 && bel <= 95 && basen <= 115)
                {
                    return "Medium (M)";
                }
                else if (gogus <= 120 && bel <= 105 && basen <= 125)
                {
                    return "Large (L)";
                }
                else
                {
                    return "Beden bulunamadı";
                }
            }
            else if (kategori == "Çocuk")
            {
                if (gogus <= 70 && bel <= 60 && basen <= 80)
                {
                    return "Small (S)";
                }
                else if (gogus <= 80 && bel <= 70 && basen <= 90)
                {
                    return "Medium (M)";
                }
                else if (gogus <= 90 && bel <= 80 && basen <= 100)
                {
                    return "Large (L)";
                }
                else
                {
                    return "Beden bulunamadı";
                }
            }
            else
            {
                return "Kategori bulunamadı";
            }
        }

        // Kategori butonlarının click eventleri
        private void KadinÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele(90, 70, 95, "Kadın");
        }

        private void KadinAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele(90, 70, 95, "Kadın");
        }

        private void ErkekÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele(100, 85, 95, "Erkek");
        }

        private void ErkekAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele(100, 85, 95, "Erkek");
        }

        private void CocukÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele(60, 50, 55, "Çocuk");
        }

        private void CocukAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele(60, 50, 55, "Çocuk");
        }

        // Bilgi girişi butonuna tıklanıldığında açılan form
        private void bilgiGirisi_Click(object sender, EventArgs e)
        {
            bilgiGirisi bg = new bilgiGirisi();
            bg.Show();
            this.Hide();
        }

        // Kullanıcıları yüklemek için tıklama işlemi
        private void kullanicilarinBilgisi_Click(object sender, EventArgs e)
        {
            KullaniciAdlariniYukle();
            MessageBox.Show("Kullanıcı bilgileri yüklendi!");
        }
    }
}
