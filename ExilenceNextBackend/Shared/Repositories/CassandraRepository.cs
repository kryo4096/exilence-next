using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using Microsoft.Extensions.Configuration;
using Shared.Entities;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class CassandraRepository : ICassandraRepository
    {
        private IConfiguration _configuration;
        private IMapper _mapper;

        public CassandraRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _mapper = new Mapper(ExilenceCassandra.Session);
        }

        public async Task AddAccount(Account account)
        {
            var accounts = new Table<Account>(ExilenceCassandra.Session);
            var result = await accounts.Insert(account).ExecuteAsync();
        }

        public async Task<Account> GetAccount(string name)
        {
            var accounts = new Table<Account>(ExilenceCassandra.Session);
            var account = await accounts.Select(account => account).ExecuteAsync();
            return account.FirstOrDefault();
        }
    }
}
