using BusinessLayer.Features.Commands.FA.UpdateFA;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FA
{
    public class FAUpdateValidation : AbstractValidator<UpdateFACommandRequest>
    {
        public FAUpdateValidation()
        {
            RuleFor(fa => fa.UserId)
                .NotEmpty()
                .NotNull()
                .NotEqual("Seçiniz...")
                .WithMessage("Lütfen bir kullanıcı seçiniz..");

            RuleFor(fa => fa.FAType)
                .NotEmpty()
                .NotNull()
                .NotEqual("Seçiniz...")
                .WithMessage("Lütfen bir fatura tipi seçiniz..");

            RuleFor(fa => fa.Amount)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen değer giriniz..")
                .GreaterThan(0);

            RuleFor(fa => fa.DueDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen tarih giriniz..");

            RuleFor(fa => fa.Status)
                .Must(fa => fa == true || fa == false)
                .NotNull()
                .WithMessage("Lütfen bir durum seçiniz..");
        }
    }
}
