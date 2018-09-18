using Shop.Model.Entities;
using System.Collections.Generic;

namespace Shop.Data.File.Extensions
{
    public static class CategoryExtension
    {
        public static IEnumerable<Category> Descendants(this Category category, bool selfIncluded = false)
        {
            var des = new List<Category>();
            if (selfIncluded)
                des.Add(category);
            if (category.Subcategories != null)
            {
                foreach (var item in category.Subcategories)
                {
                    if (item != null)
                    {
                        des.Add(item);
                        des.AddRange(item.Descendants());
                    }                    
                }
            }
            return des;
        }

        public static void SetAsParent(this Category category)
        {
            foreach (var item in category.Subcategories)
            {
                item.Parent = category;
                item.SetAsParent();
            }
        }
    }
}
