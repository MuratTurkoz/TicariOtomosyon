using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicariOtomosyon_Uygulama.Islemler;

namespace TicariOtomosyon_Uygulama
{
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }
 
        GenelIslemler gi = new GenelIslemler();
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            gi.Listele("Ad,Soyad,Telefon,Telefon2,Mail", "Musteriler", gridControl2);
            gi.Listele("Ad,Sektor,Telefon1,Telefon2,Mail", "Firmalar", gridControl1);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr!=null)
            {
                frmMail.mail = dr["Mail"].ToString();
                frmMail.Show();
            }
        }
    }
}
