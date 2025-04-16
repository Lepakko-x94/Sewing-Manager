using System.ComponentModel.DataAnnotations;
using SewingManager.CoreBusiness;
using SewingManager.Webapp.ViewModels;

namespace SewingManager.Webapp.ViewModelsValidations;

public class Material_QuantityValidationByType : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var model = validationContext.ObjectInstance as MaterialViewModel;
        if (value != null)
        {
            var quantity = (double) value;
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