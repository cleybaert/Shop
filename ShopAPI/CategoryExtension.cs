using Shop.Data.Entities;
using System.Collections.Generic;

namespace Shop.Extensions
{
    public static class CategoryExtension
    {
        public static IEnumerable<Category> Descendants(this Category category)
        {
            var des = new List<Category>();
            foreach (var item in category.Subcategories)
            {
                des.Add(item);
                des.AddRange(item.Descendants());
            }
            return des;
        }
    }
}
