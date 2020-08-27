using DevExpress.XtraBars.ViewInfo;
using DevExpress.XtraRichEdit.Model;
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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void btnGiris_MouseHover(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.DarkBlue;
        }

        private void btnGiris_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.White;
        }
        public string AktifKullanici;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Adminler where KullaniciAdi=@p1 and Sifre=@p2", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 form1 = new Form1();
                form1.AktifKullanici = txtKullaniciAd.Text;
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı Adı ya da Şifre girdiniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            gi.Baglanti().Close();

        }
    }
}
