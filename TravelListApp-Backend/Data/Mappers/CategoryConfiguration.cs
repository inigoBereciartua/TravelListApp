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
            builder.HasKey(e => e.CategoryID);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(e => e.Items)
                .WithOne(e => e.Categories)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}