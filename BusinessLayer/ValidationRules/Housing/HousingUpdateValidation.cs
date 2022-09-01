using BusinessLayer.Features.Commands.Housing.UpdateHousing;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Housing
{
    public class HousingUpdateValidation : AbstractValidator<UpdateHousingCommandRequest>
    {
        public HousingUpdateValidation()
        {
            RuleFor(h => h.UserId)
               .NotEmpty()
               .NotNull()
               .NotEqual("Seçiniz...")
               .WithMessage("Lütfen bir kullanıcı seçiniz..");

            RuleFor(h => h.BlockNumber)
                .NotEmpty()
               .NotNull()
               .NotEqual("Seçiniz...")
               .WithMessage("Lütfen bir blok seçiniz..");

            RuleFor(h => h.HousNumber)
                .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir daire numarası seçiniz..")
               .InclusiveBetween(1, 52);

            RuleFor(h => h.HousType)
               .NotEmpty()
               .NotNull()
               .NotEqual("Seçiniz...")
               .WithMessage("Lütfen bir daire tipi seçiniz..");

            RuleFor(h => h.FloorNumber)
                .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen bir kat numarası seçiniz..")
               .InclusiveBetween(0, 12);


            RuleFor(h => h.Status)
                .Must(h => h == true || h == false)
                .NotNull()
                .WithMessage("Lütfen bir durum seçiniz..");
        }
    }
}
