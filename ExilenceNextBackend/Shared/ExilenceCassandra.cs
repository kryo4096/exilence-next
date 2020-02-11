using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using Shared.Entities;

namespace Shared
{
    public class ExilenceCassandra
    {
        public static ISession Session { get; set; }
        public static IMapper Mapper { get; set; }

        public static async Task InitializeSession(IEnumerable<string> hosts, string username, string password, string keyspace)
        {
            // 1 Build cluster connection
            var cluster = Cluster.Builder().WithCredentials(username, password).AddContactPoints(hosts).Build();

            // 2 Set Mapping configuration
            //SetMappingConfiguration();

            // 3 Create Session
            Session = await cluster.ConnectAsync();

            // 4 Prepare schema
            await Session.ExecuteAsync(new SimpleStatement($"CREATE KEYSPACE IF NOT EXISTS {keyspace} WITH replication = {{ 'class': 'SimpleStrategy', 'replication_factor': '1' }}"));
            await Session.ExecuteAsync(new SimpleStatement($"USE {keyspace}"));
            await Session.ExecuteAsync(new SimpleStatement(@"CREATE TABLE IF NOT EXISTS 
                                                            Accounts(
                                                                Id int, 
                                                                ClientId uuid, 
                                                                Name varchar, 
                                                                Verified boolean, 
                                                                Role int, 
                                                                Version int, 
                                                                LastLogin timestamp, 
                                                                Created timestamp,
                                                            PRIMARY KEY(Id))")).ConfigureAwait(false);
        }

        private static void SetMappingConfiguration()
        {
            MappingConfiguration.Global.Define(
                new Map<Account>()
                .TableName("Accounts")
                .PartitionKey(u => u.Id)
                .Column(u => u.Id, cm => cm.WithName("Id")));

            //Session.UserDefinedTypes.Define(UdtMap.For<Account>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Connection>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Group>());
            //Session.UserDefinedTypes.Define(UdtMap.For<SnapshotProfile>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Snapshot>());
            //Session.UserDefinedTypes.Define(UdtMap.For<Stashtab>());
            //Session.UserDefinedTypes.Define(UdtMap.For<PricedItem>());

        }
    }
}
