using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Daycare.Data.Entities
{
    public class AccountRelation
    {
        public enum AccountRelationType
        {
            Principal,
            Child,
            Caretaker
        }
        
        // primary key
        public int AccountRelationId { get; set; }

        public AccountRelationType RelationType { get; set; }

        // foreign key        
        public int SubjectId { get; set; }
        public int ObjectId { get; set; }

        // navigation property
        public virtual Account Subject { get; set; }
        public virtual Account Object { get; set; }
    }
}
