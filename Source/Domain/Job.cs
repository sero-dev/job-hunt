using System;
using Domain.Contracts;

namespace Domain
{
    public class Job : Document
    {
        public string JobTitle { get; set; }
        public string Employer { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public decimal? MinimumSalary { get; set; }
        public decimal? MaximumSalary { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime DateLastUpdated { get; set; }

        public Amenity Amenities { get; set; }
        public TechnologyStack TechnologyStack { get; set; }
    }
}
