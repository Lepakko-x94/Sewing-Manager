using System.ComponentModel.DataAnnotations;
using SewingManager.CoreBusiness;
using SewingManager.Webapp.ViewModels;

namespace SewingManager.Webapp.ViewModelsValidations
{
    /// <summary>
    /// Атрибут валідації, що перевіряє кількість матеріалу в залежності від його типу.
    /// </summary>
    public class Material_QuantityValidationByTypeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Перевіряє, чи кількість матеріалу є коректною відповідно до типу матеріалу.
        /// </summary>
        /// <param name="value">Значення, яке потрібно перевірити (кількість матеріалу).</param>
        /// <param name="validationContext">Контекст валідації.</param>
        /// <returns>Результат валідації: якщо кількість коректна, повертається <c>ValidationResult.Success</c>, в іншому випадку — повідомлення про помилку.</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as MaterialViewModel;

            if (value != null)
            {
                var quantity = (double)value;

                if (model is not null)
                {
                    if (model.Type == MaterialType.Piece)
                    {
                        if (quantity % 1 != 0)
                        {
                            return new ValidationResult(ErrorMessage);
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}