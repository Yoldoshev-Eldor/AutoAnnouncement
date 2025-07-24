using AutoAnnouncement.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class PhotoService : IPhotoService
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IWebHostEnvironment _env;

    public PhotoService(IPhotoRepository photoRepository, IWebHostEnvironment env)
    {
        _photoRepository = photoRepository;
        _env = env;
    }

    public async Task<string> AddAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Fayl topilmadi");

        string uploadsFolder = Path.Combine(_env.WebRootPath, "photos");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        string url = $"/photos/{uniqueFileName}";
        return url;
    }

    public async Task<List<PhotoGetDto>> GetAllAsync()
    {
        var photos = await _photoRepository.GetAllAsync();
        var result = new List<PhotoGetDto>();
        foreach (var photo in photos)
        {
            result.Add(new PhotoGetDto
            {
                Id = photo.Id,
                Url = photo.Url,
                AnnouncementId = photo.AnnouncementId
            });
        }
        return result;
    }

    public async Task<PhotoGetDto> GetByIdAsync(long id)
    {
        var photo = await _photoRepository.GetByIdAsync(id);
        if (photo == null) throw new Exception("Photo topilmadi");

        return new PhotoGetDto
        {
            Id = photo.Id,
            Url = photo.Url,
            AnnouncementId = photo.AnnouncementId
        };
    }

    public async Task<List<PhotoGetDto>> GetByAnnouncementIdAsync(long announcementId)
    {
        var photos = await _photoRepository.GetByAnnouncementIdAsync(announcementId);
        var result = new List<PhotoGetDto>();
        foreach (var photo in photos)
        {
            result.Add(new PhotoGetDto
            {
                Id = photo.Id,
                Url = photo.Url,
                AnnouncementId = photo.AnnouncementId
            });
        }
        return result;
    }

    public async Task UpdateAsync(PhotoUpdateDto dto)
    {
        var photo = await _photoRepository.GetByIdAsync(dto.Id);
        if (photo == null) throw new Exception("Photo topilmadi");

        // Yangi rasmni yuklash
        var newUrl = await AddAsync(dto.NewImage);

        // Eski faylni o‘chirish
        var oldPath = Path.Combine(_env.WebRootPath, photo.Url.TrimStart('/'));
        if (File.Exists(oldPath)) File.Delete(oldPath);

        // Yangilash
        photo.Url = newUrl;
        await _photoRepository.UpdateAsync(photo);

    }

    public async Task DeleteAsync(long id)
    {
        var photo = await _photoRepository.GetByIdAsync(id);
        if (photo == null) throw new Exception("Photo topilmadi");

        // Faylni o‘chirish
        var filePath = Path.Combine(_env.WebRootPath, photo.Url.TrimStart('/'));
        if (File.Exists(filePath)) File.Delete(filePath);

        await _photoRepository.DeleteAsync(photo.Id);
    
    }
}
