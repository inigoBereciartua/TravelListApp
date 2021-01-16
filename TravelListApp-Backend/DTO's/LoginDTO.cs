using NJsonSchema.Annotations;
using System.ComponentModel.DataAnnotations;


namespace TravelListApp_Backend.DTO_s
{
    public class LoginDTO
    {
        [Required]
        [NotNull]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
