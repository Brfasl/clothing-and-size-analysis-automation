using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login_And_Register_Page
{
    public partial class FluentDesignForm1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FluentDesignForm1()
        {
            InitializeComponent();
           
        }

        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            // TileBar ayarlarını yapılandırma
            KadinÜstPage.Width = KadinÜstPage.ItemSize * 3; // 3 sütun genişliği
            KadinÜstPage.ScrollMode = TileControlScrollMode.None; // Kaydırmayı devre dışı bırak
            KadinÜstPage.Hide();
        }

        private void KadinÜstGiyim_Click(object sender, EventArgs e)
        {
            KadinÜstPage.Show();
        }

       
    }
}