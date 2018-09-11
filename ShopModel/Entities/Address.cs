using System;
using System.Collections.Generic;
using System.Text;

namespace DaycareModel.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int SubNumber { get; set; }
        public City City { get; set; }
    }
}
