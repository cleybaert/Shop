using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public DaycareIdentityUser User { get; set; }
    }
}
