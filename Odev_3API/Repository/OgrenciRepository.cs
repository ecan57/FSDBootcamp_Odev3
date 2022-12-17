using Bogus;
using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.Repository
{
    public class OgrenciRepository : IOgrenciRepository
    {
        public IEnumerable<Ogrenci> GetOgrencis()
        {
            return FakeData().Generate(50);
        }

        private Faker<Ogrenci> FakeData()
        {
            var fakeOgrenci = new Faker<Ogrenci>()
                .RuleFor(i => i.OgrenciNo, i => i.Random.Number(1000, 99999))
                .RuleFor(i => i.OgrenciAd, i => i.Name.FirstName())
                .RuleFor(i => i.OgrenciSoyad, i => i.Name.LastName())
                .RuleFor(i => i.OgrenciTC, i => i.Random.ULong(100000000000, 99999999999))
                .RuleFor(i => i.DogumTarihi, i => i.Date.Between(new DateTime(1900, 01, 01), new DateTime(2002, 12, 30)))
                .RuleFor(i => i.Telefon, i => i.Phone.PhoneNumber())
                .RuleFor(i => i.EPosta, (x, y) => x.Internet.Email(y.OgrenciAd, y.OgrenciSoyad))
                .RuleFor(i => i.Bolum, i => i.Name.JobTitle())
                .RuleFor(i => i.Sinif, i => i.Random.Number(1, 4))
                .RuleFor(i => i.AktifMi, i => i.Random.Bool());

            return fakeOgrenci;
        }
    }
}
