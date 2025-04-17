using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    /// <summary>
    /// Використовуваний випадок для перегляду матеріалу за його ідентифікатором.
    /// </summary>
    public class ViewMaterialByIdUseCase : IViewMaterialByIdUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        /// <summary>
        /// Ініціалізує новий випадок для перегляду матеріалу за його ідентифікатором.
        /// </summary>
        /// <param name="materialRepository">Репозиторій для роботи з матеріалами.</param>
        public ViewMaterialByIdUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// Отримує матеріал за його ідентифікатором.
        /// </summary>
        /// <param name="materialId">Ідентифікатор матеріалу, який потрібно переглянути.</param>
        /// <returns>
        /// Завдання, яке повертає об'єкт матеріалу, якщо матеріал знайдений.
        /// </returns>
        /// <remarks>
        /// Цей метод повертає матеріал з системи, використовуючи його унікальний ідентифікатор.
        /// </remarks>
        public async Task<Material> ExecuteAsync(int materialId)
        {
            return await _materialRepository.GetMaterialByIdAsync(materialId);
        }
    }
}