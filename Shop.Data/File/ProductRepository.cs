using Shop.Model.Entities;
using Shop.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Shop.Data.File.Extensions;
using Shop.Data.File.Entities;
using Shop.Model.Parameters;
using PagedList;

namespace Shop.Data.File
{
    public class ProductRepository : IProductRepository
    {
        private IQueryable<Product> products;
        private IQueryable<Category> categories;
        private IQueryable<Category> categoryTree;
        private IQueryable<ProductCategory> productCategories;

        public ProductRepository()
        {
            products = new JsonReader<Product>().ReadResource("Shop.Data.File.Data.products.json").AsQueryable();
            var categorySource = new JsonReader<Category>().ReadResource("Shop.Data.File.Data.categories.json").AsQueryable();
            productCategories = new JsonReader<ProductCategory>().ReadResource("Shop.Data.File.Data.productcategories.json").AsQueryable();

            // get all categories in one list

            var allcats = categorySource.Select(cat => ToSimpleCategory(cat)).ToList();
            foreach (var cat in categorySource)
                allcats.AddRange(cat.Descendants().Select(subcat => ToSimpleCategory(subcat)));
            categories = allcats.AsQueryable();

            // get all categories in a tree

            allcats = categorySource.ToList();
            foreach (var cat in categorySource)
                allcats.AddRange(cat.Descendants());
            foreach (var cat in allcats)
            {
                var parent = allcats.Find(p => (p.Subcategories == null ? false : p.Subcategories.Contains(cat)));
                cat.Parent = parent ?? null;
                cat.ParentId = parent == null ? -1 : parent.Id;
            }
            categoryTree = allcats.AsQueryable();

        }

        private Category ToSimpleCategory(Category value)
        {
            return new Category()
            {
                Description = value.Description,
                Id = value.Id,
                Name = value.Name,
                Banner = value.Banner,
                Parent = null,
                ParentId = -1,
                Products = null,
                Subcategories = null
            };
        }

        private Category ToFullCategory(Category value, Category parent = null)
        {
            var res = new Category()
            {
                Description = value.Description,
                Id = value.Id,
                Name = value.Name,
                Banner = value.Banner,
                Parent = parent != null ? parent : null,
                ParentId = parent == null ? -1 : parent.Id,
                Products = null,
                // ToDo: set parent value on subcategories + call ToFullCategory on them
                Subcategories = null
            };
            if (value.Subcategories.Count() > 0)
                res.Subcategories = value.Subcategories.Select(cat => ToFullCategory(cat, res));
            return res;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories.ToList();
        }

        public IEnumerable<Category> GetFullCategories()
        {
            return categoryTree.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return categories.FirstOrDefault(cat => cat.Id == id);
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(item => item.Id == id);
        }

        public Category GetFullCategoryById(int id)
        {
            return categoryTree.FirstOrDefault(cat => cat.Id == id);
        }

        public IEnumerable<Category> GetCategoriesByProductId(int id)
        {
            return (from category in categories
                    join link in productCategories on category.Id equals link.CategoryId
                    where link.ProductId == id
                    select category).ToList();
        }

        private Category ToTreeModel(Category parent, Category child)
        {
            return new Category() {
                Description = parent.Description,
                Id = parent.Id,
                Name = parent.Name,
                Banner = parent.Banner,
                Parent = parent.Parent?? null,
                ParentId = parent.Parent == null ? -1 : parent.Parent.Id,
                Products = parent.Products?.ToList(),
                Subcategories = new List<Category>() { child } };
        }

        private Category GetPrevious(int id, bool full)
        {
            var current = full ? GetFullCategoryById(id) : GetCategoryById(id);
            if (current.Parent == null)
                return null;
            else
                return ToTreeModel(current.Parent, current);
        }

        private Category GetPrevious(Category value)
        {
            return value.Parent == null ? null : ToTreeModel(value.Parent, value);
        }

