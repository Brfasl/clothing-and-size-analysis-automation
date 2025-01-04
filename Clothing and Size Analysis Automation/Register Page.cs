using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing; // Renk ve boyut özellikleri için



namespace Login_And_Register_Page
{
    public partial class RegisterPage : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berfin\\source\\repos\\Login And Register Page\\Clothing and Size Analysis Automation\\Database1.mdf;Integrated Security=True");

        public RegisterPage()
        {
            InitializeComponent();
        }

       

        private void register_Click(object sender, EventArgs e)
        {
        
            try
            {
                // Confirm Password kontrolü
                if (password.Text != confirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // İşlemi sonlandır
                }
                con.Open();
                string query = "INSERT INTO register (Username, Email, Password) VALUES (@username, @email, @password)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@username", userName.Text);
                cmd.Parameters.AddWithValue("@email", eMail.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Registration successful!");

                    // Formlar arası geçiş kodu
                    this.Hide(); // Mevcut formu gizle
                    LoginPage login = new LoginPage(); // Login Page formunu oluştur
                    login.Show(); // Login Page'i göster
                }
                else
                {
                    MessageBox.Show("Registration failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message );

            }
            finally
            {
                con.Close();
            }
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                // Şifreyi göster
                password.UseSystemPasswordChar = false; // UseSystemPasswordChar'ı devre dışı bırak
                confirmPassword.UseSystemPasswordChar = false;

                password.PasswordChar = '\0'; // Şifreyi açık hale getir
                confirmPassword.PasswordChar = '\0';
            }
            else
            {
                // Şifreyi yıldız (*) ile gizle
                password.UseSystemPasswordChar = false; // Kullanılmaması gerektiğinden false
                confirmPassword.UseSystemPasswordChar = false;

                password.PasswordChar = '*'; // Yıldız ile gizle
                confirmPassword.PasswordChar = '*';
            }
        }

        private void backtoLogin_Click(object sender, EventArgs e)
        {
            // Login formunu aç ve Register formunu kapat
            LoginPage loginPage = new LoginPage(); // Login sayfasının formu
            loginPage.Show();  // Login sayfasını göster
            this.Hide(); // Register sayfasını gizle
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


        private void RegisterPage_Load(object sender, EventArgs e)
        {

            // Şifre kutularını başlangıçta yıldız (*) ile gizle
            password.UseSystemPasswordChar = false;
            confirmPassword.UseSystemPasswordChar = false;

            password.PasswordChar = '*';
            confirmPassword.PasswordChar = '*';


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

        private void closeButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Boyutunu geri eski haline getirelim
                btn.Size = new Size(32, 32); // Eski boyutuna döndür (veya sizin istediğiniz boyut)
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
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

