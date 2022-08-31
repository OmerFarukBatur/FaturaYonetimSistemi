using BusinessLayer.Features.Commands.Vehicle.UpdateVehicle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Vehicle
{
    public class VehicleUpdateValidation : AbstractValidator<UpdateVehicleCommandRequest>
    {
        public VehicleUpdateValidation()
        {
            RuleFor(v => v.UserId)
               .NotEmpty()
               .NotNull()
               .NotEqual("Seçiniz...")
               .WithMessage("Lütfen bir kullanıcı seçiniz..");

            RuleFor(v => v.PlateNumber)
                .NotEmpty()
                .WithMessage("Lütfen araç plakasını giriniz...")
                .NotNull()
                .WithMessage("Lütfen araç plakasını giriniz...")
                .MaximumLength(9)
                .MinimumLength(5)
                .WithMessage("Lütfen girmiş olduğunuz plaka 5 ile 9 karakter arasında olmalıdır.");

            RuleFor(v => v.VehicleType)
                .NotEmpty()
                .NotNull()
                .NotEqual("Seçiniz...")
                .WithMessage("Lütfen bir araç tipi seçiniz..");

            RuleFor(v => v.Status)
                .Must(v => v == true || v == false)
                .NotNull()
                .WithMessage("Lütfen bir durum seçiniz..");
        }
    }
}
