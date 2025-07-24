using AutoAnnouncement.Aplication.Dtos;
using AutoAnnouncement.Aplication.Interfaces;
using AutoAnnouncement.Application.Services.Interfaces;
using AutoAnnouncement.DataAccess.Repositories.Interfaces;
using AutoAnnouncement.Domain.Entities;
using Microsoft.AspNetCore.Hosting;

public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IPhotoService _photoService;
    private readonly IWebHostEnvironment _env;

    public AnnouncementService(
        IAnnouncementRepository announcementRepository,
        IPhotoService photoService,
        IWebHostEnvironment env)
    {
        _announcementRepository = announcementRepository;
        _photoService = photoService;
        _env = env;
    }

    public async Task<long> AddAsync(AnnouncementCreateDto dto)
    {
        // 1. DTO dan Entity yasash
        var announcement = new Announcement
        {
            Title = dto.Title,
            Price = dto.Price,
            Description = dto.Description,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Photos = new List<Photo>() // bo‘sh list, keyin to‘ldiramiz
        };

        // 2. Har bir rasmni serverga saqlaymiz va path ni olamiz
        foreach (var file in dto.Photos)
        {
            var path = await _photoService.AddAsync(file); // bu string path qaytaradi
            var photo = new Photo
            {
                Url = path,
                Announcement = announcement // EF uchun
            };
            announcement.Photos.Add(photo);
        }

        // 3. Endi e'lonni repository orqali bazaga saqlaymiz
        long announcementId = await _announcementRepository.AddAsync(announcement); // MUHIM: Id shu yerda keladi

        return announcementId;
    }


    public async Task UpdateAsync(AnnouncementUpdateDto dto)
    {
        var announcement = await _announcementRepository.GetByIdAsync(dto.Id);
        if (announcement == null)
            throw new Exception("Announcement topilmadi");

        announcement.Title = dto.Title;
        announcement.Price = dto.Price;
        announcement.Description = dto.Description;
        announcement.UpdatedAt = DateTime.UtcNow;

        // Rasmlar bor bo‘lsa, yuklab, ulardan oxirgi URL ni olib, PhotoUrl ga yozamiz
        if (dto.NewPhotos != null && dto.NewPhotos.Count > 0)
        {
            foreach (var file in dto.NewPhotos)
            {
                var path = await _photoService.AddAsync(file); // bu string path qaytaradi
                var photo = new Photo
                {
                    Url = path,
                    Announcement = announcement // EF uchun
                };
                announcement.Photos.Add(photo);
            }
           
           
        }

        // Eng oxirida yangilaymiz – rasm URL endi mavjud
        await _announcementRepository.UpdateAsync(announcement);
    }


    public async Task DeleteAsync(long id)
    {

        await _announcementRepository.DeleteAsync(id);
    }

    public async Task<AnnouncementGetDto> GetByIdAsync(long id)
    {
        var announcement = await _announcementRepository.GetByIdAsync(id);
        if (announcement == null)
            throw new Exception("E'lon topilmadi");

        var photos = await _photoService.GetByAnnouncementIdAsync(id);

        return new AnnouncementGetDto
        {
            Id = announcement.Id,
            Title = announcement.Title,
            Price = announcement.Price,
            Description = announcement.Description,
            CreatedAt = announcement.CreatedAt,
            UpdatedAt = announcement.UpdatedAt,
            UserId = announcement.UserId,
            PhotoPaths = photos.Select(p => p.Url).ToList()
        };
    }


    public async Task<List<AnnouncementGetDto>> GetAllAsync()
    {
        var announcements = await _announcementRepository.GetAllAsync();
        var result = new List<AnnouncementGetDto>();

        foreach (var a in announcements)
        {
            var photos = await _photoService.GetByAnnouncementIdAsync(a.Id);

            result.Add(new AnnouncementGetDto
            {
                Id = a.Id,
                Title = a.Title,
                Price = a.Price,
                Description = a.Description,
                CreatedAt = a.CreatedAt,
                UpdatedAt = a.UpdatedAt,
                UserId = a.UserId,
                PhotoPaths = photos.Select(p => p.Url).ToList()
            });
        }

        return result;
    }

    Task<IEnumerable<AnnouncementGetDto>> IAnnouncementService.GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
