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
using DevExpress.Charts;

namespace TicariOtomosyon_Uygulama
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        public string Ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblAktifKullanici.Text = Ad;
            gi.ListeleProcedure("SP_MusteriHareketler", gridControl1);
            gi.ListeleProcedure("SP_FirmaHareketler", gridControl4);
            //Toplam Tutar
            SqlCommand komut = new SqlCommand("Select Sum(Tutar) from FaturaDetay", gi.Baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblKasaToplamTutar.Text = dr[0].ToString() + " TL";
            }
            //Son ayın Faturaları
            SqlCommand komut1 = new SqlCommand("select ([Elektrik]+[Su]+[Dogalgaz]+[Internet]+[Maaslar]+[Ekstra]) from Giderler order by Id asc", gi.Baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblOdemeler.Text = dr1[0].ToString() + " TL";
            }
            //Personel Maaşlar
            SqlCommand komut2 = new SqlCommand("select Maaslar from Giderler order by Id asc", gi.Baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblPersonelMaaslar.Text = dr2[0].ToString() + " TL";
            }
            //Müşteri Sayısı
            gi.SayiGetir("Musteriler", lblMusteriSayisi);
            //Firma Sayısı
            gi.SayiGetir("Firmalar", lblFirmaSayisi);
            //Personel Sayısı
            gi.SayiGetir("Personeller", lblPersonelSayisi);
            //Sehir Sayısı
            gi.IlSayiGetir("Musteriler", lblSehirSayisi);
            gi.IlSayiGetir("Firmalar", lblSehirSayisi2);
            gi.SayiGetir("Firmalar", lblFirmaSayisi);
            //ToplamUrunSayisi
            gi.ToplamGetir("Urunler", lblStokSayisi);
            ////Chart Controle Elektrik Faturası Son 4 Ay Listeleme
            //SqlCommand komut3 = new SqlCommand("Select top 4 Tarih,Elektrik from Giderler order by Id desc", gi.Baglanti());
            //SqlDataReader dr3 = komut3.ExecuteReader();
            //while (dr3.Read())
            //{
            //    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr3[0], dr3[1]));
            //}
            //gi.Baglanti().Close();


        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac > 0 && sayac <= 5)
            {
                //Elektrik Faturası Son 4 Ay Listeleme
                groupBox1.Text = "Elektrik";
                SqlCommand komut3 = new SqlCommand("Select top 4 Tarih,Elektrik from Giderler order by Id desc", gi.Baglanti());
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr3[0], dr3[1]));
                }
                gi.Baglanti().Close();
            }
            if (sayac > 5 && sayac <= 10)
            {
                //Su Faturası Son 4 Ay Listeleme
                groupBox1.Text = "Su";
                SqlCommand komut3 = new SqlCommand("Select top 4 Tarih,Su from Giderler order by Id desc", gi.Baglanti());
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    chartControl1.Series["Aylar"].ColorDataMember = "Apex";
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr3[0], dr3[1]));
                }
                gi.Baglanti().Close();
            }
            if (sayac > 10 && sayac <= 15)
            {
                groupBox1.Text = "Doğalgaz";
                //Doğalgaz Faturası Son 4 Ay Listeleme
                SqlCommand komut3 = new SqlCommand("Select top 4 Tarih,Dogalgaz from Giderler order by Id desc", gi.Baglanti());
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr3[0].ToString(), dr3[1]));
                }
                gi.Baglanti().Close();
            }
            if (sayac > 15 && sayac <= 20)
            {
                //İnternet Faturası Son 4 Ay Listeleme
                groupBox1.Text = "İnternet";
                SqlCommand komut3 = new SqlCommand("Select top 4 Tarih,Internet from Giderler order by Id desc", gi.Baglanti());
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr3[0].ToString(), dr3[1]));
                }
                gi.Baglanti().Close();
            }
            if (sayac > 20 && sayac <= 25)
            {
                //Ekstra Faturası Son 4 Ay Listeleme
                groupBox1.Text = "Ekstra";
                SqlCommand komut3 = new SqlCommand("Select top 4 Tarih,Ekstra from Giderler order by Id desc", gi.Baglanti());
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr3[0].ToString(), dr3[1]));
                }
                gi.Baglanti().Close();
            }
            if (sayac == 26)
            {
                sayac = 0;
            }
        }
    }
}
