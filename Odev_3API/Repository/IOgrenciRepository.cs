using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.Repository
{
    public interface IOgrenciRepository
    {
        IEnumerable<Ogrenci> GetOgrencis();
    }
}
