using Daycare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycare.DAL
{
    // a general repository or one repository for every entity?
    // General:
    // https://stackoverflow.com/questions/6887971/single-or-multiple-repository-classes 
    // One for every entity:
    // https://programmingwithmosh.com/entity-framework/common-mistakes-with-the-repository-pattern/
    public interface IDaycareRepository : IDisposable
    {
        IEnumerable<Account> GetAccounts();
        void InsertAccount(Account account);
        void DeleteAccount(Account account);
        void UpdateAccount(Account account);
    }
}
