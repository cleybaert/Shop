using Shop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Model.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
    }
}
