using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.DTO_s
{
    public class ActivityDTO
    {
        [Required]
        [NotNull]
        public int TravelId { get; set; }
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Description{get;set;}
        [Required]
        public DateTime Start { get; set; }
                
    }
}
