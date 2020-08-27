using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomosyon_Uygulama.Islemler
{
    public class GenelIslemler
    {
        public SqlConnection Baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-PIAEES2\MURATPC;Initial Catalog=DbTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

        public void Listele(string TabloIsmi, GridControl gridControl)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From " + TabloIsmi + "", Baglanti());
            da.Fill(dt);
            gridControl.DataSource = dt;
            Baglanti().Close();
        }
        public void BenzersizListele(string TabloIsmi, GridControl gridControl)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select distinct * From " + TabloIsmi + "", Baglanti());
            da.Fill(dt);
            gridControl.DataSource = dt;
            Baglanti().Close();
        }
        public void IdGoreListele(int id, string SutunIsmi, string TabloIsmi, GridControl gridControl)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From " + TabloIsmi + " where " + SutunIsmi + "=" + id, Baglanti());
            da.Fill(dt);
            gridControl.DataSource = dt;
            Baglanti().Close();
        }
        public void ListeleProcedure(string procedure, GridControl gridControl)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec " + procedure + "", Baglanti());
            da.Fill(dt);
            gridControl.DataSource = dt;
            Baglanti().Close();
        }
        public void Listele(string SutunIsmi, string TabloIsmi, GridControl gridControl)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select " + SutunIsmi + " From " + TabloIsmi, Baglanti());
            da.Fill(dt);
            gridControl.DataSource = dt;
            Baglanti().Close();
        }
        public void Sil(string TabloIsmi, GridView gridView)
        {
            SqlCommand cm = new SqlCommand("Delete from " + TabloIsmi + " where Id=@p1", Baglanti());
            cm.Parameters.AddWithValue("@p1", gridView.GetFocusedRowCellValue("Id"));
            cm.ExecuteNonQuery();
            Baglanti().Close();
            MessageBox.Show("Ürün Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Sil(string SutunIsmi, string TabloIsmi, GridView gridView)
        {
            SqlCommand cm = new SqlCommand("Delete from " + TabloIsmi + " where " + SutunIsmi + "=@p1", Baglanti());
            cm.Parameters.AddWithValue("@p1", gridView.GetFocusedRowCellValue(SutunIsmi));
            cm.ExecuteNonQuery();
            Baglanti().Close();
            MessageBox.Show("Ürün Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void SutunGetir(string SutunAdi, string TabloAdi, ComboBoxEdit comboBox)
        {
            SqlCommand cm = new SqlCommand("select  * from " + TabloAdi, Baglanti());
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox.Properties.Items.Add(dr[SutunAdi]);
            }
            Baglanti().Close();
        }
        public void UniqSutunGetir(string SutunAdi, string TabloAdi, ComboBoxEdit comboBox)
        {
            SqlCommand cm = new SqlCommand("select distinct " + SutunAdi + " from " + TabloAdi, Baglanti());
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox.Properties.Items.Add(dr[SutunAdi]);
            }
            Baglanti().Close();
        }

        public void IlceGetir(ComboBoxEdit comboBox, ComboBoxEdit comboBox2)
        {
            SqlCommand cm = new SqlCommand("select * from Ilceler where Sehir=@p1", Baglanti());
            cm.Parameters.AddWithValue("@p1", comboBox.SelectedIndex + 1);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Properties.Items.Add(dr["Ilce"]);
            }
            Baglanti().Close();

        }
        public void UniqSutunGetir(string Kolon, string Kolon2, string Tablo, ComboBoxEdit comboBox, ComboBoxEdit comboBox2)
        {
            SqlCommand cm = new SqlCommand("select distinct " + Kolon + " from " + Tablo + " where " + Kolon2 + "= @p1", Baglanti());
            cm.Parameters.AddWithValue("@p1", comboBox.SelectedText.ToString());

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Properties.Items.Add(dr[Kolon]);
            }
            Baglanti().Close();

        }
        public void UniqSutunGetir(string Kolon, string Kolon2, string Tablo, ComboBoxEdit comboBox, ComboBoxEdit comboBox2, ComboBoxEdit comboBox3)
        {
            SqlCommand cm = new SqlCommand("select distinct " + Kolon + " from " + Tablo + " where " + Kolon2 + "= @p1 and UrunAd=@p2", Baglanti());
            cm.Parameters.AddWithValue("@p1", comboBox.SelectedText.ToString());
            cm.Parameters.AddWithValue("@p2", comboBox3.SelectedText.ToString()); ;

            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Properties.Items.Add(dr[Kolon]);
            }
            Baglanti().Close();

        }
        public void UniqSutunGetir1(string Tablo, string Kolon, string Kolon2, LookUpEdit lookUpEdit, ComboBoxEdit comboBox2, ComboBoxEdit comboBox3)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select distinct " + Kolon + ",Id from " + Tablo + " where " + Kolon2 + "=@p1 and UrunAd=@p2", Baglanti());
            da.SelectCommand.Parameters.AddWithValue("@p1", comboBox2.EditValue);
            da.SelectCommand.Parameters.AddWithValue("@p2", comboBox3.EditValue);

            da.Fill(dataSet, "Urunler");
            lookUpEdit.Properties.DisplayMember = "Model";
            lookUpEdit.Properties.ValueMember = "Id";
            lookUpEdit.Properties.DataSource = dataSet.Tables["Urunler"];
            lookUpEdit.Properties.PopulateColumns();
            lookUpEdit.Properties.Columns["Id"].Visible = false;
            Baglanti().Close();

        }
        public void FirmaAdGetir(System.Windows.Forms.ComboBox comboBox)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Firmalar", Baglanti());
            da.Fill(dataSet, "Firmalar");
            comboBox.DisplayMember = "Ad";
            comboBox.ValueMember = "Id";
            comboBox.DataSource = dataSet.Tables["Firmalar"];
            Baglanti().Close();
        }
        public void SayiGetir(string Tabloismi, Label LabelName)
        {
            SqlCommand komut = new SqlCommand("Select Count(Id) from " + Tabloismi, Baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LabelName.Text = dr[0].ToString();
            }
            Baglanti().Close();
        }
        public void IlSayiGetir(string Tabloismi, Label LabelName)
        {
            SqlCommand komut = new SqlCommand("Select Count(Distinct(Il)) from " + Tabloismi, Baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LabelName.Text = dr[0].ToString();
            }
            Baglanti().Close();
        }
        public void ToplamGetir(string Tabloismi, Label LabelName)
        {
            SqlCommand komut = new SqlCommand("Select Sum(Adet) from " + Tabloismi, Baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LabelName.Text = dr[0].ToString();
            }
            Baglanti().Close();
        }
        public void FiyatGetir(string Id, TextEdit textEdit)
        {
            SqlCommand komut = new SqlCommand("Select SatisFiyat from Urunler where Id=" + Id, Baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textEdit.Text = dr["SatisFiyat"].ToString();
            }




            Baglanti().Close();
        }

    }
}


