using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ICassandraRepository
    {
        Task<Account> GetAccount(string name);
        Task AddAccount(Account account);
    }
}
