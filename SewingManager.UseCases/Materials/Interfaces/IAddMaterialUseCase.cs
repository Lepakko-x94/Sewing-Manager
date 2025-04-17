using Microsoft.AspNetCore.Components.Forms;
using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces
{
    /// <summary>
    /// Інтерфейс для додавання нового матеріалу в систему.
    /// </summary>
    public interface IAddMaterialUseCase
    {
        /// <summary>
        /// Виконує операцію додавання нового матеріалу в систему.
        /// </summary>
        /// <param name="material">Об'єкт матеріалу, який потрібно додати.</param>
        /// <param name="file">Файл, що супроводжує матеріал (наприклад, зображення або інший документ), або <c>null</c>, якщо файл не надано.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        /// <remarks>
        /// Цей метод обробляє додавання матеріалу до системи, включаючи можливість додавання супутнього файлу.
        /// </remarks>
        Task ExecuteAsync(Material material, IBrowserFile? file);
    }
}