using Cassandra;
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


    }
}
