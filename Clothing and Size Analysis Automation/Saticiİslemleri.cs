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
                resim.Image = Image.FromFile(openFileDialog.FileName);

                
            }
        }

        
    }
}
