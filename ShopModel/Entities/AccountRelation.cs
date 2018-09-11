using System;
using System.Collections.Generic;
using System.Text;

namespace DaycareModel.Entities
{
    public class AccountRelation
    {
        public int AccountRelationId { get; set; }
        public AccountInfo AccountA { get; set; }
        public AccountInfo AccountB { get; set; }
        public AccountRelationType AccountRelationType { get; set; }
    }
}
