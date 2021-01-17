using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.DTO_s
{
    public class CategoryItemDTO
    {
        [Required]
        [NotNull]
        public int CategorylId { get; set; }
        [Required]
        [NotNull]
        public int ItemId { get; set; }
    }
}
