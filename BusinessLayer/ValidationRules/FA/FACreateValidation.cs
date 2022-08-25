using BusinessLayer.Features.Commands.FA.CreateFA;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FA
{
    public class FACreateValidation : AbstractValidator<CreateFACommandRequest>
    {
        public FACreateValidation()
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
                .WithMessage("Lütfen değer giriniz..");

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
