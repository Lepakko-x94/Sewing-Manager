using Microsoft.AspNetCore.Components.Forms;
using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    /// <summary>
    /// Використовуваний випадок для додавання нового матеріалу до системи.
    /// </summary>
    public class AddMaterialUseCase : IAddMaterialUseCase
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IFileStorageService _fileStorageService;

        /// <summary>
        /// Ініціалізує новий випадок додавання матеріалу.
        /// </summary>
        /// <param name="materialRepository">Репозиторій для роботи з матеріалами.</param>
        /// <param name="fileStorageService">Сервіс для зберігання файлів.</param>
        public AddMaterialUseCase(IMaterialRepository materialRepository, IFileStorageService fileStorageService)
        {
            _materialRepository = materialRepository;
            _fileStorageService = fileStorageService;
        }

        /// <summary>
        /// Додає новий матеріал до системи.
        /// </summary>
        /// <param name="material">Об'єкт матеріалу, який потрібно додати.</param>
        /// <param name="file">Файл, що супроводжує матеріал (наприклад, зображення або інший документ), або <c>null</c>, якщо файл не надано.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        /// <remarks>
        /// Цей метод додає новий матеріал до системи. Якщо файл надано, то він зберігається за допомогою сервісу
        /// зберігання файлів, і його URL записується в об'єкт матеріалу.
        /// </remarks>
        public async Task ExecuteAsync(Material material, IBrowserFile? file)
        {
            if (file != null)
            {
                material.ImageUrl = await _fileStorageService.SaveImageAsync(file, 1024, 1024);
            }

            await _materialRepository.AddMaterialAsync(material);
        }
    }
}
