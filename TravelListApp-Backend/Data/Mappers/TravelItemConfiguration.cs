using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data
{
    internal class TravelItemConfiguration : IEntityTypeConfiguration<TravelItem>
    {
        public void Configure(EntityTypeBuilder<TravelItem> builder)
        {
            builder.Property(e => e.Checked);
            builder.Property(e => e.Count);
            builder.HasOne(e => e.Item).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Travel).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}