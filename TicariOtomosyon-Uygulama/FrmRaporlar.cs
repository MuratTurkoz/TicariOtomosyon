using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomosyon_Uygulama
{
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'DbTicariOtomasyonDataSet3.Personeller' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.PersonellerTableAdapter.Fill(this.DbTicariOtomasyonDataSet3.Personeller);
            // TODO: Bu kod satırı 'DbTicariOtomasyonDataSet3.Giderler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.GiderlerTableAdapter.Fill(this.DbTicariOtomasyonDataSet3.Giderler);
            // TODO: Bu kod satırı 'DbTicariOtomasyonDataSet3.Firmalar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.FirmalarTableAdapter.Fill(this.DbTicariOtomasyonDataSet3.Firmalar);
            // TODO: Bu kod satırı 'DbTicariOtomasyonDataSet3.Musteriler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.MusterilerTableAdapter.Fill(this.DbTicariOtomasyonDataSet3.Musteriler);
            // TODO: Bu kod satırı 'DbTicariOtomasyonDataSet1.Firmalar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.FirmalarTableAdapter.Fill(this.DbTicariOtomasyonDataSet1.Firmalar);
            // TODO: Bu kod satırı 'DbTicariOtomasyonDataSet.Musteriler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.MusterilerTableAdapter.Fill(this.DbTicariOtomasyonDataSet.Musteriler);

            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
        }
    }
}
