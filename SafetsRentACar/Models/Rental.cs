namespace SafetsRentACar.Models
{
    public class Rental
    {

        public int RentalId { get; set; }

        public int CarId {  get; set; }
     
        public Car Car { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
