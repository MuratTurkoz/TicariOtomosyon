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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            gi.Listele("Notlar", gridControl1);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Notlar ([Tarih],[Saat],[Baslik],[Detay],[Olusturan],[Hitap]) values (@p1,@p2,@p3,@p4,@p5,@p6)", gi.Baglanti());
            komut.Parameters.AddWithValue("@p1", DateTime.Parse(dateTarih.Text).Date);
            komut.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rchDetay.Text);
            komut.ExecuteNonQuery();
            gi.Listele("Notlar", gridControl1);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            gi.Sil("Notlar", gridView1);
            gi.Listele("Notlar", gridControl1);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Notlar set [Tarih]=@p1,[Saat]=@p2,[Baslik]=@p3,[Detay]=@p4,[Olusturan]=@p5,[Hitap]=@p6 where Id=@p0", gi.Baglanti());
            komut.Parameters.AddWithValue("@p0",gridView1.GetFocusedRowCellValue("Id"));
            komut.Parameters.AddWithValue("@p1", DateTime.Parse(dateTarih.Text).Date);
            komut.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rchDetay.Text);
            komut.ExecuteNonQuery();
            gi.Listele("Notlar", gridControl1);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                dateTarih.Text = DateTime.Parse(dr["Tarih"].ToString()).Date.ToString();
                mskSaat.Text = dr["Saat"].ToString();
                txtOlusturan.Text = dr["Olusturan"].ToString();
                txtHitap.Text = dr["Hitap"].ToString();
                txtBaslik.Text = dr["Baslik"].ToString();
                rchDetay.Text = dr["Detay"].ToString();
            }
        }
    }
}
