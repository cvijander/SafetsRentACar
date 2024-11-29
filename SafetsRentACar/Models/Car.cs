using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SafetsRentACar.Models
{
    public class Car
    {
        public enum CarMake
        {
            Audi,
            BMW,
            Nissan,
            Ford,
            Mitsubishi,
            Mazda,
            Honda,
            Tesla,
            Toyota,
            Subaru,
            Volkswagen
        }

        public enum FuelType
        {
            Gasoline,
            Diesel,
            Electric,
            Hybrid,
            Lpg
            
        }

        public enum TransmisionType
        {
            Automatic,
            Manual
        }


        
        public enum DriveType
        {
            [Description("Prednji pogon")]
            FrontWheel,
            RearWheel,
            AllWheel
        }

        public enum CarType
        {
            Sedan,
            SUV,
            Coupe,
            Hatchback,
            Minivan,
            Truck,
            Pickup
        }

        public enum NumberSeats
        {
            Two = 2,
            Five = 5,
            Seven = 7,
            Eight = 8,
            More = 9
        }

        public enum ColorType
        {
            White,
            Black,
            Gray,
            Blue,
            Yellow,
            Green,
            Orange,
            Silver,
            Red,


        }

        public int CarId { get; set; }

        [Required]
        public CarMake Make { get; set; }

        [Required]
        [StringLength(50,ErrorMessage = "Model ne moze imati vise od 50 karaktera.")]
        public string Model { get; set; }

        [Required]
        [Range(1900,2024,ErrorMessage = "Godiste mora biti u ovom rasponu")]
        public int Year { get; set; }

        [Required]
        [Range(1,5000, ErrorMessage = "Cena po danu mora biti u rasponu od 1 do 5000")]
        public decimal PricePerDay { get;set; }
    

        public bool IsAvailable { get; set; }

        [Required]
        public FuelType Fuel { get;set; }

        [Required]
        public TransmisionType Transmision { get; set; }

        [Required]
        public DriveType Drive { get; set; }

        [Required]
        public CarType Type { get; set; }

        [Required]
        public ColorType Color { get; set; }

        [Required]
        public NumberSeats Seats { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        [Required]
        [StringLength(17,MinimumLength = 17)]
        public string VIN { get;set; }
    
        [Required]
        [StringLength(15)]
        public string LicencePlate { get; set; }

        [Url]
        public string ImageUrl { get;set; }
        
    
    


    }
}
