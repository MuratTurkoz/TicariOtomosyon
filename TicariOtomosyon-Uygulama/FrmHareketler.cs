using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicariOtomosyon_Uygulama.Islemler;

namespace TicariOtomosyon_Uygulama
{
    public partial class FrmHareketler : Form
    {
        public FrmHareketler()
        {
            InitializeComponent();
        }
        GenelIslemler gi = new GenelIslemler();
        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            gi.ListeleProcedure("Sp_MusteriHareketler",gridControl2);
            gi.ListeleProcedure("Sp_FirmaHareketler", gridControl1);
        }
    }
}
