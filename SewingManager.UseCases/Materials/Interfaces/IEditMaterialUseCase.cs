using Microsoft.AspNetCore.Components.Forms;
using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces
{
    /// <summary>
    /// Інтерфейс для редагування інформації про матеріал у системі.
    /// </summary>
    public interface IEditMaterialUseCase
    {
        /// <summary>
        /// Виконує операцію редагування існуючого матеріалу в системі.
        /// </summary>
        /// <param name="material">Об'єкт матеріалу, який потрібно оновити.</param>
        /// <param name="file">Файл, що супроводжує матеріал (наприклад, зображення або інший документ), або <c>null</c>, якщо файл не надано.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        /// <remarks>
        /// Цей метод дозволяє редагувати дані матеріалу, а також оновлювати супутні файли, якщо вони надані.
        /// </remarks>
        Task ExecuteAsync(Material material, IBrowserFile? file);
    }
}