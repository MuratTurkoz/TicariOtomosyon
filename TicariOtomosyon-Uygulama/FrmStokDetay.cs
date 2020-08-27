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
    public partial class FrmStokDetay : Form
    {
        public FrmStokDetay()
        {
            InitializeComponent();
        }
        public string urunAd;
        GenelIslemler gi = new GenelIslemler();
        private void FrmStokDetay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Urunler where UrunAd='" + urunAd + "'", gi.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
