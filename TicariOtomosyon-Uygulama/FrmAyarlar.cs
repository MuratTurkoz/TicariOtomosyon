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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            gi.Listele("Adminler", gridControl1);
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into Adminler (KullaniciAdi,Sifre) values (@p1,@p2)", gi.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                gi.Listele("Adminler", gridControl1);
            }
            if (btnKaydet.Text == "Güncelle")
            {

                SqlCommand komut = new SqlCommand("Update Adminler set KullaniciAdi=@p1,Sifre=@p2 where Id=@p0", gi.Baglanti());
                komut.Parameters.AddWithValue("@p0", gridView1.GetFocusedRowCellValue("Id").ToString());
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                gi.Listele("Adminler", gridControl1);
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtKullaniciAdi.Text = dr["KullaniciAdi"].ToString();
                txtSifre.Text = dr["Sifre"].ToString();
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text != "")
            {
                btnKaydet.Text = "Güncelle";

            }
            else
            {
                btnKaydet.Text = "Kaydet";
            }
        }
    }
}
