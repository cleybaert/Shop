using Shop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Data.File.Extensions
{
    public static class ProductExtension
    {
        public static Product Clone(this Product product)
        {
            return new Product()
            {
                Id = product.Id,
                Categories = product.Categories?.ToList(),
                Description = product.Description,
                Name = product.Name,
                Previews = product.Previews?.ToList(),
                Price = product.Price,
                Url = product.Url,
                Tags = new Dictionary<string, IEnumerable<string>>(product.Tags)
            };
        }
        public static bool ContainsTags(this Product product, Dictionary<string, IEnumerable<string>> tags)
        {
            if (product.Tags == null)
                return false;
            foreach (var item in tags.Keys)
            {
                if (item != null)
                {
                    var producttags = (from t in product.Tags where t.Key == item select t).ToList();
                    if (producttags.Count == 0)
                        return false;
                    foreach (var v in tags[item])
                    {
                        if (v != null)
                        {
                            if (!producttags[0].Value.Contains(v))
                                return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
