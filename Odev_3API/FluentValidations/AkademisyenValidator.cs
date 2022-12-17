using FluentValidation;
using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.FluentValidations
{
    public class AkademisyenValidator : AbstractValidator<Akademisyen>
    {//Fluent validation kullanımı:
        public AkademisyenValidator()
        {
            RuleFor(p => p.AkademisyenAd).NotEmpty().WithMessage("Akademisyen adı boş bırakılamaz.");
            RuleFor(p => p.AkademisyenSoyad).NotEmpty().WithMessage("Akademisyen soyadı boş bırakılamaz.");
            RuleFor(p => p.AkademisyenTC).NotEmpty();
            RuleFor(p => p.Telefon).NotEmpty().NotNull();
        }
    }
}
