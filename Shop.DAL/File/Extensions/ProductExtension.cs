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
                AvailableSizes = product.AvailableSizes?.ToList(),
                Categories = product.Categories?.ToList(),
                Description = product.Description,
                Name = product.Name,
                Previews = product.Previews?.ToList(),
                Price = product.Price,
                Url = product.Url
            };
        }
    }
}
