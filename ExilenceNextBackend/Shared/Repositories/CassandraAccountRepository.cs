using Cassandra;
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
    class CassandraAccountRepository : IAccountRepository
    {
        private IConfiguration _configuration;
        private Cluster _cluster;
        private ISession _session;

        public CassandraAccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _cluster = Cluster.Builder().AddContactPoints("host1").Build();
            _session = _cluster.Connect("exilence_next");

            MapTypes();
        }

        public Account AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Account> GetAccounts(Expression<Func<Account, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Connection> GetConnections(Expression<Func<Connection, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SnapshotProfile> GetProfiles(Expression<Func<SnapshotProfile, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Account RemoveAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public SnapshotProfile RemoveProfile(SnapshotProfile account)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        private void MapTypes()
        {
            _session.UserDefinedTypes.Define(UdtMap.For<Account>());
            _session.UserDefinedTypes.Define(UdtMap.For<Connection>());
            _session.UserDefinedTypes.Define(UdtMap.For<Group>());
            _session.UserDefinedTypes.Define(UdtMap.For<SnapshotProfile>());
            _session.UserDefinedTypes.Define(UdtMap.For<Snapshot>());
            _session.UserDefinedTypes.Define(UdtMap.For<Stashtab>());
            _session.UserDefinedTypes.Define(UdtMap.For<PricedItem>());
        }
    }
}
