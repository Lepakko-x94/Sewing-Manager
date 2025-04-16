using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewingManager.CoreBusiness
{
    public class MaterialCategory
    {
        public string MaterialCategoryId { get; set; }

        public string Name { get; set; }


        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
