using Microsoft.AspNetCore.Http;

public static class MediaHelper
{
    public static async Task<string> SaveFileAsync(IFormFile file, string rootPath)
    {
        var folder = Path.Combine(rootPath, "photos");

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var path = Path.Combine(folder, fileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/photos/{fileName}";
    }
}
