using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using Shared.Entities;

namespace Shared
{
    // https://www.datastax.com/examples?language=86
    // https://docs.datastax.com/en/developer/csharp-driver/3.13/features/datatypes/
    // https://github.com/DataStax-Examples/concurrent-requests-csharp
    // https://github.com/DataStax-Examples/linq-csharp/blob/master/Program.cs
    // https://github.com/DataStax-Examples/object-mapper-csharp/blob/master/Program.cs
    // https://docs.datastax.com/en/dse/6.7/cql/cql/cql_using/useCreateUDT.html

    public class ExilenceCassandra
    {
        public static ISession Session { get; set; }

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
            await CreateDatabaseTables();
        }
        
        private async static void SetMappingConfiguration()
        {
            //MappingConfiguration.Global.Define(
            //    new Map<Account>()
            //    .TableName("Accounts")
            //    .PartitionKey(u => u.Id)
            //    .Column(u => u.Id, cm => cm.WithName("Id")));

            await Session.UserDefinedTypes.DefineAsync(UdtMap.For<Account>());
            await Session.UserDefinedTypes.DefineAsync(UdtMap.For<Connection>());
            await Session.UserDefinedTypes.DefineAsync(UdtMap.For<Group>());
            await Session.UserDefinedTypes.DefineAsync(UdtMap.For<SnapshotProfile>());
            await Session.UserDefinedTypes.DefineAsync(UdtMap.For<Snapshot>());
            await Session.UserDefinedTypes.DefineAsync(UdtMap.For<Stashtab>());
            await Session.UserDefinedTypes.DefineAsync(UdtMap.For<PricedItem>());

        }

        private async static Task CreateDatabaseTables()
        {
            await Session.ExecuteAsync(new SimpleStatement(@"
            CREATE TABLE IF NOT EXISTS 
            Accounts(
                ClientId uuid, 
                Name varchar, 
                Verified boolean, 
                Role int, 
                Version int, 
                LastLogin timestamp, 
                Created timestamp,
            PRIMARY KEY(ClientId))
            "));

            await Session.ExecuteAsync(new SimpleStatement(@"
            CREATE TABLE IF NOT EXISTS 
            Connections(
            ConnectionId varchar,
            InstanceName varchar,
            Created timestamp,
            PRIMARY KEY(ConnectionId))
            ")).ConfigureAwait(false);

            await Session.ExecuteAsync(new SimpleStatement(@"
            CREATE TABLE IF NOT EXISTS 
            Groups(
                ClientId uuid, 
                Name varchar,
                Hash varchar,
                Salt varchar,
                Created timestamp,
            PRIMARY KEY(ClientId))
            ")).ConfigureAwait(false);

            await Session.ExecuteAsync(new SimpleStatement(@"
            CREATE TABLE IF NOT EXISTS 
            SnapshotProfiles(
                ClientId uuid, 

            PRIMARY KEY(ClientId))
            ")).ConfigureAwait(false);

            await Session.ExecuteAsync(new SimpleStatement(@"
            CREATE TABLE IF NOT EXISTS 
            Snapshots(
                ClientId uuid, 
                Created timestamp,
            PRIMARY KEY(ClientId))
            ")).ConfigureAwait(false);

            await Session.ExecuteAsync(new SimpleStatement(@"
            CREATE TABLE IF NOT EXISTS 
            StashTabs(
                ClientId uuid,
                StashTabId varchar,
                Name varchar,
                TabIndex int,
                Color varchar,
                Value decimal,
            PRIMARY KEY(ClientId))
            ")).ConfigureAwait(false);

            await Session.ExecuteAsync(new SimpleStatement(@"
            CREATE TABLE IF NOT EXISTS 
            PricedItems(
                ClientId uuid, 
                ItemId varchar,
                Name varchar,
                FrameType int,
                Calculated decimal,
                Elder boolean,
                Shaper boolean,
                Icon varchar,
                Ilvl int,
                Tier int,
                Corrupted boolean,
                Links int,
                Sockets int,
                Quality int,
                Level int,
                Stacksize int,
                TotalStacksize int,
                Variant varchar,
                Total decimal,
                Max decimal,
                Min decimal,
                Mean decimal,
                Mode decimal,
                Median decimal,
                BaseType varchar,
                Count int,
            PRIMARY KEY(ClientId))
            ")).ConfigureAwait(false);
        }
    }
}
