using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;

namespace TravelListApp_Backend.Data.Mappers
{
    public class TravelTaskConfiguration : IEntityTypeConfiguration<TravelTask>
    {
        public void Configure(EntityTypeBuilder<TravelTask> builder)
        {
            builder.Property(e => e.Checked);
            builder.HasOne(e => e.Task).WithMany().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Travel).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
