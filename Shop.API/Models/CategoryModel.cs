﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Banner { get; set; }
        public IEnumerable<CategoryModel> SubCategories { get; set; }
    }
}
