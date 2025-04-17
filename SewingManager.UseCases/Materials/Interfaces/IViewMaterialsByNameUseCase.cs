using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces
{
    /// <summary>
    /// Інтерфейс для перегляду матеріалів за їх іменем.
    /// </summary>
    public interface IViewMaterialsByNameUseCase
    {
        /// <summary>
        /// Виконує операцію отримання матеріалів за їх іменем.
        /// </summary>
        /// <param name="name">Ім'я матеріалу для фільтрації результатів. Якщо не вказано, повертаються всі матеріали.</param>
        /// <returns>
        /// Завдання, яке повертає колекцію матеріалів, що відповідають вказаному імені.
        /// </returns>
        /// <remarks>
        /// Цей метод дозволяє отримати матеріали, відфільтровані за ім'ям.
        /// Якщо параметр <paramref name="name"/> не вказано або порожній, будуть повернуті всі матеріали.
        /// </remarks>
        Task<IEnumerable<Material>> ExecuteAsync(string name = "");
    }
}