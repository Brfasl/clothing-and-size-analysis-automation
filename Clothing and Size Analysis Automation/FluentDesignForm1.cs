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
            KadinÜstPage1.Width = KadinÜstPage1.ItemSize * 3; // 3 sütun genişliği
            KadinÜstPage1.ScrollMode = TileControlScrollMode.None; // Kaydırmayı devre dışı bırak
            KadinÜstPage1.Hide();
        }

        private void KadinÜstGiyim_Click(object sender, EventArgs e)
        {
            KadinÜstPage1.Show();
            KadinÜstPage2.Show();
        }

        private void ErkekÜstGiyim_Click(object sender, EventArgs e)
        {
            ErkekÜstPage1.Show();
            ErkekÜstPage2.Show();

        }

        private void CocukÜstGiyim_Click(object sender, EventArgs e)
        {
            CocukÜstPage1.Show();
            CocukÜstPage2.Show();
        }
    }
}