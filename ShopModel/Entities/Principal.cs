using System;
using System.Collections.Generic;
using System.Text;

namespace DaycareModel.Entities
{
    public class Principal : IAccount
    {
        public AccountInfo Account { get; set; }
        public IEnumerable<Child> Children { get; set; }        
    }
}
