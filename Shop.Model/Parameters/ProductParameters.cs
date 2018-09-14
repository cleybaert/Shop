using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Model.Parameters
{
    public class ProductParameters
    {
        private const int MaxPageSize = 100;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public int MinPrice { get; set; } = int.MinValue;
        public int MaxPrice { get; set; } = int.MaxValue;

        public int ProductId { get; set; }

        public string Category { get; set; }
        public string OrderBy { get; set; } = "Id";
    }
}
