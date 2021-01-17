using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.DTO_s
{
    public class ItemDTO
    {
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Name { get; set; }
    }
}
