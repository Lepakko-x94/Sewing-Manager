using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SewingManager.CoreBusiness
{
    /// <summary>
    /// Перелік типів матеріалів.
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        /// Тип матеріалу: Штучний (Piece).
        /// </summary>
        [Display(Name = "Штучний")]
        Piece,

        /// <summary>
        /// Тип матеріалу: Відрізний (Cut).
        /// </summary>
        [Display(Name = "Відрізний")]
        Cut
    }
}