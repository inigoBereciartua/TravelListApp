using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data.Mappers
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(e => e.Items)
                .WithMany(e => e.Categories);
            builder.HasMany(e => e.Task)
                .WithMany(e => e.Categories);
            builder.HasMany(e => e.Travel).WithMany(e => e.Categories);
        }
    }
}