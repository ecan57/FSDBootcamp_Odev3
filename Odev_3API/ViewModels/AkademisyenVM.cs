using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.Models.ViewModels
{
    public class AkademisyenVM
    {//1. Auto Mapper kullanımı için öncelikle paketi indirdim. Daha sonra view modellerimi oluşturdum.
        public string AkademisyenAd { get; set; }
        public string AkademisyenSoyad { get; set; }
    }
}
