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

    public partial class bilgiGirisi : Form
    {
        // Buradaki TextBox'lar, formunuzdaki ilgili alanlardır
        public TextBox gogusTextBox;
        public TextBox belTextBox;
        public TextBox basenTextBox;

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berfin\\source\\repos\\Login And Register Page\\Clothing and Size Analysis Automation\\Database1.mdf;Integrated Security=True");
        public bilgiGirisi()
        {
            InitializeComponent();
        }

        // SetMeasurements metodunu ekliyoruz
        public void SetMeasurements(int gogus, int bel, int basen)
        {
            gogusTextBox.Text = gogus.ToString();
            belTextBox.Text = bel.ToString();
            basenTextBox.Text = basen.ToString();
        }
        private void bilgiEkle_Click(object sender, EventArgs e)
        {
            Ekle();
        }
        public void Ekle()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO girilenBilgi (Name, Kategori, GiyimSecenekleri, Gogus, Bel, Basen)" +
                                            "VALUES (@name, @kategori, @giyimSecenekleri, @gogus, @bel, @basen)", con);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@kategori", kategori.SelectedItem);
            cmd.Parameters.AddWithValue("@giyimSecenekleri", giyimSecenekleri.SelectedItem);
            cmd.Parameters.AddWithValue("@gogus", gogus.Text);
            cmd.Parameters.AddWithValue("@bel", bel.Text);
            cmd.Parameters.AddWithValue("@basen", basen.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
        }

        private void bilgiGirisi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            string komut = "SELECT * FROM girilenBilgi";
            SqlDataAdapter db = new SqlDataAdapter(komut, con);
            DataSet ds = new DataSet();
            db.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
        }

        private void bilgiGüncelle_Click(object sender, EventArgs e)
        {
            Güncelle();
        }
        public void Güncelle()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO girilenBilgi (Name, Kategori, GiyimSecenekleri, Gogus, Bel, Basen)" +
                                            "VALUES (@name, @kategori, @giyimSecenekleri, @gogus, @bel, @basen)", con);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@kategori", kategori.SelectedItem);
            cmd.Parameters.AddWithValue("@giyimSecenekleri", giyimSecenekleri.SelectedItem);
            cmd.Parameters.AddWithValue("@gogus", gogus.Text);
            cmd.Parameters.AddWithValue("@bel", bel.Text);
            cmd.Parameters.AddWithValue("@basen", basen.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
        }


        private void bilgiSil_Click(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("DELETE FROM girilenBilgi WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                Listele();
            }
        }

        private void geriDön_Click(object sender, EventArgs e)
        {
            Musteriİslemleri mstr = new Musteriİslemleri();
            mstr.Show();
            this.Hide();
        }
    }
}
