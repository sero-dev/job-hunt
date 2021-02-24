using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence
{
    public partial class Job
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int EmployerId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int StatusId { get; set; }
        public decimal? MinimumSalary { get; set; }
        public decimal? MaximumSalary { get; set; }
        public int AmenitiesId { get; set; }
        public int TechnologyStackId { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateLastUpdated { get; set; }

        public virtual Amenity Amenities { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Status Status { get; set; }
        public virtual TechnologyStack TechnologyStack { get; set; }
    }
}
