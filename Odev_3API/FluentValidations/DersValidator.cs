using FluentValidation;
using Odev3_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev_3API.FluentValidations
{
    public class DersValidator : AbstractValidator<Ders>
    {
        public DersValidator()
        {
            RuleFor(p => p.DersKodu).NotEmpty().WithMessage("Ders kodu boş bırakılamaz.");
            RuleFor(p => p.DersAdi).NotEmpty().WithMessage("Ders adı boş bırakılamaz.");
            RuleFor(p => p.KacSaat).NotEmpty();
            RuleFor(p => p.Kredi).NotEmpty().NotNull();
        }
    }
}
