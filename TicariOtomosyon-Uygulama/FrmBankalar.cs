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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            gi.ListeleProcedure("BankaBilgileri", gridControl1);
            gi.SutunGetir("Sehir", "Iller", cmbIl);
            gi.FirmaAdGetir(cmbFirmalar);
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            gi.IlceGetir(cmbIl, cmbIlce);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Bankalar (BankaAdi,Il,Ilce,Sube,IBAN,HesapNo,Yetkili,Telefon,HesapTuru,Tarih,FirmaId) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", cmbIl.Text);
            komut.Parameters.AddWithValue("@p3", cmbIlce.SelectedText);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", txtIban.Text);
            komut.Parameters.AddWithValue("@p6", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTel.Text);
            komut.Parameters.AddWithValue("@p9", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p10", DateTime.Parse(dateTarih.Text).Date);
            komut.Parameters.AddWithValue("@p11", int.Parse(cmbFirmalar.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            gi.ListeleProcedure("BankaBilgileri", gridControl1);
            gi.Baglanti().Close();
            //string a = lookUpEdit1.OldEditValue.ToString();
        }



        private void cmbFirmalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string a = cmbFirmalar.ValueMember;
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtBankaAdi.Text = dr["BankaAdi"].ToString();
                cmbIl.Text = dr["Il"].ToString();
                cmbIlce.Text = dr["Ilce"].ToString();
                txtSube.Text = dr["Sube"].ToString();
                txtIban.Text = dr["Iban"].ToString();
                txtHesapNo.Text = dr["HesapNo"].ToString();
                txtYetkili.Text = dr["Yetkili"].ToString();
                mskTel.Text = dr["Telefon"].ToString();
                dateTarih.Text = DateTime.Parse(dr["Tarih"].ToString()).ToString("dd.MM.yyyy");
                txtHesapTuru.Text = dr["HesapTuru"].ToString();
                cmbFirmalar.Text = dr["Ad"].ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            gi.Sil("Bankalar", gridView1);
            gi.ListeleProcedure("BankaBilgileri", gridControl1);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //UPDATE tblUrunler_2 SET Fiyat = (SELECT Fiyat FROM tblUrunler_1 WHERE tblUrunler_2.UrunAdi = tblUrunler_1.UrunAdi
            SqlCommand komut = new SqlCommand("exec BankaGuncelle @p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12", gi.Baglanti());
            komut.Parameters.AddWithValue("@p12", gridView1.GetFocusedRowCellValue("Id").ToString());
            komut.Parameters.AddWithValue("@p1", txtBankaAdi.Text);
            komut.Parameters.AddWithValue("@p2", cmbIl.Text);
            komut.Parameters.AddWithValue("@p3", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", txtIban.Text);
            komut.Parameters.AddWithValue("@p6", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTel.Text);
            komut.Parameters.AddWithValue("@p9", DateTime.Parse(dateTarih.Text).Date);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", cmbFirmalar.Text);
            komut.ExecuteNonQuery();
            gi.ListeleProcedure("BankaBilgileri", gridControl1);
        }
    }
}

