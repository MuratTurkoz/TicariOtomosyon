using DevExpress.XtraEditors.Filtering.Templates;
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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            gi.Listele("FaturaBilgi", gridControl1);

            gi.UniqSutunGetir("UrunAd", "Urunler", cmbUrunAd);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            //SqlCommand komut = new SqlCommand("insert into FaturaDetay (UrunAd,Miktar,Fiyat,Tutar,FaturaId) values (@p1,@p2,@p3,@p4)", gi.Baglanti());
            //komut.Parameters.AddWithValue("@p1", cmbUrunAd.Text);
            //komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            //komut.Parameters.AddWithValue("@p3", txtFiyat.Text);
            //komut.Parameters.AddWithValue("@p4", txtTutar.Text);
            //komut.Parameters.AddWithValue("@p5", );

            //komut.ExecuteNonQuery();
            //gi.Listele("FaturaBilgi", gridControl1);

        }

        private void btnKaydet1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into FaturaBilgi ([Seri],[SıraNo],[Tarih],[Saat],[VergiDaire],[Alici],[TeslimEden],[TeslimAlan]) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtSeri.Text);
            komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", DateTime.Parse(dateTarih.Text).Date);
            komut.Parameters.AddWithValue("@p4", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            komut.ExecuteNonQuery();
            gi.Listele("FaturaBilgi", gridControl1);
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            FrmFaturaDetay frmFaturaDetay = new FrmFaturaDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                frmFaturaDetay.id = dr["Id"].ToString();
            }
            frmFaturaDetay.Show();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtSeri.Text = dr[0].ToString();
                txtSiraNo.Text = dr[1].ToString();
                dateTarih.Text = dr[2].ToString();
                mskSaat.Text = dr[3].ToString();
                txtVergiDaire.Text = dr[4].ToString();
                txtAlici.Text = dr[5].ToString();
                txtTeslimEden.Text = dr[6].ToString();
                txtTeslimAlan.Text = dr[7].ToString();
            }
        }

        private void cmbUrunAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMarka.Properties.Items.Clear();
            gi.UniqSutunGetir("Marka", "UrunAd", "Urunler", cmbUrunAd, cmbMarka);
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMarka.Properties.Items.Clear();

            // gi.UniqSutunGetir("model", "Marka", "Urunler", cmbMarka, cmbModel, cmbUrunAd);

            //gi.FiyatGetir(txtFiyat.Text);
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.Columns.Clear();

            //gi.UniqSutunGetir("model", "Marka", "Urunler", cmbMarka, lookUpEdit1, cmbUrunAd);
            gi.UniqSutunGetir1("Urunler", "Model", "Marka", lookUpEdit1, cmbMarka, cmbUrunAd);

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            txtFiyat.Text = "";
            gi.FiyatGetir(lookUpEdit1.EditValue.ToString(), txtFiyat);
        }
    }
}
