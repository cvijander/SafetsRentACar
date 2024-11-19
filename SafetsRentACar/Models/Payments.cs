namespace SafetsRentACar.Models
{
    public class Payments
    {
        public enum PaymentType
        {
            Card, 
            Cash,
            Paypal, 
            Cripto,
            Invoice
        }

        public int PaymentId { get; set; }

        public int RentalId { get;set; }

        public Rental Rental { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public PaymentType Payment { get;set; }

            
    

    }
}
