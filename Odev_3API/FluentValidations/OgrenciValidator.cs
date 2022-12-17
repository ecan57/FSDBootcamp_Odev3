using FluentValidation;
using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.FluentValidations
{
    public class OgrenciValidator : AbstractValidator<Ogrenci>
    {
        public OgrenciValidator()
        {
            RuleFor(p => p.OgrenciAd).NotEmpty().WithMessage("Öğrenci adı boş bırakılamaz.");
            RuleFor(p => p.OgrenciSoyad).NotEmpty().WithMessage("Öğrenci soyadı boş bırakılamaz.");
            RuleFor(p => p.OgrenciTC).NotEmpty();
            RuleFor(p => p.Telefon).NotEmpty().NotNull();
        }
    }
    
}
