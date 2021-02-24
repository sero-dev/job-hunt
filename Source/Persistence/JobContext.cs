using System;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Persistence
{
    public partial class JobContext : DbContext, IJobContext
    {
        public JobContext()
        {
        }

        public JobContext(DbContextOptions<JobContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amenity> Amenities { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<TechnologyStack> TechnologyStacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenity>(entity =>
            {
                entity.HasKey(e => e.AmenitiesId)
                    .HasName("PRIMARY");

                entity.Property(e => e.Has401Kmatching).HasColumnName("Has401KMatching");

                entity.Property(e => e.Other)
                    .IsRequired()
                    .HasMaxLength(280);
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("Employer");

                entity.HasIndex(e => e.Name, "Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.HasIndex(e => e.AmenitiesId, "FkJob_AmenitiesId_idx");

                entity.HasIndex(e => e.EmployerId, "FkJob_EmployerId_idx");

                entity.HasIndex(e => e.StatusId, "FkJob_StatusId_idx");

                entity.HasIndex(e => e.TechnologyStackId, "FkJob_TechnologyStackId_idx");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.DateLastUpdated).HasColumnType("date");

                entity.Property(e => e.DateSubmitted).HasColumnType("date");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.MaximumSalary).HasColumnType("decimal(9,2)");

                entity.Property(e => e.MinimumSalary).HasColumnType("decimal(9,2)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.Amenities)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.AmenitiesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkJob_AmenitiesId");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkJob_EmployerId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkJob_StatusId");

                entity.HasOne(d => d.TechnologyStack)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.TechnologyStackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkJob_TechnologyStackId");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.HasIndex(e => e.Description, "Description_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.StatusId, "StatusId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<TechnologyStack>(entity =>
            {
                entity.ToTable("TechnologyStack");

                entity.Property(e => e.BackEndLanguage).HasMaxLength(45);

                entity.Property(e => e.CloudService).HasMaxLength(45);

                entity.Property(e => e.DatabaseSystem).HasMaxLength(45);

                entity.Property(e => e.FrontEndFramework).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
