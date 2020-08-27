using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Data.Db;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Behaviors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            gi.Listele("Urunler", gridControl1);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Urunler(UrunAd,Marka,Model,Yil,Adet,AlisFiyat,SatisFiyat,Detay) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(nmUpAdet.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlis.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
            komut.Parameters.AddWithValue("@p8", rchDetay.Text);
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            MessageBox.Show("Ürün Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Listele();
            gi.Listele("Urunler", gridControl1);
            txtAd.ResetText();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            gi.Sil("Urunler", gridView1);
            gi.Listele("Urunler", gridControl1);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtAd.Text = dr["UrunAd"].ToString();
            txtMarka.Text = dr["Marka"].ToString();
            txtModel.Text = dr["Model"].ToString();
            mskYil.Text = dr["Yil"].ToString();
            nmUpAdet.Text = dr["Adet"].ToString();
            txtAlis.Text = dr["AlisFiyat"].ToString();
            txtSatis.Text = dr["SatisFiyat"].ToString();
            rchDetay.Text = dr["Detay"].ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("update Urunler set UrunAd=@p1,Marka=@p2,Model=@p3,Yil=@p4,Adet=@p5,AlisFiyat=@p6,SatisFiyat=@p7,Detay=@p8 where Id=@p0", gi.Baglanti());
            komutGuncelle.Parameters.AddWithValue("@p0", gridView1.GetFocusedRowCellValue("Id").ToString());
            komutGuncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", txtMarka.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", txtModel.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", mskYil.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", int.Parse(nmUpAdet.Text));
            komutGuncelle.Parameters.AddWithValue("@p6", decimal.Parse(txtAlis.Text));
            komutGuncelle.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
            komutGuncelle.Parameters.AddWithValue("@p8", rchDetay.Text);
            komutGuncelle.ExecuteNonQuery();
            gi.Baglanti().Close();
            MessageBox.Show("Ürün Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Listele();
            gi.Listele("Urunler", gridControl1);
        }
    }
}
