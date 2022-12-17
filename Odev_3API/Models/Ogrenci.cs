using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev3_API.Models
{
    public class Ogrenci : BaseModel
    {
        public int OgrenciNo { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public ulong OgrenciTC { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string EPosta { get; set; }
        //public string Adres { get; set; }
        public string Bolum { get; set; }
        public char Sinif { get; set; }
        public bool AktifMi { get; set; }

        public ICollection<Ders> Dersler { get; set; }
    }
}
