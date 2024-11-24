using System.ComponentModel.DataAnnotations;

namespace SafetsRentACar.ViewModels.User
{
    public class UserViewModel
    {

        public int UserId { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(50,ErrorMessage ="Ime ne moze imate vise od 50 karaktera.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(50, ErrorMessage ="Prezime ne moze imate vise od 50 karaktera.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email je obavezan")]
        [EmailAddress(ErrorMessage ="Unesite validnu email adresu ")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "Telefonski broj je  obavezan")]
        [StringLength(15, ErrorMessage ="Telefonski broj ne moze da ima vise od 15 karaktera")]
        public string PhoneNumber { get; set; }


        
        public string Username { get; set; }

        [Required(ErrorMessage = "Password  je obavezan")]
        [DataType(DataType.Password)]
        [StringLength(45,MinimumLength = 6, ErrorMessage = "Lozinka mora imati izmedju 6 i 45 karaktera")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Potvrda passworda je obavezna")]
        [DataType(DataType.Password)]
        [Compare("PasswordHash",ErrorMessage ="Lozinke se ne podudaraju")]
        public string ConfirmPasswordHash { get; set; }


        [Required(ErrorMessage = "Adresa je obavezna")]
        [StringLength(100,ErrorMessage ="Adresa ne moze imate vise od 100 karaktera")]
        public string Address { get; set; }


    }
}
