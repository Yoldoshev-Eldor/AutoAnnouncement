using AutoAnnouncement.Aplication.Dtos;
using FluentValidation;

namespace AutoAnnouncement.Aplication.Validators;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ism bo'sh bo'lishi mumkin emas.")
            .MinimumLength(2).WithMessage("Ism kamida 2 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Familiya bo'sh bo'lishi mumkin emas.")
            .MinimumLength(2).WithMessage("Familiya kamida 2 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Foydalanuvchi nomi bo'sh bo'lishi mumkin emas.")
            .MinimumLength(3).WithMessage("Foydalanuvchi nomi kamida 3 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email bo'sh bo'lishi mumkin emas.")
            .EmailAddress().WithMessage("Email formati noto‘g‘ri.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol bo'sh bo'lishi mumkin emas.")
            .MinimumLength(6).WithMessage("Parol kamida 6 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon raqami bo'sh bo'lishi mumkin emas.")
            .Matches(@"^\+998\d{9}$").WithMessage("Telefon raqami +998 bilan boshlanishi va 9 ta raqamdan iborat bo‘lishi kerak.");

        RuleFor(x => x.Role)
            .IsInEnum().WithMessage("Role noto‘g‘ri qiymatga ega.");
    }
}
