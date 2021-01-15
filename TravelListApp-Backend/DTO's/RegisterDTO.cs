using NJsonSchema.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.DTO_s
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        [NotNull]
        public string Email { get; set; }
        [Required]
        [NotNull]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
