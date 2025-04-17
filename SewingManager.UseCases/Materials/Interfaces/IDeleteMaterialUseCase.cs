namespace SewingManager.UseCases.Materials.Interfaces
{
    /// <summary>
    /// Інтерфейс для видалення матеріалу з системи.
    /// </summary>
    public interface IDeleteMaterialUseCase
    {
        /// <summary>
        /// Виконує операцію видалення матеріалу за його ідентифікатором.
        /// </summary>
        /// <param name="materialId">Ідентифікатор матеріалу, який потрібно видалити.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        /// <remarks>
        /// Цей метод забезпечує видалення матеріалу з системи за допомогою наданого ідентифікатора.
        /// </remarks>
        Task ExecuteAsync(int materialId);
    }
}