using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.PluginInterfaces
{
    /// <summary>
    /// Репозиторій для роботи з матеріалами.
    /// </summary>
    public interface IMaterialRepository
    {
        /// <summary>
        /// Отримує матеріали за їх іменем.
        /// </summary>
        /// <param name="name">Ім'я матеріалу для фільтрації результатів. Якщо не вказано, повертаються всі матеріали.</param>
        /// <returns>
        /// Завдання, яке повертає колекцію матеріалів, що відповідають вказаному імені.
        /// </returns>
        Task<IEnumerable<Material>> GetMaterialsByNameAsync(string name);

        /// <summary>
        /// Видаляє матеріал за його ідентифікатором.
        /// </summary>
        /// <param name="materialId">Ідентифікатор матеріалу, який потрібно видалити.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        Task DeleteMaterialByIdAsync(int materialId);

        /// <summary>
        /// Додає новий матеріал.
        /// </summary>
        /// <param name="material">Об'єкт матеріалу, який потрібно додати.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        Task AddMaterialAsync(Material material);

        /// <summary>
        /// Отримує категорії матеріалів за їх іменем.
        /// </summary>
        /// <param name="name">Ім'я категорії для фільтрації результатів. Якщо не вказано, повертаються всі категорії.</param>
        /// <returns>
        /// Завдання, яке повертає колекцію категорій матеріалів, що відповідають вказаному імені.
        /// </returns>
        Task<IEnumerable<MaterialCategory>> GetMaterialCategoriesByNameUseCase(string name);

        /// <summary>
        /// Отримує матеріал за його ідентифікатором.
        /// </summary>
        /// <param name="materialId">Ідентифікатор матеріалу, який потрібно переглянути.</param>
        /// <returns>
        /// Завдання, яке повертає матеріал за вказаним ідентифікатором.
        /// </returns>
        Task<Material> GetMaterialByIdAsync(int materialId);

        /// <summary>
        /// Оновлює існуючий матеріал.
        /// </summary>
        /// <param name="material">Об'єкт матеріалу з оновленими даними.</param>
        /// <returns>
        /// Завдання, яке виконується асинхронно.
        /// </returns>
        Task UpdateMaterialAsync(Material material);
    }
}
