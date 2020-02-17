using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Entities
{
    public class Group
    {
        public string ClientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Hash { get; set; }
        [Required]
        public string Salt { get; set; }
        public DateTimeOffset Created { get; set; }
        public virtual ICollection<Connection> Connections { get; set; }

    }
}
