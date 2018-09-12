using Shop.Model.Entities;
using Shop.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shop.Data.File.Extensions;
using System.Reflection;
using System.Diagnostics;

namespace Shop.Data.File
{
    public class ProductRepository : IProductRepository
    {
        private IQueryable<Product> products;
        private IQueryable<Category> categories;

        public ProductRepository()
        {
            products = new JsonReader<Product>().ReadResource("Shop.Data.File.Data.products.json").AsQueryable();
            categories = new JsonReader<Category>().ReadResource("Shop.Data.File.Data.categories.json").AsQueryable();
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories.AsEnumerable();
        }

        public Category GetCategoryById(int id)
        {
            foreach (var item in categories)
            {
                if (item.Id == id)
                    return item;
                foreach (var subitem in item.Descendants())
                {
                    if (subitem != null)
                    {
                        if (subitem.Id == id)
                            return subitem;
                    }
                }
            }
            return null;
        }

        public Product GetProductById(int id)
        {
            return products.First(item => item.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products.AsEnumerable();
        }
    }
}
