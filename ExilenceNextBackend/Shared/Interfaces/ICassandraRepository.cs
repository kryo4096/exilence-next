using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ICassandraRepository
    {
        Task AddAccount(Account account);
    }
}
