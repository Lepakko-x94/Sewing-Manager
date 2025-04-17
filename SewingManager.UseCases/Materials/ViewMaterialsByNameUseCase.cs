using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    /// <summary>
    /// Використовуваний випадок для перегляду матеріалів за їх іменем.
    /// </summary>
    public class ViewMaterialsByNameUseCase : IViewMaterialsByNameUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        /// <summary>
        /// Ініціалізує новий випадок для перегляду матеріалів за їх іменем.
        /// </summary>
        /// <param name="materialRepository">Репозиторій для роботи з матеріалами.</param>
        public ViewMaterialsByNameUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// Отримує матеріали за їх іменем.
        /// </summary>
        /// <param name="name">Ім'я матеріалу для фільтрації результатів. Якщо не вказано, повертаються всі матеріали.</param>
        /// <returns>
        /// Завдання, яке повертає колекцію матеріалів, що відповідають вказаному імені.
        /// </returns>
        /// <remarks>
        /// Цей метод дозволяє отримати матеріали, відфільтровані за ім'ям.
        /// Якщо параметр <paramref name="name"/> не вказано або порожній, будуть повернуті всі матеріали.
        /// </remarks>
        public async Task<IEnumerable<Material>> ExecuteAsync(string name = "")
        {
            return await _materialRepository.GetMaterialsByNameAsync(name);
        }
    }
}