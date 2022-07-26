﻿using BusinessLayer.Features.Commands.AdminUser.UpdateUser;
using FluentValidation;

namespace BusinessLayer.ValidationRules.UserAdmin
{
    public class UserUpdateValidation : AbstractValidator<UpdateUserCommandRequest>
    {
        public UserUpdateValidation()
        {
            RuleFor(u => u.FirstName)
               .NotEmpty()
               .WithMessage("Lütfen adınızı giriniz...")
               .NotNull()
               .WithMessage("Lütfen adınızı giriniz...")
               .MaximumLength(30)
               .MinimumLength(2)
               .WithMessage("Lütfen girmiş olduğunuz isim 30 ile 2 karakter arasında olmalıdır.");

            RuleFor(u => u.LastName).NotEmpty()
                .WithMessage("Lütfen soyadınızı giriniz...")
                .NotNull()
                .WithMessage("Lütfen soyadınızı giriniz...")
                .MaximumLength(30)
                .MinimumLength(3)
                .WithMessage("Lütfen girmiş olduğunuz soyadınız 30 ile 2 karakter arasında olmalıdır.");

            RuleFor(u => u.Email).NotEmpty()
                .WithMessage("Lütfen email giriniz...")
                .NotNull()
                .WithMessage("Lütfen email giriniz...")
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir email giriniz.");

            RuleFor(u => u.PhoneNumber).NotEmpty()
                .WithMessage("Lütfen telefon numaranızı giriniz...")
                .NotNull()
                .WithMessage("Lütfen telefon numaranızı giriniz...")
                .Length(11)
                .WithMessage("Lütfen 11 karaktere sahip geçerli bir telefon numarası giriniz.");

            RuleFor(u => u.Status)
                .Must(u => u == true || u == false)
                .NotNull()
                .WithMessage("Lütfen bir durum seçiniz...");

            RuleFor(u => u.TCNumber).NotEmpty()
                .WithMessage("Lütfen TC kimilk numarasını giriniz...")
                .NotNull()
                .WithMessage("Lütfen TC kimilk numarasını giriniz...")
                .Length(11)
                .WithMessage("Lütfen 11 karaktere sahip TC kimlik numaranızı giriniz.");

            RuleFor(u => u.UserRole)
                .Must(u => u == true || u == false)
                .NotNull()
                .WithMessage("Lütfen bir rol seçiniz...");

            RuleFor(u => u.HousingStatus)
                .Must(u => u == true || u == false)
                .NotNull()
                .WithMessage("Lütfen bir durum seçiniz...");
        }
    }
}
