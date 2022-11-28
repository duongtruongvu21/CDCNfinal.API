using System.ComponentModel.DataAnnotations;

namespace CDCNfinal.API.Data.Entities
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(32)]
        public string Username { get; set; }

        public byte[] PasswordHashed { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}