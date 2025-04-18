﻿using SewingManager.CoreBusiness;
using SewingManager.UseCases.PluginInterfaces;
using System.Diagnostics;
using System.Drawing;
using System.IO.Pipelines;
using System.Xml.Linq;

namespace SewingManger.Plugins.InMemory
{
    /// <summary>
    /// Репозиторій для управління матеріалами та їх категоріями в пам'яті.
    /// </summary>
    public class MaterialRepository : IMaterialRepository
    {
        private readonly List<MaterialCategory> _categories;
        private readonly List<Material> _materials;

        /// <summary>
        /// Ініціалізує новий екземпляр репозиторію з попередньо визначеними категоріями та матеріалами.
        /// </summary>
        public MaterialRepository()
        {
            _categories = new List<MaterialCategory>
            {
                new MaterialCategory { MaterialCategoryId = "1", Name = "Тканини" },
                new MaterialCategory { MaterialCategoryId = "2", Name = "Фурнітура" },
                new MaterialCategory { MaterialCategoryId = "3", Name = "Підкладкові матеріали" }
            };

            _materials = new List<Material>
            {
                new Material
                {
                    MaterialId = 1,
                    MaterialCode = "1",
                    CategoryId = "1",
                    Name = "Бавовна біла",
                    Description = "100% бавовна, використовується для сорочок.",
                    Type = MaterialType.Cut,
                    Quantity = 1000,
                    Price = 5.50,
                    MaterialCategory = _categories.First(c => c.MaterialCategoryId == "1"),
                    ImageUrl = "/images/2.jpg"
                },
                new Material
                {
                    MaterialId = 2,
                    MaterialCode = "2",
                    CategoryId = "2",
                    Name = "Блискавка 20см",
                    Description = "Металева блискавка чорного кольору.",
                    Type = MaterialType.Piece,
                    Quantity = 500,
                    Price = 0.80,
                    MaterialCategory = _categories.First(c => c.MaterialCategoryId == "2"),
                    ImageUrl = "/images/3.jpg"
                },
                new Material
                {
                    MaterialId = 3,
                    MaterialCode = "3",
                    CategoryId = "3",
                    Name = "Підкладка нейлонова",
                    Description = "Тонка нейлонова тканина для підкладки курток.",
                    Type = MaterialType.Cut,
                    Quantity = 500,
                    Price = 3.20,
                    MaterialCategory = _categories.First(c => c.MaterialCategoryId == "3"),
                    ImageUrl = "/images/1.jpg"
                }
            };

            foreach (var category in _categories)
            {
                category.Materials = _materials
                    .Where(m => m.CategoryId == category.MaterialCategoryId)
                    .ToList();
            }
        }

        /// <summary>
        /// Отримує список матеріалів за назвою.
        /// </summary>
        /// <param name="name">Назва матеріалу для пошуку (чутливість до регістру ігнорується).</param>
        /// <returns>Список матеріалів, що відповідають критерію пошуку.</returns>
        /// <example>
        /// var materials = await repository.GetMaterialsByNameAsync("Бавовна");
        /// foreach (var material in materials) { Console.WriteLine(material.Name); }
        /// </example>
        public async Task<IEnumerable<Material>> GetMaterialsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_materials);

            return _materials.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public Task DeleteMaterialByIdAsync(int materialId)
        {
            var material = _materials.FirstOrDefault(x => x.MaterialId == materialId);
            if (material is not null)
            {
                _materials.Remove(material);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Додає новий матеріал до репозиторію.
        /// </summary>
        /// <param name="material">Модель матеріалу для додавання.</param>
        /// <returns>Завдання, що завершується після додавання.</returns>
        /// <example>
        /// var material = new Material { Name = "Шовк", Type = MaterialType.Cut };
        /// await repository.AddMaterialAsync(material);
        /// </example>
        public Task AddMaterialAsync(Material material)
        {
            if (_materials.Any(x => x.Name.Equals(material.Name, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var maxId = _materials.Max(x => x.MaterialId);

            material.MaterialId = maxId + 1;
            _materials.Add(material);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<MaterialCategory>> GetMaterialCategoriesByNameUseCase(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_categories);

            return _categories.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Material> GetMaterialByIdAsync(int materialId)
        {
            var material = _materials.FirstOrDefault(x => x.MaterialId == materialId);
            var tempMaterial = new Material
            {
                MaterialId = material!.MaterialId,
                MaterialCode = material.MaterialCode,
                CategoryId = material.CategoryId,
                Name = material.Name,
                Description = material.Description,
                Type = material.Type,
                Quantity = material.Quantity,
                Price = material.Price,
                ImageUrl = material.ImageUrl
            };

            return await Task.FromResult(tempMaterial);
        }

        /// <summary>
        /// Оновлює дані існуючого матеріалу.
        /// </summary>
        /// <param name="material">Модель матеріалу з оновленими даними.</param>
        /// <returns>Завдання, що завершується після оновлення.</returns>
        /// <example>
        /// var material = await repository.GetMaterialByIdAsync(1);
        /// material.Quantity = 2000;
        /// await repository.UpdateMaterialAsync(material);
        /// </example>
        public Task UpdateMaterialAsync(Material material)
        {
            if (_materials.Any(x => x.MaterialId != material.MaterialId &&
                                      x.Name.Equals(material.Name, StringComparison.OrdinalIgnoreCase)))
                return Task.CompletedTask;

            var invToUpdate = _materials.FirstOrDefault(x => x.MaterialId == material.MaterialId);
            if (invToUpdate is not null)
            {
                invToUpdate.MaterialCode = material.MaterialCode;
                invToUpdate.CategoryId = material.CategoryId;
                invToUpdate.Name = material.Name;
                invToUpdate.Description = material.Description;
                invToUpdate.Type = material.Type;
                invToUpdate.Quantity = material.Quantity;
                invToUpdate.Price = material.Price;
                invToUpdate.ImageUrl = material.ImageUrl;
            }

            return Task.CompletedTask;
        }
    }
}