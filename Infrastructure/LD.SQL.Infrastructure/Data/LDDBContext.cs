using LD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LD.SQL.Infrastructure.Data
{
    public class LDDBContext : DbContext
    {
        public LDDBContext(DbContextOptions<LDDBContext> options) : base(options)
        {

        }
        public virtual DbSet<GenericStringsComputations> GenericStringsComputations { get; set; }
        public virtual DbSet<GenericMetaData> GenericMetaData { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }


            modelBuilder.Entity<GenericStringsComputations>(entity =>
            {
                #region commented Codes

                //entity.ToTable("IM_GROUPS_PROFILES", "IM");
                //entity.HasOne(d => d)
                //     .WithMany(p => p.AdAircraft)
                //     .HasForeignKey(d => d.AIRCRAFTTYPE_ID);

                //entity.HasOne(d => d.AircraftFamily)
                //    .WithMany(p => p.AdAircraft)
                //    .HasForeignKey(d => d.AIRCRAFTFAMILY_ID);
                #endregion

            });
        }


    }

    public class ApplicationConfiguration : IEntityTypeConfiguration<GenericStringsComputations>
    {
        public void Configure(EntityTypeBuilder<GenericStringsComputations> builder)
        {

        }
    }
}
