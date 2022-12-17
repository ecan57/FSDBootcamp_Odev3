using Bogus;
using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.Repository
{
    public class DersRepository : IDersRepository
    {
        public IEnumerable<Ders> GetDerss()
        {
            return FakeData().Generate(25);
        }
        private Faker<Ders> FakeData()
        {
            var fakeDers = new Faker<Ders>()
                .RuleFor(i => i.DersId, i => Guid.NewGuid())
                .RuleFor(i => i.DersKodu, i => i.Random.AlphaNumeric(6))
                .RuleFor(i => i.DersAdi, i => i.Name.JobDescriptor())
                .RuleFor(i => i.KacSaat, i => i.Random.Number(2, 12))
                .RuleFor(i => i.Kredi, i => i.Random.Number(1, 8))
                .RuleFor(i => i.Donem, i => i.Random.Number(1, 8))
                .RuleFor(i => i.Derslik, i => i.Random.AlphaNumeric(4))
                .RuleFor(i => i.Aciklama, i => i.Name.JobDescriptor())
                .RuleFor(i => i.ZorunluMu, i => i.Random.Bool());

            return fakeDers;
        }
    }
}
