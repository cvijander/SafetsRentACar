namespace SafetsRentACar.Models
{
    public class Rental
    {

        public int RentalId { get; set; }

        public int CarId {  get; set; }
     
        public Car Car { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
