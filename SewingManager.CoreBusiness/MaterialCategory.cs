using System;
using System.Collections.Generic;

namespace SewingManager.CoreBusiness
{
    /// <summary>
    /// Клас, який представляє категорію матеріалу в системі.
    /// </summary>
    public class MaterialCategory
    {
        /// <summary>
        /// Унікальний ідентифікатор категорії матеріалу.
        /// </summary>
        public string MaterialCategoryId { get; set; }

        /// <summary>
        /// Назва категорії матеріалу.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Колекція матеріалів, що належать до цієї категорії.
        /// </summary>
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}