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

        private Category ToSimpleCategory(Category value)
        {
            return new Category()
            {
                Description = value.Description,
                Id = value.Id,
                Name = value.Name,
                Parent = null,
                Products = null,
                Subcategories = null
            };
        }       
        
        private Category ToFullCategory(Category value)
        {
            var res = new Category()
            {
                Description = value.Description,
                Id = value.Id,
                Name = value.Name,
                Parent = value.Parent != null ? value.Parent : null,
                Products = null,
                // ToDo: set parent value on subcategories + call ToFullCategory on them
                Subcategories = (value.Subcategories != null) ? value.Subcategories.Select(cat => 
                (
                    cat
                )) : null
            };
        }

        public IEnumerable<Category> GetCategories()
        {
            var res = categories.Select(cat => ToSimpleCategory(cat)).ToList();
            foreach (var cat in categories)
                res.AddRange(cat.Descendants().Select(subcat => ToSimpleCategory(subcat)));
            return res;
        }

        public IEnumerable<Category> GetCategoriesInTree()
        {
            return categories.Select(cat => ToFullCategory(cat));
        }

        public Category GetCategoryById(int id)
        {
            foreach (var item in categories)
            {
                if (item.Id == id)
                    return ToSimpleCategory(item);
                foreach (var subitem in item.Descendants())
                {
                    if (subitem != null)
                    {
                        if (subitem.Id == id)
                            return ToSimpleCategory(subitem);
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

        public Category GetCategoryTreeById(int id)
        {
            foreach (var item in categories)
            {
                if (item.Id == id)
                    return ToFullCategory(item);
                foreach (var subitem in item.Descendants())
                {
                    if (subitem != null)
                    {
                        if (subitem.Id == id)
                            return ToFullCategory(subitem);
                    }
                }
            }
            return null;
        }
    }
}
