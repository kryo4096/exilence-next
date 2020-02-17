using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Entities
{
    public class Connection
    {
        public string ConnectionId { get; set; }
        public string InstanceName { get; set; }
        public DateTimeOffset Created { get; set; }
        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }

    }
}
