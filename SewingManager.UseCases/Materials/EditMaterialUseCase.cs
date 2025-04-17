using Microsoft.AspNetCore.Components.Forms;
using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    /// <summary>
    /// Використовується для редагування матеріалів, включаючи оновлення зображень.
    /// </summary>
    public class EditMaterialUseCase : IEditMaterialUseCase
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IFileStorageService _fileStorageService;

        /// <summary>
        /// Ініціалізує новий екземпляр класу EditMaterialUseCase.
        /// </summary>
        /// <param name="materialRepository">Репозиторій для роботи з матеріалами.</param>
        /// <param name="fileStorageService">Сервіс для збереження зображень.</param>
        public EditMaterialUseCase(IMaterialRepository materialRepository, IFileStorageService fileStorageService)
        {
            _materialRepository = materialRepository;
            _fileStorageService = fileStorageService;
        }

        /// <summary>
        /// Оновлює матеріал у репозиторії та, за наявності, зберігає нове зображення.
        /// </summary>
        /// <param name="material">Модель матеріалу з оновленими даними.</param>
        /// <param name="file">Файл зображення для збереження (може бути null).</param>
        /// <returns>Завдання, що завершується після оновлення матеріалу.</returns>
        /// <example>
        /// var material = new Material { MaterialId = 1, Name = "Бавовна оновлена" };
        /// var file = await GetFileFromInput(); // Отримати файл із Blazor InputFile
        /// await editMaterialUseCase.ExecuteAsync(material, file);
        /// </example>
        public async Task ExecuteAsync(Material material, IBrowserFile? file)
        {
            if (file != null)
            {
                material.ImageUrl = await _fileStorageService.SaveImageAsync(file, 1024, 1024);
            }

            await _materialRepository.UpdateMaterialAsync(material);
        }
    }
}
