using SafetsRentACar.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SafetsRentACar.ViewModels.User
{
    public class UserViewModel
    {

        public int UserId { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        //[StringLength(50,ErrorMessage ="Ime ne moze imate vise od 50 karaktera.")]
        [StringLengthRangeAttribute(2,50,ErrorMessage="Ime mora da ima izmedju 2 i 50 karaktera")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(50, ErrorMessage ="Prezime ne moze imate vise od 50 karaktera.")]
        [StringLengthRangeAttribute(2, 50, ErrorMessage = "Prezimee mora da ima izmedju 2 i 50 karaktera")]
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
        [PasswordStrengthAttribute(6,50, ErrorMessage = "Lozinka mora imati izmedju 6 i 45 karaktera, da ima i minumum 1 veliko slovo i jedan specijalan karakter")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Potvrda passworda je obavezna")]
        [DataType(DataType.Password)]
        [Compare("PasswordHash",ErrorMessage ="Lozinke se ne podudaraju")]
        public string ConfirmPasswordHash { get; set; }


        [Required(ErrorMessage = "Adresa je obavezna")]
        [StringLength(100,ErrorMessage ="Adresa ne moze imate vise od 100 karaktera")]
        public string Address { get; set; }


    }

    public class StringLengthRangeAttribute : ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _maxLength;
        
        public StringLengthRangeAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value is string stringUsername)
            {
                if((stringUsername.Length < _minLength) || (stringUsername.Length > _maxLength))
                        {
                    return new ValidationResult(ErrorMessage ?? $"Duzina username mora da bude veca od {_minLength}, takodje mora biti i manja od {_maxLength}");

                }
            }

           return ValidationResult.Success;
        }
    }

    public class PasswordStrengthAttribute : ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public PasswordStrengthAttribute(int minLenght, int maxLength)
        {
            _minLength = minLenght;
            _maxLength = maxLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value is string password)
            {
                if(password.Length < _minLength || password.Length > _maxLength)
                {
                    return new ValidationResult(ErrorMessage ?? $"Duzina passworda mora da bude veca od {_minLength}, takodje mora biti i manja od {_maxLength}");
                }

                if(!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
                {
                    return new ValidationResult(ErrorMessage ?? "Password mora da sadrzi barem jedan specijalan karakter");
                }

                if(!Regex.IsMatch(password, @"[A-Z]"))
                {
                    return new ValidationResult(ErrorMessage ?? "Password mora da sadrzi barem jedno veliko slovo");
                }
            }
           return ValidationResult.Success;
        }
    }
}

