namespace SafetsRentACar.Models
{
    public class Service
    {

        public enum ServiceType
        {
            RegularService ,
            OilChange, 
            BrakeRepair,
            EngineCheck,
            FilterReplacement,
            ElectronicRepair,
            TireBalancing,
            TireChange,
            Other

        }

        public enum Mechanic 
        {
            AuthorizedDealer ,
            IndependentMechanic,
            ElectronicsSpecialist,
            EngineSpecialist,
            TireSpecialist,
            Other
        }


        public int ServiceId { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public DateTime ServiceDate { get; set; }

        public ServiceType ServiceT { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public Mechanic MechanicM { get; set; }

        public bool IsWarrantyCovered { get; set; }


    }
}
