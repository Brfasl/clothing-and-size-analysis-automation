using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Login_And_Register_Page
{
    public partial class CustomerProductView : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berfin\\source\\repos\\Login And Register Page\\Clothing and Size Analysis Automation\\Database1.mdf;Integrated Security=True");

        public CustomerProductView()
        {
            InitializeComponent();

        }
        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemleri buraya yazabilirsiniz.
        }

        public void UrunleriListele(string kategori, string giyimSecenekleri)
        {
            // Seçilen kategoriye göre doğru paneli al
            FlowLayoutPanel selectedPanel = null;

            if (kategori == "Kadın")
            {
                if (giyimSecenekleri == "Üst")
                    selectedPanel = KadinUstPanel;
                else if (giyimSecenekleri == "Alt")
                    selectedPanel = KadinAltPanel;
            }
            else if (kategori == "Erkek")
            {
                if (giyimSecenekleri == "Üst")
                    selectedPanel = ErkekUstPanel;
                else if (giyimSecenekleri == "Alt")
                    selectedPanel = ErkekAltPanel;
            }
            else if (kategori == "Çocuk")
            {
                if (giyimSecenekleri == "Üst")
                    selectedPanel = CocukUstPanel;
                else if (giyimSecenekleri == "Alt")
                    selectedPanel = CocukAltPanel;
            }

            if (selectedPanel != null)
            {
                // FlowLayoutPanel'deki önceki ürünleri temizle
                selectedPanel.Controls.Clear();

                // Kategoriye ve giyim türüne göre ürünleri veritabanından al
                SqlDataAdapter da = new SqlDataAdapter("SELECT UrunAdi, Fiyat, Resim FROM urun WHERE Kategori = @kategori AND GiyimSecenekleri = @giyimSecenekleri", con);
                da.SelectCommand.Parameters.AddWithValue("@kategori", kategori);
                da.SelectCommand.Parameters.AddWithValue("@giyimSecenekleri", giyimSecenekleri);

                DataTable dt = new DataTable();
                da.Fill(dt); // Veritabanındaki ürünleri DataTable'a yükle

                // Her bir ürünü FlowLayoutPanel'e ekle
                foreach (DataRow row in dt.Rows)
                {
                    Panel panel = new Panel();
                    panel.Width = 200;
                    panel.Height = 300;

                    // Ürün adı
                    Label lblUrunAdi = new Label();
                    lblUrunAdi.Text = row["UrunAdi"].ToString();
                    lblUrunAdi.Dock = DockStyle.Top;
                    panel.Controls.Add(lblUrunAdi);

                    // Ürün fiyatı
                    Label lblFiyat = new Label();
                    lblFiyat.Text = "Fiyat: " + row["Fiyat"].ToString() + " TL";
                    lblFiyat.Dock = DockStyle.Top;
                    panel.Controls.Add(lblFiyat);

                    // Ürün resmi
                    PictureBox pictureBox = new PictureBox();
                    byte[] resimByte = (byte[])row["Resim"];
                    pictureBox.Image = ByteToResim(resimByte); // Byte dizisinden resmi Image'a çevirme
                    pictureBox.Width = 150;
                    pictureBox.Height = 150;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Dock = DockStyle.Fill;
                    panel.Controls.Add(pictureBox);

                    // Seçilen FlowLayoutPanel'e ekle
                    selectedPanel.Controls.Add(panel);
                }
            }
        }

        private Image ByteToResim(byte[] resimByte)
        {
            using (MemoryStream ms = new MemoryStream(resimByte))
            {
                return Image.FromStream(ms);
            }
        }

        // Kadın Üst Giyim butonunun click olayı
        private void KadinÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Kadın", "Üst");

            // Tüm panelleri gizle
            KadinAltPanel.Hide();
            KadinUstPanel.Show();
            ErkekAltPanel.Hide();
            ErkekUstPanel.Hide();
            CocukAltPanel.Hide();
            CocukUstPanel.Hide();
        }

        // Kadın Alt Giyim butonunun click olayı
        private void KadinAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Kadın", "Alt");

            KadinAltPanel.Show();
            KadinUstPanel.Hide();
            ErkekAltPanel.Hide();
            ErkekUstPanel.Hide();
            CocukAltPanel.Hide();
            CocukUstPanel.Hide();
        }

        // Erkek Üst Giyim butonunun click olayı
        private void ErkekÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Erkek", "Üst");

            KadinAltPanel.Hide();
            KadinUstPanel.Hide();
            ErkekAltPanel.Hide();
            ErkekUstPanel.Show();
            CocukAltPanel.Hide();
            CocukUstPanel.Hide();
        }

        // Erkek Alt Giyim butonunun click olayı
        private void ErkekAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Erkek", "Alt");

            KadinAltPanel.Hide();
            KadinUstPanel.Hide();
            ErkekAltPanel.Show();
            ErkekUstPanel.Hide();
            CocukAltPanel.Hide();
            CocukUstPanel.Hide();
        }

        // Çocuk Üst Giyim butonunun click olayı
        private void CocukÜstGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Çocuk", "Üst");

            KadinAltPanel.Hide();
            KadinUstPanel.Hide();
            ErkekAltPanel.Hide();
            ErkekUstPanel.Hide();
            CocukAltPanel.Hide();
            CocukUstPanel.Show();
        }

        // Çocuk Alt Giyim butonunun click olayı
        private void CocukAltGiyim_Click(object sender, EventArgs e)
        {
            UrunleriListele("Çocuk", "Alt");

            KadinAltPanel.Hide();
            KadinUstPanel.Hide();
            ErkekAltPanel.Hide();
            ErkekUstPanel.Hide();
            CocukAltPanel.Show();
            CocukUstPanel.Hide();
        }
    }
}
