using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
           

        }

        
    }
}
