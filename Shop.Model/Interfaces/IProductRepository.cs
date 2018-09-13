﻿using Shop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Model.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsWithCategories();
        Product GetProductById(int id);
        IEnumerable<Category> GetCategoriesByProductId(int id);
        IEnumerable<Product> GetProductsByCategoryId(int id);
        IEnumerable<Category> GetFullCategoriesByProductId(int id);
        IEnumerable<Category> GetCategories();
        IEnumerable<Category> GetFullCategories();
        Category GetCategoryById(int id);
        Category GetFullCategoryById(int id);
    }
}
