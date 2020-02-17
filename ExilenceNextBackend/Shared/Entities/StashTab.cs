using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Entities
{
    public class Stashtab
    {
        public string ClientId { get; set; }
        public string StashTabId { get; set; }
        public string Name { get; set; }
        public int TabIndex { get; set; }
        public string Color { get; set; }
        public decimal Value { get; set; }
        public virtual ICollection<PricedItem> PricedItems { get; set; }
        public virtual Snapshot Snapshot { get; set; }
        public virtual int SnapshotId { get; set; }

    }
}
