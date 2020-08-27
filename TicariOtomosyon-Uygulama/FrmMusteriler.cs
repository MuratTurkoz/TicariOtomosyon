using DevExpress.XtraPrinting.Export.Pdf;
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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        GenelIslemler gi = new GenelIslemler();
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            gi.Listele("Musteriler", gridControl1);
            gi.SutunGetir("Sehir", "Iller", cmbIl);
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            gi.IlceGetir(cmbIl, cmbIlce);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Musteriler(Ad,Soyad,Telefon,Telefon2,Tc,Mail,Il,Ilce,Adres,VergiDaire) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbIl.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@p8", cmbIlce.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergiDaire.Text);
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            gi.Listele("Musteriler", gridControl1);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTel1.Text = dr[3].ToString();
                mskTel2.Text = dr[4].ToString();
                mskTC.Text = dr[5].ToString();
                txtMail.Text = dr[6].ToString();
                cmbIl.Text = dr[7].ToString();
                cmbIlce.Text = dr[8].ToString();
                txtVergiDaire.Text = dr[9].ToString();
                rchAdres.Text = dr[10].ToString();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            gi.Sil("Musteriler", gridView1);
            gi.Listele("Musteriler", gridControl1);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Musteriler set Ad=@p1,Soyad=@p2,Telefon=@p3,Telefon2=@p4,Tc=@p5,Mail=@p6,Il=@p7,Ilce=@p8,Adres=@p9,VergiDaire=@p10 where Id=@p0", gi.Baglanti());
            komut.Parameters.AddWithValue("@p0", gridView1.GetFocusedRowCellValue("Id").ToString());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbIl.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@p8", cmbIlce.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergiDaire.Text);
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            gi.Listele("Musteriler", gridControl1);
        }
    }
}
