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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        GenelIslemler gi = new GenelIslemler();
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            gi.Listele("Personeller", grdConPersoneller);
            gi.SutunGetir("Sehir", "Iller", cmbIl);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            gi.Sil("Personeller", gridView1);
            gi.Listele("Personeller", grdConPersoneller);
        }

        private void grdConPersoneller_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtAd.Text = dr["Ad"].ToString();
                txtSoyad.Text = dr["Soyad"].ToString();
                mskTelefon.Text = dr["Telefon"].ToString();
                mskTC.Text = dr["Tc"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                cmbIl.Text = dr["Il"].ToString();
                cmbIlce.Text = dr["Ilce"].ToString();
                rchAdres.Text = dr["Adres"].ToString();
                txtGorev.Text = dr["Gorev"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Personeller (Ad,Soyad,Telefon,Tc,Mail,Il,Ilce,Adres,Gorev) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIl.Text);
            komut.Parameters.AddWithValue("@p7", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            gi.Listele("Personeller", grdConPersoneller);
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            gi.IlceGetir(cmbIl, cmbIlce);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Personeller set Ad=@p1,Soyad=@p2,Telefon=@p3,Tc=@p4,Mail=@p5,Il=@p6,Ilce=@p7,Adres=@p8,Gorev=@p9 where Id=@p0", gi.Baglanti());
            komut.Parameters.AddWithValue("@p0", gridView1.GetFocusedRowCellValue("Id"));
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIl.Text);
            komut.Parameters.AddWithValue("@p7", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            gi.Baglanti().Close();
            gi.Listele("Personeller", grdConPersoneller);
        }
    }
}
