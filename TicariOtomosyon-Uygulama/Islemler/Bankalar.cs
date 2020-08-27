using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomosyon_Uygulama.Islemler
{
  public  class Bankalar
    {
        public int Id { get; set; }
        public string BankaAdi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Sube { get; set; }
        public int IBAN { get; set; }
        public int HesapNo { get; set; }
        public string Yetkili { get; set; }
        public int Telefon { get; set; }
        public string HesapTuru { get; set; }
        public DateTime Tarih { get; set; }
        public int FirmaId { get; set; }
    }
}
