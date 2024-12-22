using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetsRentACar.Models
{
    [Table("User")]
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        
        public string ? Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Address { get; set; }

        


    }
}
