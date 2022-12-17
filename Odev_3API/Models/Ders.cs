using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev3_API.Models
{
    public class Ders : BaseModel
    {
        public Guid DersId { get; set; }
        public string DersKodu { get; set; }
        public string DersAdi { get; set; }
        public sbyte KacSaat { get; set; }
        public sbyte Kredi { get; set; }
        public char Donem { get; set; }
        //public string Dili { get; set; }
        public string Derslik { get; set; }
        public string Aciklama { get; set; }
        public bool ZorunluMu { get; set; }
        
        public int AkademisyenId { get; set; }
        public Akademisyen Akademisyen { get; set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }
    }
}
