using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SewingManager.CoreBusiness;

public class Material
{
    public int MaterialId { get; set; }

    [Required]
    public string MaterialCode { get; set; }

    public string CategoryId { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    public string Description { get; set; } = string.Empty;

    [Required]
    public MaterialType Type { get; set; }

    [Required]
    public double Quantity { get; set; }

    [Required]
    public double Price { get; set; }

    public string? ImageUrl { get; set; }

    [JsonIgnore]
    public MaterialCategory MaterialCategory { get; set; }

}