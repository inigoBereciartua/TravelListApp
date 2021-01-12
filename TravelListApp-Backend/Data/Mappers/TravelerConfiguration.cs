using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data.Mappers
{
    internal class TravelerConfiguration : IEntityTypeConfiguration<Traveler>
    {
        public void Configure(EntityTypeBuilder<Traveler> builder)
        {
            builder.ToTable("Traveler");
            builder.HasMany(e => e.Travels);
            builder.HasMany(e => e.Category);
        }
    }
}