using Daycare.DAL;
using Daycare.Data.Entities;
using System;
using System.Collections.Generic;

namespace Daycare.BLL
{
    // implement repository
    // https://code.msdn.microsoft.com/ASPNET-Web-Forms-6c7197aa
    // vs
    // https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implemenation-entity-framework-core
    public class DaycareRepository : IDaycareRepository
    {
        public void DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public void InsertAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
