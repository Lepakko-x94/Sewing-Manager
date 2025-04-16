using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components.Forms;
using SewingManager.UseCases.Materials.Interfaces;

namespace SewingManager.Infrastructure
{
    public class FileStorageService : IFileStorageService
    {
        public async Task<string?> SaveImageAsync(IBrowserFile file, int maxWidth, int maxHeight)
        {
            if (file == null) return null;

            var fileName = Path.GetFileNameWithoutExtension(file.Name);
            var extension = Path.GetExtension(file.Name);
            var uniqueName = $"{fileName}_{Guid.NewGuid():N}{extension}";
            var path = Path.Combine("wwwroot", "images", uniqueName);

            var resized = await file.RequestImageFileAsync(file.ContentType, maxWidth, maxHeight);
            await using var fileStream = File.Create(path);
            await resized.OpenReadStream().CopyToAsync(fileStream);

            return $"/images/{uniqueName}";
        }
    }
}