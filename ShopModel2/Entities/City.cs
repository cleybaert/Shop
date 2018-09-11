using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Daycare.Data.Entities
{
    public class City
    {
        // primary key
        [Key]
        public int CityId { get; set; }

        public string Name { get; set; }
        public int Code { get; set; }
    }
}
