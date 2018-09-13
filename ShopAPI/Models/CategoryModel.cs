using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<CategoryModel> SubCategories { get; set; }
    }
}
