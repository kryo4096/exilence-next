using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Entities
{
    public class Snapshot
    {
        public string ClientId { get; set; }
        public DateTimeOffset Created { get; set; }
        public virtual ICollection<Stashtab> StashTabs { get; set; }
        public virtual SnapshotProfile Profile { get; set; }
        public virtual int ProfileId { get; set; }

    }
}
