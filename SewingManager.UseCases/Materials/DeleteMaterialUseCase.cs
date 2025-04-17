using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    /// <summary>
    /// Використовуваний випадок для видалення матеріалу з системи.
    /// </summary>
    public class DeleteMaterialUseCase : IDeleteMaterialUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        /// <summary>
        /// Ініціалізує новий випадок для видалення матеріалу.
        /// </summary>
        /// <param name="materialRepository">Репозиторій для роботи з матеріалами.</param>
        public DeleteMaterialUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// Видаляє матеріал з системи за його ідентифікатором.
        /// </summary>
        /// <param name="materialId">Ідентифікатор матеріалу, який потрібно видалити.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        /// <remarks>
        /// Цей метод видаляє матеріал із системи, використовуючи його унікальний ідентифікатор.
        /// </remarks>
        public async Task ExecuteAsync(int materialId)
        {
            await _materialRepository.DeleteMaterialByIdAsync(materialId);
        }
    }
}