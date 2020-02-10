using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace Shared
{
    public class ExilenceCassandra
    {
        public static ISession Session { get; set; }

        public static async Task InitializeSession(IEnumerable<string> hosts, string keyspace)
        {
            var cluster = Cluster.Builder().AddContactPoints(hosts).Build();
            Session = await cluster.ConnectAsync(keyspace);

        }
    }
}
