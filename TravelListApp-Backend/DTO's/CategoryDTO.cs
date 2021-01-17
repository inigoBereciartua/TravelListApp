using System.ComponentModel.DataAnnotations;
using NJsonSchema.Annotations;
using System.Collections.Generic;

namespace TravelListApp_Backend.DTO_s
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Name { get; set; }
    }
}
