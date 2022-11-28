using System.ComponentModel.DataAnnotations;

namespace CDCNfinal.API.Data.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}