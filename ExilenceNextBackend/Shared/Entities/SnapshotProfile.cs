using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Entities
{
    public class SnapshotProfile
    {
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string ActiveLeagueId { get; set; }
        public string ActivePriceLeagueId { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset Created { get; set; }
        public ICollection<string> ActiveStashTabIds { get; set; }
        public virtual ICollection<Snapshot> Snapshots { get; set; }
        public virtual Account Account { get; set; }
    }
}
