using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data.Mappers
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Person");
            builder.Property(e => e.Name);
            builder.Property(e => e.Lastname);
            builder.Property(e => e.Email);
            builder.HasMany(e => e.Travels);
            builder.HasMany(e => e.Category);
        }
    }
}