using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Common.Interfaces
{
    public interface IJobContext
    {
        DbSet<Amenity> Amenities { get; set; }
        DbSet<Employer> Employers { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<TechnologyStack> TechnologyStacks { get; set; }
    }
}
