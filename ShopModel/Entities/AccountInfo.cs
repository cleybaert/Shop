using System;

namespace DaycareModel.Entities
{
    public class AccountInfo
    {
        public int AccountId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Address Address { get; set; }
    }
}
