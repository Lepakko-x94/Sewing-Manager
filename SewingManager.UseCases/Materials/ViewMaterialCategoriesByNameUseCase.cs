using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    /// <summary>
    /// Використовуваний випадок для перегляду категорій матеріалів за їх ім'ям.
    /// </summary>
    public class ViewMaterialCategoriesByNameUseCase : IViewMaterialCategoriesByNameUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        /// <summary>
        /// Ініціалізує новий випадок для перегляду категорій матеріалів за їх ім'ям.
        /// </summary>
        /// <param name="materialRepository">Репозиторій для роботи з категоріями матеріалів.</param>
        public ViewMaterialCategoriesByNameUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// Отримує категорії матеріалів за їх іменем.
        /// </summary>
        /// <param name="name">Ім'я категорії для фільтрації результатів. Якщо не вказано, повертаються всі категорії.</param>
        /// <returns>
        /// Завдання, яке повертає колекцію категорій матеріалів, що відповідають вказаному імені.
        /// </returns>
        /// <remarks>
        /// Цей метод дозволяє отримати категорії матеріалів, відфільтровані за ім'ям.
        /// Якщо параметр <paramref name="name"/> не вказано або порожній, будуть повернуті всі категорії.
        /// </remarks>
        public async Task<IEnumerable<MaterialCategory>> ExecuteAsync(string name = "")
        {
            return await _materialRepository.GetMaterialCategoriesByNameUseCase(name);
        }
    }
}