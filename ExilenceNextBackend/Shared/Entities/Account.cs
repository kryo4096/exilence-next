using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Entities
{
    public class Account
    {

        public string ClientId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Verified { get; set; }
        public Role Role { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<SnapshotProfile> Profiles { get; set; }
        public string Version { get; set; }
        public DateTimeOffset LastLogin { get; set; }
        public DateTimeOffset Created { get; set; }

    }
}
