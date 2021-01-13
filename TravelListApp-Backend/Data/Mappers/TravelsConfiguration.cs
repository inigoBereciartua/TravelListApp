using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data.Mappers
{
    internal class TravelsConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.ToTable("Travel");
            builder.Property(e => e.Name);
            builder.HasMany(e => e.Iternary).WithOne();
            //builder.HasMany(e => e.Categories).WithMany(e => e.Travel);
        }
    }
}