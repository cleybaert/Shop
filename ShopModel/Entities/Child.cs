using System;
using System.Collections.Generic;
using System.Text;

namespace DaycareModel.Entities
{
    public class Child : IAccount
    {
        private readonly IEventLogger logger;

        public AccountInfo Account { get; set; }
        public bool IsPresent { get; set; }
        public IEnumerable<Principal> Principals { get; set; }        

        public Child(IEventLogger logger)
        {
            this.logger = logger;
        }
    }
}
