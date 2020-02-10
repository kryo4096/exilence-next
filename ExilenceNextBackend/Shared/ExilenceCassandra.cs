using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Shared.Entities;

namespace Shared
{
    public class ExilenceCassandra
    {
        public static ISession Session { get; set; }

        public static async Task InitializeSession(IEnumerable<string> hosts, string username, string password, string keyspace)
        {
            var cluster = Cluster.Builder().WithCredentials(username, password).AddContactPoints(hosts).Build();

            //Session.UserDefinedTypes.Define(UdtMap.For<Account>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Connection>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Group>());
            //Session.UserDefinedTypes.Define(UdtMap.For<SnapshotProfile>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Snapshot>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Stashtab>());
            //Session.UserDefinedTypes.Define(UdtMap.For<PricedItem>());

            Session = await cluster.ConnectAsync(keyspace);

        }
    }
}
