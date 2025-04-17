using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces
{
    /// <summary>
    /// Інтерфейс для перегляду матеріалу за його ідентифікатором.
    /// </summary>
    public interface IViewMaterialByIdUseCase
    {
        /// <summary>
        /// Виконує операцію отримання матеріалу за його ідентифікатором.
        /// </summary>
        /// <param name="materialId">Ідентифікатор матеріалу, який потрібно переглянути.</param>
        /// <returns>
        /// Завдання, яке повертає об'єкт матеріалу, якщо матеріал знайдений.
        /// </returns>
        /// <remarks>
        /// Цей метод дозволяє отримати інформацію про конкретний матеріал із системи за його унікальним ідентифікатором.
        /// </remarks>
        Task<Material> ExecuteAsync(int materialId);
    }
}