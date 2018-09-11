using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Daycare.Data.Entities
{
    public class Account
    {
        // primary key
        public int AccountId { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<AccountRelation> SubjectRelations { get; set; }
        [InverseProperty("Object")]
        public virtual ICollection<AccountRelation> ObjectRelations { get; set; }

        // foreign key
        public int AddressId { get; set; }        

        // navigation property
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
    }
}
