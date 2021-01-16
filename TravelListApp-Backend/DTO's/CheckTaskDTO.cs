using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.DTO_s
{
    public class CheckTaskDTO
    {
        [Required]
        [NotNull]
        public int TravelId { get; set; }
        [Required]
        [NotNull]
        public int TaskId { get; set; }
        [Required]
        [NotNull]
        public bool Completed { get; set; }
    }
}
