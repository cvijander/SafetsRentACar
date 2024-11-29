using SafetsRentACar.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace SafetsRentACar.ViewModels.User
{
    public class UserViewModel
    {

        public int UserId { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        //[StringLength(50,ErrorMessage ="Ime ne moze imate vise od 50 karaktera.")]
        [StringLengthRangeAttribute(2, 50, ErrorMessage = "Ime mora da ima izmedju 2 i 50 karaktera")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(50, ErrorMessage = "Prezime ne moze imate vise od 50 karaktera.")]
        [StringLengthRangeAttribute(2, 50, ErrorMessage = "Prezimee mora da ima izmedju 2 i 50 karaktera")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email je obavezan")]
        [EmailAddress(ErrorMessage = "Unesite validnu email adresu ")]
        [DataType(DataType.EmailAddress)]
        [EmailValidationAttribute(ErrorMessage = "Unesite validnu email adresu")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Telefonski broj je  obavezan")]
        [StringLength(15, ErrorMessage = "Telefonski broj ne moze da ima vise od 15 karaktera")]
        [PhoneLengthAttribute(ErrorMessage = "Telefonski broj ne moze da ima vise od 15 karaktera")]
        public string PhoneNumber { get; set; }



        public string Username { get; set; }

        [Required(ErrorMessage = "Password  je obavezan")]
        [DataType(DataType.Password)]
        [StringLength(45, MinimumLength = 6, ErrorMessage = "Lozinka mora imati izmedju 6 i 45 karaktera")]
        [PasswordStrengthAttribute(6, 50, ErrorMessage = "Lozinka mora imati izmedju 6 i 45 karaktera, da ima i minumum 1 veliko slovo i jedan specijalan karakter")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Potvrda passworda je obavezna")]
        [DataType(DataType.Password)]
        [Compare("PasswordHash", ErrorMessage = "Lozinke se ne podudaraju")]
        [PasswordMatchAttribute("PasswordHash", ErrorMessage = "Lozinke se ne poklapaju")]
        public string ConfirmPasswordHash { get; set; }


        [Required(ErrorMessage = "Adresa je obavezna")]
        [StringLength(100, ErrorMessage = "Adresa ne moze imate vise od 100 karaktera")]
        
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
            if (value is string stringUsername)
            {
                if ((stringUsername.Length < _minLength) || (stringUsername.Length > _maxLength))
                {
                    return new ValidationResult(ErrorMessage ?? $"Duzina username mora da bude veca od {_minLength}, takodje mora biti i manja od {_maxLength}");

                }
            }

            return ValidationResult.Success;
        }
    }

    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string email)
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                if (!regex.IsMatch(email))
                {
                    return new ValidationResult(ErrorMessage ?? "Nije ispravno unesem email");
                }
            }
            return ValidationResult.Success;
        }

    }

    public class PhoneLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is string number)
            {
                var regex = new Regex(@"^\+?[0-9]{9,15}$");
                if (!regex.IsMatch(number))
                {
                    return new ValidationResult(ErrorMessage ?? "Niste uneli telefonski broj u duzini do 15 karaktera i moraju da budu iskuljucivo brojevi");
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
                if (value is string password)
                {
                    if (password.Length < _minLength || password.Length > _maxLength)
                    {
                        return new ValidationResult(ErrorMessage ?? $"Duzina passworda mora da bude veca od {_minLength}, takodje mora biti i manja od {_maxLength}");
                    }

                    if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
                    {
                        return new ValidationResult(ErrorMessage ?? "Password mora da sadrzi barem jedan specijalan karakter");
                    }

                    if (!Regex.IsMatch(password, @"[A-Z]"))
                    {
                        return new ValidationResult(ErrorMessage ?? "Password mora da sadrzi barem jedno veliko slovo");
                    }
                }
                return ValidationResult.Success;
            }
    }

    public class PasswordMatchAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public PasswordMatchAttribute(string comparisonProperty) 
            {
              _comparisonProperty = comparisonProperty;
            }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = value as string;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if(property == null )
            {
                return new ValidationResult(ErrorMessage ?? $" Property {_comparisonProperty} ne postoji");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance) as string;

            if(!string.Equals(currentValue, comparisonValue))
            {
                return new ValidationResult(ErrorMessage ?? " Lozinke se ne poklapaju ");
            }

            return ValidationResult.Success;

        }
       
    }


}


