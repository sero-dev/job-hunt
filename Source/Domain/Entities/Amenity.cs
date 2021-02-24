using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Amenity
    {
        public Amenity()
        {
            Jobs = new HashSet<Job>();
        }

        public int AmenitiesId { get; set; }
        public byte IsTemporaryRemote { get; set; }
        public byte IsFullyRemote { get; set; }
        public byte HasAnnualBonus { get; set; }
        public byte Has401Kmatching { get; set; }
        public byte HasHealthInsurance { get; set; }
        public byte HasDentalInsurance { get; set; }
        public byte HasVisionInsurance { get; set; }
        public byte HasPaidTimeOff { get; set; }
        public string Other { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
