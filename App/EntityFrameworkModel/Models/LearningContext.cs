using System;
using EntityFrameworkModel.Logger;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkModel.Models
{
    public partial class LearningContext : DbContext
    {
        public LearningContext()
        {
        }

        public LearningContext(DbContextOptions<LearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }

        // Unable to generate entity type for table 'dbo.worldcities'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.City1);

                entity.Property(e => e.City1)
                    .HasColumnName("city")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AdminName)
                    .HasColumnName("admin_name")
                    .IsUnicode(false);

                entity.Property(e => e.Capital)
                    .HasColumnName("capital")
                    .IsUnicode(false);

                entity.Property(e => e.CityAscii)
                    .HasColumnName("city_ascii")
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsUnicode(false);

                entity.Property(e => e.Iso2)
                    .HasColumnName("iso2")
                    .IsUnicode(false);

                entity.Property(e => e.Iso3)
                    .HasColumnName("iso3")
                    .IsUnicode(false);

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .IsUnicode(false);

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .IsUnicode(false);

                entity.Property(e => e.Population)
                    .HasColumnName("population")
                    .IsUnicode(false);
            });
        }
    }
}
