using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces
{
    /// <summary>
    /// Інтерфейс для перегляду категорій матеріалів за їх ім'ям.
    /// </summary>
    public interface IViewMaterialCategoriesByNameUseCase
    {
        /// <summary>
        /// Виконує операцію отримання категорій матеріалів за їх ім'ям.
        /// </summary>
        /// <param name="name">Ім'я категорії для фільтрації результатів. Якщо не вказано, повертаються всі категорії.</param>
        /// <returns>
        /// Завдання, яке повертає колекцію категорій матеріалів, що відповідають вказаному імені.
        /// </returns>
        /// <remarks>
        /// Цей метод дозволяє отримати категорії матеріалів, відфільтровані за ім'ям.
        /// Якщо параметр <paramref name="name"/> не вказано або порожній, будуть повернуті всі категорії.
        /// </remarks>
        Task<IEnumerable<MaterialCategory>> ExecuteAsync(string name = "");
    }
}