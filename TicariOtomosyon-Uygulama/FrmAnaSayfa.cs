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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            //Stok
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd, Sum(Adet) as 'Adet' from Urunler group by UrunAd having Sum(Adet) < 20 order by Sum(Adet)", gi.Baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
            //Ajanda
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select top 5 Tarih,Saat,Baslik,Detay from Notlar order by Id desc", gi.Baglanti());
            da1.Fill(dt1);
            gridControlAjanda.DataSource = dt1;
            //Hareket
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("exec SP_Son10FirmaHareketler", gi.Baglanti());
            da2.Fill(dt2);
            gridControlHareket.DataSource = dt2;
            //Firma
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select top 5 Tarih,Saat,Baslik,Detay from Notlar order by Id desc", gi.Baglanti());
            da2.Fill(dt3);
            gridControlHareket.DataSource = dt3;
            //Döviz Kurları
            
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            webBrowser2.Navigate("https://news.google.com/topstories?hl=tr&gl=TR&ceid=TR:tr");
        }
    }
}
