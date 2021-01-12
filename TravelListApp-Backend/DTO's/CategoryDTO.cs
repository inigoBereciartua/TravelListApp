using System.ComponentModel.DataAnnotations;
using NJsonSchema.Annotations;
using System.Collections.Generic;

namespace TravelListApp_Backend.DTO_s
{
    public class CategoryDTO
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid integer number")]
        public int id { get; set; }
        [Required]
        [NotNull]
        public string name { get; set; }
    }
}
