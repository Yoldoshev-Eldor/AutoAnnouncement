using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Aplication.Validators;
using AutoAnnouncement.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace AutoAnnouncement.Aplication.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;

    }

    public async Task<long> CreateAsync(CommentCreateDto dto)
    {
        var validator = new CommentCreateDtoValidator();
        ValidationResult result = await validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var comment = new Comment
        {
            Text = dto.Text,
            AnnouncementId = dto.AnnouncementId,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow
        };

        await _commentRepository.AddAsync(comment);
        return comment.Id;
    }

    public async Task DeleteAsync(long id)
    {
        await _commentRepository.DeleteAsync(id);

    }

    public async Task<IEnumerable<CommentGetDto>> GetAllByAnnouncementIdAsync(long announcementId)
    {
        var comments = await _commentRepository.GetByAnnouncementIdAsync(announcementId);
        return comments.Select(c => new CommentGetDto
        {
            Id = c.Id,
            Text = c.Text,
            CreatedAt = c.CreatedAt,
            UserId = c.UserId,
            AnnouncementId = c.AnnouncementId
        });
    }

    public async Task<CommentGetDto> GetByIdAsync(long id)
    {
        var comment = await _commentRepository.GetByIdAsync(id)
            ?? throw new Exception("Comment not found");

        return new CommentGetDto
        {
            Id = comment.Id,
            Text = comment.Text,
            CreatedAt = comment.CreatedAt,
            UserId = comment.UserId,
            AnnouncementId = comment.AnnouncementId
        };
    }

    public async Task UpdateAsync(CommentUpdateDto dto)
    {
        var validator = new CommentUpdateDtoValidator();
        ValidationResult result = await validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var comment = await _commentRepository.GetByIdAsync(dto.Id)
            ?? throw new Exception("Comment not found");

        comment.Text = dto.Text;

        await _commentRepository.UpdateAsync(comment);
    }
}
