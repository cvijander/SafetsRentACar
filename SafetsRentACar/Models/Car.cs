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
        public CarMake Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public decimal PricePerDay { get;set; }
    
        public bool IsAvailable { get; set; }

        public FuelType Fuel { get;set; }

        public TransmisionType Transmision { get; set; }

        public DriveType Drive { get; set; }
        
        public CarType Type { get; set; }

        public ColorType Color { get; set; }

        public NumberSeats Seats { get; set; }
        public int Mileage { get; set; }

        public string VIN { get;set; }
    
        public string LicencePlate { get; set; }

        public string ImageUrl { get;set; }
        
    
    


    }
}
