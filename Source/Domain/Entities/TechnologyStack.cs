using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class TechnologyStack
    {
        public TechnologyStack()
        {
            Jobs = new HashSet<Job>();
        }

        public int TechnologyStackId { get; set; }
        public string FrontEndFramework { get; set; }
        public string BackEndLanguage { get; set; }
        public string DatabaseSystem { get; set; }
        public string CloudService { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
