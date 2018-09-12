using Shop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Model.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        //IEnumerable<Product> GetProductsWithCategories();
        Product GetProductById(int id);
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetCategoriesInTree();
        //IEnumerable<Category> GetCategoriesWithProducts();
        Category GetCategoryById(int id);
        Category GetCategoryTreeById(int id);
    }
}
