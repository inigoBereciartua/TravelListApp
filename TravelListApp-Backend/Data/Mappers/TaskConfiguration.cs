using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data.Mappers
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.Property(e => e.Checked);
            builder.Property(e => e.Description);
            builder.HasMany(e => e.Categories).WithMany(e => e.Task);
        }
    }
}