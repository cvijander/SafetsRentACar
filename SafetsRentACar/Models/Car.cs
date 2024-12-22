using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetsRentACar.Models
{
    [Table("Car")]
    public class Car
    {

        public enum CarMake
        {
            [Display(Name = "Audi")]
            Audi,
            [Display(Name = "Alfa Romeo")]
            AlfaRomeo,
            [Display(Name = "BMW")]
            BMW,
            [Display(Name = "Nisan")]
            Nissan,
            [Display(Name = "Ford")]
            Ford,
            [Display(Name = "Fiat")]
            Fiat,
            [Display(Name = "Micubisi")]
            Mitsubishi,
            [Display(Name = "Mazda")]
            Mazda,
            [Display(Name = "Kia")]
            Kia,
            [Display(Name = "Hjundai")]
            Hyundai,
            [Display(Name = "Honda")]
            Honda,
            [Display(Name = "Tesla")]
            Tesla,
            [Display(Name = "Tojota")]
            Toyota,
            [Display(Name = "Subaru")]
            Subaru,
            [Display(Name = "Volksvagen")]
            Volkswagen,
            [Display(Name = "Pezo")]
            Peugeot,
            [Display(Name = "Reno")]
            Renaulth,
            [Display(Name = "Volvo")]
            Volvo,
            [Display(Name = "Skoda")]
            Skoda,
            [Display(Name = "Lancia")]
            Lanchia,
            [Display(Name = "Citroen")]
            Citroen,
            [Display(Name = "Seat")]
            Seat,
            [Display(Name = "Bentli")]
            Bentley,
            [Display(Name = "Sab")]
            Saab,
            [Display(Name = "Opel")]
            Opel,
            [Display(Name = "Mini")]
            Mini,
            [Display(Name = "Smart")]
            Smart,
            [Display(Name = "Aston martin")]
            AstonMartin,
            [Display(Name = "Jaguar")]
            Jaguar,
            [Display(Name = "Rover")]
            Rover,
            [Display(Name = "Zastava")]
            Zastava,
            [Display(Name = "Ferari")]
            Ferarri,
            [Display(Name = "Lamburdzini")]
            Lambourgini,




        }

        public enum FuelType
        {
            [Display(Name = "Benzin")]
            Gasoline,
            [Display(Name = "Dizel")]
            Diesel,
            [Display(Name = "Elektro")]
            Electric,
            [Display(Name = "Hibrid")]
            Hybrid,
            [Display(Name = "Plin")]
            Lpg
            
        }

        public enum TransmisionType
        {
            [Display(Name = "Automatski menjac")]
            Automatic,
            [Display(Name = "Manuelni menjac")]
            Manual
        }


        
        public enum DriveType
        {
            [Display(Name = "Prednji pogon")]
            FrontWheel,
            [Display(Name = "Zadnji pogon")]
            RearWheel,
            [Display(Name = "Pogon na sva 4 tocka")]
            AllWheel
        }

        public enum CarType
        {
            [Display(Name = "Limuzina")]
            Sedan,
            [Display(Name = "SUV")]
            SUV,
            [Display(Name = "Kupe")]
            Coupe,
            [Display(Name = "Hecbek")]
            Hatchback,
            [Display(Name = "Miniven")]
            Minivan,
            [Display(Name = "Kamion")]
            Truck,
            [Display(Name = "Pikap")]
            Pickup
        }

        public enum NumberSeats
        {
            [Display(Name = "Dva sedista")]
            Two = 2,
            [Display(Name = "Tri sedista")]
            Three = 3,
            [Display(Name = "Cetiri sedista")]
            Four = 4,
            [Display(Name = "Pet sedista")]
            Five = 5,
            [Display(Name = "Sest sedista")]
            Six = 6,
            [Display(Name = "Sedam sedista")]
            Seven = 7,
            [Display(Name = "Osam sedista")]
            Eight = 8,
            [Display(Name = "Devet i sedista")]
            More = 9
        }

        public enum ColorType
        {
            [Display(Name = "Bela")]
            White,
            [Display(Name = "Crna")]
            Black,
            [Display(Name = "Siva")]
            Gray,
            [Display(Name = "Plava")]
            Blue,
            [Display(Name = "Zuta")]
            Yellow,
            [Display(Name = "Zelena")]
            Green,
            [Display(Name = "Narandzasta")]
            Orange,
            [Display(Name = "Srebrna")]
            Silver,
            [Display(Name = "Crvena")]
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

        
        public string? ImageUrl { get;set; }
        
    
    


    }
}
