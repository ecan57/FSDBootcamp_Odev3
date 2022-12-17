using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev3_API.Models
{
    public class Akademisyen : BaseModel
    {
        public Guid AkademisyenId { get; set; }
        public string Unvan { get; set; }
        public string AkademisyenAd { get; set; }
        public string AkademisyenSoyad { get; set; }
        public ulong AkademisyenTC { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public string EPosta { get; set; }
        //public string Adres { get; set; }
        public string AnabilimDali { get; set; }
        public bool AktifMi { get; set; }

        public ICollection<Ders> Dersler { get; set; }
    }
}
