﻿using System.Collections.Generic;

namespace Shop.Model.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Category> Subcategories { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
        public virtual Category Parent { get; set; }
    }
}
