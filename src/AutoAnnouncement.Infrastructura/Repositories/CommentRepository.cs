using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Domain.Entities;
using AutoAnnouncement.Infrastructura.Persistence;
using Microsoft.EntityFrameworkCore;
using Pinterest.Core.Errors;
using System;

namespace AutoAnnouncement.Infrastructura.Repositories;

public class CommentRepository(MsSqlDbContext _context) : ICommentRepository
{
    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment comment)
    {
        _context.Remove(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAllByPinIdAsync(long pinId)
    {
        return await _context.Comments.Include(x => x.User).ToListAsync();
    }

    public async Task<Comment> GetByIdAsync(long id)
    {
        var comment = await _context.Comments.Include(x => x.User).FirstOrDefaultAsync(c => c.Id == id);

        if (comment is null)
        {
            throw new EntityNotFoundException();
        }
        return comment;
    }
}

