using PagedList;
using Shop.Model.Entities;
using Shop.Model.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Model.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsWithCategories();
        PagedList<Product> GetProducts(ProductParameters param);
        Product GetProductById(int id);
        IEnumerable<Category> GetCategoriesByProductId(int id);
        IEnumerable<Product> GetProductsByCategoryId(int id);
        Category GetCategoryTreeByProductId(int id);
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetFullCategories();
        Category GetCategoryById(int id);
        Category GetFullCategoryById(int id);
    }
}
