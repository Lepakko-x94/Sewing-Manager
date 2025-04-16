using System.ComponentModel.DataAnnotations;
using SewingManager.CoreBusiness;
using SewingManager.Webapp.ViewModelsValidations;

namespace SewingManager.Webapp.ViewModels;

public class MaterialViewModel
{
    public int MaterialId { get; set; }

    [Required]
    public string MaterialCode { get; set; }

    [Required]
    public string CategoryId { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [StringLength(3000)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Кількість обов'язкова")]
    [Range(0, double.MaxValue, ErrorMessage = "Кількість має бути більше або \"=\" 0")]
    [Material_QuantityValidationByType]
    public double Quantity { get; set; }

    [Required(ErrorMessage = "Ціна обов'язкова")]
    [Range(0, double.MaxValue, ErrorMessage = "Ціна має бути більше або \"=\" 0")]
    public double Price { get; set; }
    public MaterialType Type { get; set; }

    public string ImageUrl { get; set; }
}