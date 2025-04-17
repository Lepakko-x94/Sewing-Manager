using Microsoft.AspNetCore.Components.Forms;
using SewingManager.UseCases.Materials.Interfaces;

namespace SewingManager.Infrastructure
{
    /// <summary>
    /// Сервіс для збереження зображень на файловій системі сервера.
    /// </summary>
    public class FileStorageService : IFileStorageService
    {
        /// <summary>
        /// Зберігає завантажене зображення на сервері після його зміни розміру відповідно до заданих параметрів.
        /// </summary>
        /// <param name="file">Завантажений файл зображення з браузера.</param>
        /// <param name="maxWidth">Максимальна ширина для зміненого зображення.</param>
        /// <param name="maxHeight">Максимальна висота для зміненого зображення.</param>
        /// <returns>
        /// Відносна URL-адреса до збереженого зображення (наприклад, "/images/унікальне-ім'я.jpg"),
        /// або <c>null</c>, якщо файл є <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Цей метод генерує унікальне ім'я для файлу, щоб уникнути перезапису існуючих файлів.
        /// Файл зберігається в директорії "wwwroot/images".
        /// </remarks>
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