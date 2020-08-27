using DevExpress.XtraEditors;
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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        //void Listele()
        //{
        //    DataTable dt = new DataTable();
        //    SqlDataAdapter da = new SqlDataAdapter("Select * from Firmalar", baglan.Baglanti());
        //    da.Fill(dt);
        //    gridControl1.DataSource = dt;

        //}
        GenelIslemler gi = new GenelIslemler();
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            gi.Listele("Firmalar", gridControl1);
            gi.SutunGetir("Sehir", "Iller", cmbIl);
            //Listele();
        }
        public void Temizle()
        {

            foreach (Control item in this.Controls)
            {
                if (item is TextEdit)
                {
                    TextEdit tb = (TextEdit)item;
                    tb.Reset();
                }
                if (item is MaskedTextBox)
                {
                    MaskedTextBox msk = (MaskedTextBox)item;
                    msk.Clear();
                }
                if (item is RichTextBox)
                {
                    RichTextBox rch = (RichTextBox)item;
                    rch.Clear();
                }


            }
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtAd.Text = dr["Ad"].ToString();
                txtSektor.Text = dr["Sektor"].ToString();
                txtYetkiliAdSoyad.Text = dr["YetkiliAdSoyad"].ToString();
                txtYetkiliGorev.Text = dr["YetkiliStatu"].ToString();
                mskTC.Text = dr["YetkiliTC"].ToString();
                mskTel1.Text = dr["Telefon1"].ToString();
                mskTel1.Text = dr["Telefon2"].ToString();
                mskTel1.Text = dr["Telefon3"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                mskFax.Text = dr["Fax"].ToString();
                cmbIl.Text = dr["Il"].ToString();
                cmbIlce.Text = dr["Ilce"].ToString();
                txtVergiDaire.Text = dr["VergiDaire"].ToString();
                rchAdres.Text = dr["Adres"].ToString();
                txtOzelKod1.Text = dr["OzelKod1"].ToString();
                txtOzelKod2.Text = dr["OzelKod1"].ToString();
                txtOzelKod3.Text = dr["OzelKod1"].ToString();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            gi.Sil("Firmalar", gridView1);
            gi.Listele("Firmalar", gridControl1);

            //gi.Temizle(this.Controls);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Firmalar(Ad,YetkiliStatu,YetkiliAdSoyad,YetkiliTC,Sektor,Telefon1,Telefon2,Telefon3,Mail,Fax,Il,Ilce,VergiDaire,Adres,OzelKod1,OzelKod2,OzelKod3) values(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8,@p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16,@p17)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbIl.Text);
            komut.Parameters.AddWithValue("@p12", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p14", rchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtOzelKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtOzelKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtOzelKod3.Text);
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            MessageBox.Show("Ürün Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Listele();
            gi.Listele("Firmalar", gridControl1);
            FrmFirmalar frmFirmalar = new FrmFirmalar();
            frmFirmalar = this;
            //gi.Temizle(frmFirmalar.Controls);
            //Temizle();
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            gi.IlceGetir(cmbIl, cmbIlce);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Firmalar set Ad=@p1,YetkiliStatu=@p2,YetkiliAdSoyad=@p3,YetkiliTC=@p4,Sektor=@p5,Telefon1=@p6,Telefon2=@p7,Telefon3=@p8,Mail=@p9,Fax=@p10,Il=@p11,Ilce=@p12,VergiDaire=@p13,Adres=@p14,OzelKod1=@p15,OzelKod2=@p16,OzelKod3=@p17 where Id=@p0", gi.Baglanti());
            komut.Parameters.AddWithValue("@p0", gridView1.GetFocusedRowCellValue("Id").ToString());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliAdSoyad.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbIl.Text);
            komut.Parameters.AddWithValue("@p12", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDaire.Text);
            komut.Parameters.AddWithValue("@p14", rchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtOzelKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtOzelKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtOzelKod3.Text);
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            MessageBox.Show("Firma Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gi.Listele("Firmalar", gridControl1);
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            //List<Control> control = new List<Control>();
            //control= (Control.ControlCollection)this.Controls;
            //for (int i = 0; i < this.Controls.Count; i++)
            //{
            //    control.
            //}


            //this.Controls.Remove();

        }
    }
}