        private Category GetFirst(int id, bool full)
        {
            var prev = GetPrevious(id, full);
            if (prev == null)
                return GetCategoryById(id);
            else
                return GetFirst(prev);
        }

        private Category GetFirst(Category value)
        {
            var prev = GetPrevious(value);
            if (prev == null)
                return value;
            else
                return GetFirst(prev);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            var res = (from product in products
                       join link in productCategories on product.Id equals link.ProductId
                       where link.CategoryId == id
                       select product).ToList();
            var cat = GetFullCategoryById(id);
            if ((cat != null) && (cat.Subcategories != null))
            {
                foreach (var subcat in cat.Subcategories)
                    res.AddRange(GetProductsByCategoryId(subcat.Id));
            }
            return res.AsEnumerable();
        }

        public PagedList<Product> GetProducts(ProductParameters param)
        {
            IQueryable<Product> beforePaging;

            if (param.Category == -1)
                beforePaging = (from product in products
                               where (param.Tags.Count() == 0 ? true : product.ContainsTags(param.Tags))
                               select product).Distinct();
            else
            {
                beforePaging = (from product in products
                                join link in productCategories on product.Id equals link.ProductId
                                join cat1 in categoryTree on link.CategoryId equals cat1.Id
                                join cat2 in categoryTree on cat1.ParentId equals cat2.Id into pc2
                                from subcat2 in pc2.DefaultIfEmpty(new Category() { Name = cat1.Name, ParentId = cat1.Id })
                                join cat3 in categoryTree on subcat2.ParentId equals cat3.Id into pc3
                                from subcat3 in pc3.DefaultIfEmpty(new Category() { Name = cat1.Name, ParentId = cat1.Id })
                                where (((cat1.Id == param.Category)
                                || (subcat2.Id == param.Category)
                                || (subcat3.Id == param.Category))
                                && (param.Tags.Count() == 0 ? true : product.ContainsTags(param.Tags)))
                                select product).Distinct();
            }
            beforePaging = beforePaging.OrderBy(param.OrderBy);

            return new PagedList<Product>(beforePaging, param.PageNumber, param.PageSize);
        }

        public IEnumerable<Category> GetCategoryPath(int id)
        {
            var root = GetFirst(id, true);
            var res = new List<Category>();
            res.Add(root);
            foreach (var item in root.Descendants())
            {
                res.Add(item);
                if (item.Id == id)
                {
                    return res;
                }
            }
            return res;
        }

        public Dictionary<string, IEnumerable<string>> GetTags(string category)
        {
            var dicts = from p in ((from product in products
                                    join link in productCategories on product.Id equals link.ProductId
                                    join cat1 in categoryTree on link.CategoryId equals cat1.Id
                                    join cat2 in categoryTree on cat1.ParentId equals cat2.Id into pc2
                                    from subcat2 in pc2.DefaultIfEmpty(new Category() { Name = cat1.Name, ParentId = cat1.Id })
                                    join cat3 in categoryTree on subcat2.ParentId equals cat3.Id into pc3
                                    from subcat3 in pc3.DefaultIfEmpty(new Category() { Name = cat1.Name, ParentId = cat1.Id })
                                    where (cat1.Name.Equals(category, StringComparison.InvariantCultureIgnoreCase)
                                    || subcat2.Name.Equals(category, StringComparison.InvariantCultureIgnoreCase)
                                    || subcat3.Name.Equals(category, StringComparison.InvariantCultureIgnoreCase))
                                    select product).Distinct())
                        select p.Tags;
            var res = new Dictionary<string, IEnumerable<string>>();
            foreach (var dict in dicts)
            {
                if (dict != null)
                {
                    foreach (var pair in dict)
                    {
                        if (!res.ContainsKey(pair.Key))
                            res[pair.Key] = new HashSet<string>();
                        foreach (var str in pair.Value)
                        {
                            ((HashSet<string>)res[pair.Key]).Add(str);
                        }
                    }
                }
            }
            
            return res;
        }
    }
}
