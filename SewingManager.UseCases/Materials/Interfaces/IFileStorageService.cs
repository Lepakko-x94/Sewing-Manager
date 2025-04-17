using Microsoft.AspNetCore.Components.Forms;

namespace SewingManager.UseCases.Materials.Interfaces
{
    /// <summary>
    /// Інтерфейс для зберігання файлів на сервері.
    /// </summary>
    public interface IFileStorageService
    {
        /// <summary>
        /// Зберігає зображення на сервері після його зміни розміру до заданих розмірів.
        /// </summary>
        /// <param name="file">Завантажене зображення з браузера.</param>
        /// <param name="maxWidth">Максимальна ширина для зміненої картинки.</param>
        /// <param name="maxHeight">Максимальна висота для зміненої картинки.</param>
        /// <returns>
        /// Відносна URL-адреса збереженого зображення (наприклад, "/images/унікальне-ім'я.jpg"), 
        /// або <c>null</c>, якщо файл є <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Цей метод зберігає файл з унікальним ім'ям у директорії для зображень на сервері.
        /// </remarks>
        Task<string?> SaveImageAsync(IBrowserFile file, int maxWidth, int maxHeight);
    }
}