using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Status
    {
        public Status()
        {
            Jobs = new HashSet<Job>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
