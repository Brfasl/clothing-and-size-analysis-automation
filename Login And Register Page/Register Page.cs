using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_And_Register_Page
{
    public partial class RegisterPage : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berfin\\source\\repos\\Login And Register\\Login And Register Page\\Register.mdf;Integrated Security=True");

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
                string query = "INSERT INTO ABCD (Username, Email, Password) VALUES (@username, @email, @password)";
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
                MessageBox.Show("Error: " + ex.Message);
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

        private void RegisterPage_Load(object sender, EventArgs e)
        {
            // Şifre kutularını başlangıçta yıldız (*) ile gizle
            password.UseSystemPasswordChar = false;
            confirmPassword.UseSystemPasswordChar = false;

            password.PasswordChar = '*';
            confirmPassword.PasswordChar = '*';

        }
    }
}

