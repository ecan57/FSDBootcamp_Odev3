using Bogus;
using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.Repository
{
    public class AkademisyenRepository : IAkademisyenRepository
    {
        public IEnumerable<Akademisyen> GetAkademisyens()
        {
            return FakeData().Generate(5);
        }
        private Faker<Akademisyen> FakeData()
        {
            var fakeAkademisyen = new Faker<Akademisyen>()
                .RuleFor(i => i.AkademisyenId, i => Guid.NewGuid())
                .RuleFor(i => i.Unvan, i => i.Name.Prefix())
                .RuleFor(i => i.AkademisyenAd, i => i.Name.FirstName())
                .RuleFor(i => i.AkademisyenSoyad, i => i.Name.LastName())
                .RuleFor(i => i.AkademisyenTC, i => i.Random.ULong(100000000000, 99999999999))
                .RuleFor(i => i.DogumTarihi, i => i.Date.Between(new DateTime(1900, 01, 01), new DateTime(2002, 12, 30)))
                .RuleFor(i => i.Telefon, i => i.Phone.PhoneNumber())
                .RuleFor(i => i.EPosta, (x, y) => x.Internet.Email(y.AkademisyenAd, y.AkademisyenSoyad))
                .RuleFor(i => i.AnabilimDali, i => i.Name.JobArea())
                .RuleFor(i => i.AktifMi, i => i.Random.Bool());

            return fakeAkademisyen;
        }
    }
}
