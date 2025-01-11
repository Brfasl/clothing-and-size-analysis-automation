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
            // Form yüklendiğinde yapılacak işlemler buraya eklenebilir.
        }

        public void UrunleriListele(string kategori, string giyimSecenekleri)
        {
            // Tek bir FlowLayoutPanel kullanıyoruz
            flowLayoutPanel1.Controls.Clear();

            try
            {
                con.Open();
                string query = "SELECT UrunAdi, Beden, Fiyat, Resim, Aciklama FROM urun WHERE Kategori = @Kategori AND GiyimSecenekleri = @GiyimSecenekleri";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@Kategori", kategori);
                da.SelectCommand.Parameters.AddWithValue("@GiyimSecenekleri", giyimSecenekleri);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Bu kategoride ürün bulunamadı.");
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

                    // Ürün adı
                    Label lblUrunAdi = new Label
                    {
                        Text = row["UrunAdi"].ToString(),
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    panel.Controls.Add(lblUrunAdi);

                    // Ürün fiyatı
                    Label lblFiyat = new Label
                    {
                        Text = "Fiyat: " + row["Fiyat"].ToString() + " TL",
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    panel.Controls.Add(lblFiyat);

                    // Ürün beden
                    Label lblBeden = new Label
                    {
                        Text = "Beden: " + row["Beden"].ToString(),
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    panel.Controls.Add(lblBeden);

                    // Ürün açıklama
                    Label lblAciklama = new Label
                    {
                        Text = "Açıklama: " + row["Aciklama"].ToString(),
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = true
                    };
                    panel.Controls.Add(lblAciklama);

                    // Ürün resmi
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
                        pictureBox.Image = null; // Eğer resim yoksa null bırak
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

        private void KadinÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Kadın", "Üst Giyim");
        }

        private void KadinAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Kadın", "Alt Giyim");
        }

        private void ErkekÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Erkek", "Üst Giyim");
        }

        private void ErkekAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Erkek", "Alt Giyim");
        }

        private void CocukÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Çocuk", "Üst Giyim");
        }

        private void CocukAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Çocuk", "Alt Giyim");
        }

        private void bilgiGirisi_Click(object sender, EventArgs e)
        {
            bilgiGirisi bg = new bilgiGirisi();
            bg.Show();
            this.Hide();
        }
    }
}
