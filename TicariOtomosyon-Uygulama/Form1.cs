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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FrmUrunler fm;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fm == null || fm.IsDisposed)
            {
                fm = new FrmUrunler();
                fm.MdiParent = this;
                fm.Show();
            }
        }
        FrmMusteriler FrmMusteriler;
        private void btnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmMusteriler == null || FrmMusteriler.IsDisposed)
            {
                FrmMusteriler = new FrmMusteriler();
                FrmMusteriler.MdiParent = this;
                FrmMusteriler.Show();
            }
        }

        FrmFirmalar FrmFirmalar;
        private void btnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmFirmalar == null || FrmFirmalar.IsDisposed)
            {
                FrmFirmalar = new FrmFirmalar();
                FrmFirmalar.MdiParent = this;
                FrmFirmalar.Show();
            }
        }
        FrmPersoneller FrmPersoneller;
        private void btnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmPersoneller == null || FrmPersoneller.IsDisposed)
            {
                FrmPersoneller = new FrmPersoneller();
                FrmPersoneller.MdiParent = this;
                FrmPersoneller.Show();
            }
        }
        FrmRehber FrmRehber;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmRehber == null || FrmRehber.IsDisposed)
            {
                FrmRehber = new FrmRehber();
                FrmRehber.MdiParent = this;
                FrmRehber.Show();
            }
        }
        FrmGiderler FrmGiderler;
        private void btnGideler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmGiderler == null || FrmGiderler.IsDisposed)
            {
                FrmGiderler = new FrmGiderler();
                FrmGiderler.MdiParent = this;
                FrmGiderler.Show();
            }
        }
        FrmBankalar FrmBankalar;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmBankalar == null || FrmBankalar.IsDisposed)
            {
                FrmBankalar = new FrmBankalar();
                FrmBankalar.MdiParent = this;
                FrmBankalar.Show();
            }
        }
        FrmFaturalar FrmFaturalar;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmFaturalar == null || FrmFaturalar.IsDisposed)
            {
                FrmFaturalar = new FrmFaturalar();
                FrmFaturalar.MdiParent = this;
                FrmFaturalar.Show();
            }
        }
        FrmNotlar FrmNotlar;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmNotlar == null || FrmNotlar.IsDisposed)
            {
                FrmNotlar = new FrmNotlar();
                FrmNotlar.MdiParent = this;
                FrmNotlar.Show();
            }
        }
        FrmHareketler frmHareketler;
        private void btnHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmHareketler == null || frmHareketler.IsDisposed)
            {
                frmHareketler = new FrmHareketler();
                frmHareketler.MdiParent = this;
                frmHareketler.Show();
            }
        }
        FrmRaporlar FrmRaporlar;
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FrmRaporlar == null || FrmRaporlar.IsDisposed)
            {
                FrmRaporlar = new FrmRaporlar();
                FrmRaporlar.MdiParent = this;
                FrmRaporlar.Show();
            }
        }
        FrmStoklar f12;
        private void btnStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f12 == null || f12.IsDisposed)
            {
                f12 = new FrmStoklar();
                f12.MdiParent = this;
                f12.Show();
            }
        }
        FrmAyarlar f13;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f13 == null || f13.IsDisposed)
            {
                f13 = new FrmAyarlar();
                f13.Show();
            }
        }
        FrmKasa f14;
        public string AktifKullanici;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f14 == null || f14.IsDisposed)
            {
                f14 = new FrmKasa();
                f14.Ad = AktifKullanici;
                f14.Show();
            }
        }
        FrmAnaSayfa f15;
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f15 == null || f15.IsDisposed)
            {
                f15 = new FrmAnaSayfa();
                f15.MdiParent = this;
                f15.Show();
            }
        }
    }
}
