using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing; // Renk ve boyut özellikleri için

namespace Login_And_Register_Page
{
    public partial class LoginPage : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berfin\\source\\repos\\Login And Register\\Login And Register Page\\Register.mdf;Integrated Security=True");

        public LoginPage()
        {
            InitializeComponent();
        }

       

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                // Şifreyi göster
                password.UseSystemPasswordChar = false; // UseSystemPasswordChar'ı devre dışı bırak
                

                password.PasswordChar = '\0'; // Şifreyi açık hale getir
               
            }
            else
            {
                // Şifreyi yıldız (*) ile gizle
                password.UseSystemPasswordChar = false; // Kullanılmaması gerektiğinden false
               

                password.PasswordChar = '*'; // Yıldız ile gizle
                
            }
        }

        private void createAccount_Click(object sender, EventArgs e)
        {
            // Register formunu aç ve Login formunu kapat
            RegisterPage registerPage = new RegisterPage(); // Register sayfasının formu
            registerPage.Show();  // Register sayfasını göster
            this.Hide(); // Login sayfasını gizle
        }

        private void closeButton_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;
            Graphics g = e.Graphics;

            // Anti-aliasing (daha düzgün çizim için)
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(button.BackColor); // Butonun arka planını temizle

            // Yuvarlak şekli çizme
            int borderRadius = button.Width / 2; // Butonun yarıçapı, boyutuna göre dinamik
            g.FillEllipse(new SolidBrush(button.BackColor), 0, 0, button.Width, button.Height); // İç kısmı yuvarlak dolduruyor

            // Kenarlık çizme
            using (Pen pen = new Pen(Color.Black, 2)) // Kenarlık kalınlığı
            {
                g.DrawEllipse(pen, 0, 0, button.Width, button.Height); // Butonun etrafına kenarlık çiz
            }

            // Buton metnini ortalayarak çiziyoruz
            TextRenderer.DrawText(g, button.Text, button.Font, new Rectangle(0, 0, button.Width, button.Height), button.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                // Veritabanına bağlan
                con.Open();

                // Kullanıcı bilgilerini kontrol eden SQL sorgusu
                string query = "SELECT * FROM ABCD WHERE Username = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, con);

                // Parametreleri ekle
                cmd.Parameters.AddWithValue("@username", userName.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                // Giriş kontrolü
                if (reader.HasRows)
                {
                    MessageBox.Show("Login successful!");
                    // Giriş başarılıysa başka bir forma geçiş yapabilirsiniz
                    this.Hide();
                    // Örnek: Ana sayfa

                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            // Şifre kutularını başlangıçta yıldız (*) ile gizle
            password.UseSystemPasswordChar = false;
            

            password.PasswordChar = '*';


            // Paint olayını ekleyelim
            closeButton.Paint += new PaintEventHandler(closeButton_Paint);

            // Mouse olayları
            closeButton.MouseHover += new EventHandler(closeButton_MouseHover);
            closeButton.MouseLeave += new EventHandler(closeButton_MouseLeave);


        }

        private void closeButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Boyutun sadece bir kez küçülmesini sağlamak için bir kontrol ekleyelim
                if (btn.Width == 32 && btn.Height == 32) // Başlangıç boyutuna sahipse
                {
                    btn.Size = new Size(btn.Width - 5, btn.Height - 5); // Küçült
                }
            }
        }

        private void closeButton_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Buton boyutunu küçültüyoruz
                btn.Size = new Size(btn.Width - 3, btn.Height - 3);
            }
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            if (btn != null)
            {
                // Boyutunu geri eski haline getirelim
                btn.Size = new Size(32, 32); // Eski boyutuna döndür (veya sizin istediğiniz boyut)
            }
        }

        private void closeButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Boyutunu geri eski haline getirelim
                btn.Size = new Size(32, 32); // Eski boyutuna döndür (veya sizin istediğiniz boyut)
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
