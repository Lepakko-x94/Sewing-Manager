using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SewingManager.CoreBusiness
{
    /// <summary>
    /// Клас, який представляє матеріал у системі.
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Унікальний ідентифікатор матеріалу.
        /// </summary>
        public int MaterialId { get; set; }

        /// <summary>
        /// Код матеріалу, що є обов'язковим полем для кожного матеріалу.
        /// </summary>
        [Required]
        public string MaterialCode { get; set; }

        /// <summary>
        /// Ідентифікатор категорії матеріалу. За замовчуванням порожній рядок.
        /// </summary>
        public string CategoryId { get; set; } = string.Empty;

        /// <summary>
        /// Назва матеріалу. Це обов'язкове поле з обмеженням довжини до 150 символів.
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// Опис матеріалу. За замовчуванням порожній рядок.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Тип матеріалу. Це обов'язкове поле.
        /// </summary>
        [Required]
        public MaterialType Type { get; set; }

        /// <summary>
        /// Кількість одиниць матеріалу на складі. Це обов'язкове поле.
        /// </summary>
        [Required]
        public double Quantity { get; set; }

        /// <summary>
        /// Ціна за одиницю матеріалу. Це обов'язкове поле.
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// URL зображення матеріалу (якщо є).
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Категорія матеріалу. Цей властивість не серіалізується в JSON.
        /// </summary>
        [JsonIgnore]
        public MaterialCategory MaterialCategory { get; set; }
    }
}
