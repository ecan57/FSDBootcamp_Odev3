using Odev_3API.Models.ViewModels;
using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.Utility.Profile
{
    public class ApplicationProfile : AutoMapper.Profile
    {//2. ApplicationProfile classı oluşturdum. Asıl classlar ile view modeller arasında oluşturulacak olan mapping işlemleri bu classta verildi.
        public ApplicationProfile()
        {
            CreateMap<Ogrenci, OgrenciVM>()
                .ReverseMap();
            CreateMap<Akademisyen, AkademisyenVM>()
                .ReverseMap();
            CreateMap<Ders, DersVM>()
                .ReverseMap();
        }
    }
}
