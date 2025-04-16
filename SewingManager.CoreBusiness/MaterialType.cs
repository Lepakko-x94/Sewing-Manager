using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SewingManager.CoreBusiness;

public enum MaterialType
{
    [Display(Name = "Штучний")]
    Piece,

    [Display(Name = "Відрізний")]
    Cut
}