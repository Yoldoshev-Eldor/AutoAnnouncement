using FluentValidation;
using AutoAnnouncement.Aplication.Dtos;

namespace AutoAnnouncement.Aplication.Validators;

public class CommentCreateDtoValidator : AbstractValidator<CommentCreateDto>
{
    public CommentCreateDtoValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Komment matni bo'sh bo'lmasligi kerak")
            .MaximumLength(500).WithMessage("Komment matni 500 ta belgidan oshmasligi kerak");

        RuleFor(x => x.AnnouncementId)
            .GreaterThan(0).WithMessage("AnnouncementId 0 dan katta bo'lishi kerak");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId 0 dan katta bo'lishi kerak");
    }
}
