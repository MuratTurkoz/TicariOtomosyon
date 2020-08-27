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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Giderler ([Elektrik],[Su],[Dogalgaz],[Internet],[Maaslar],[Ekstra],[Notlar],[Tarih]) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p7", rchBxNotlar.Text);
            komut.Parameters.AddWithValue("@p8", DateTime.Parse(dateTarih.Text).Date);
            komut.ExecuteNonQuery();
            gi.Listele("Giderler", grdConGiderler);
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            gi.Listele("Giderler", grdConGiderler);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            gi.Sil("Giderler", gridView1);
            gi.Listele("Giderler", grdConGiderler);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,Internet=@p4,Maaslar=@p5,Ekstra=@p6,Notlar=@p7,Tarih=@p8 where Id=@p0", gi.Baglanti());
            komut.Parameters.AddWithValue("@p0", gridView1.GetFocusedRowCellValue("Id").ToString());
            komut.Parameters.AddWithValue("@p1", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p7", rchBxNotlar.Text);
            komut.Parameters.AddWithValue("@p8", DateTime.Parse(dateTarih.Text).Date);
            komut.ExecuteNonQuery();
            gi.Listele("Giderler", grdConGiderler);
        }

        private void grdConGiderler_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                dateTarih.Text = DateTime.Parse(dr["Tarih"].ToString()).ToString("dd.MM.yyyy");
                txtElektrik.Text = dr["Elektrik"].ToString();
                txtSu.Text = dr["Su"].ToString();
                txtDogalgaz.Text = dr["Dogalgaz"].ToString();
                txtInternet.Text = dr["Internet"].ToString();
                txtMaaslar.Text = dr["Maaslar"].ToString();
                txtEkstra.Text = dr["Ekstra"].ToString();
                rchBxNotlar.Text = dr["Notlar"].ToString();
            }
        }
    }
}
