using FluentValidation;
using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Aplication.Validators;

public class CommentUpdateDtoValidator : AbstractValidator<CommentUpdateDto>
{
    public CommentUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id 0 dan katta bo'lishi kerak");

        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Komment matni bo'sh bo'lmasligi kerak")
            .MaximumLength(500).WithMessage("Komment matni 500 ta belgidan oshmasligi kerak");
    }
}
