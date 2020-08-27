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
    public partial class FrmFaturaDetay : Form
    {
        public FrmFaturaDetay()
        {
            InitializeComponent();
        }
        public string id;
        GenelIslemler gi = new GenelIslemler();
        private void FrmFaturaDetay_Load(object sender, EventArgs e)
        {
            //lblDeneme.Text = id;
            gi.UniqSutunGetir("UrunAd", "Urunler", cmbUrunAd);
            gi.IdGoreListele(int.Parse(id), "FaturaId", "FaturaDetay", gridControl12);


        }

        private void btnKaydet1_Click(object sender, EventArgs e)
        {
            double miktar, fiyat, tutar;
            fiyat = Convert.ToDouble(txtFiyat.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = fiyat * miktar;
            lblTutar.Text = tutar.ToString();
            SqlCommand komut = new SqlCommand("insert into FaturaDetay (UrunAd,Miktar,Fiyat,Tutar,FaturaId) values (@p1,@p2,@p3,@p4,@p5)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", cmbUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblTutar.Text));
            komut.Parameters.AddWithValue("@p5", id);

            komut.ExecuteNonQuery();
            gi.IdGoreListele(int.Parse(id), "FaturaId", "FaturaDetay", gridControl12);
        }

        private void btnSil1_Click(object sender, EventArgs e)
        {
            gi.Sil("FaturaUrunID", "FaturaDetay", gridView1);
            gi.IdGoreListele(int.Parse(id), "FaturaId", "FaturaDetay", gridControl12);
        }


        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                cmbUrunAd.Text = dr["UrunAd"].ToString();
                txtMiktar.Text = dr["Miktar"].ToString();
                txtFiyat.Text = dr["Fiyat"].ToString();
                lblTutar.Text = dr["Tutar"].ToString();

            }
        }

        private void btnGuncelle1_Click(object sender, EventArgs e)
        {
            double miktar, fiyat, tutar;
            fiyat = Convert.ToDouble(txtFiyat.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = fiyat * miktar;
            lblTutar.Text = tutar.ToString();
            SqlCommand komut = new SqlCommand("update FaturaDetay set UrunAd=@p1,Miktar=@p2,Fiyat=@p3,Tutar=@p4 where FaturaUrunId=@p0", gi.Baglanti());
            komut.Parameters.AddWithValue("@p0", gridView1.GetFocusedRowCellValue("FaturaUrunID").ToString());
            komut.Parameters.AddWithValue("@p1", cmbUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", int.Parse(txtMiktar.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblTutar.Text));
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            MessageBox.Show("Ürün Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Listele();
            gi.IdGoreListele(int.Parse(id), "FaturaId", "FaturaDetay", gridControl12);
        }
    }
}
