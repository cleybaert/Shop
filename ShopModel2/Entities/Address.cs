using System;
using System.Collections.Generic;
using System.Text;

namespace Daycare.Data.Entities
{
    public class Address
    {
        // primary key
        public int AddressId { get; set; }

        public string Street { get; set; }
        public int Number { get; set; }
        public int SubNumber { get; set; }

        // foreign keys
        public int CityId { get; set; }

        // navigation property
        public virtual City City { get; set; }
    }
}
