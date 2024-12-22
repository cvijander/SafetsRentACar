using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafetsRentACar.Models
{
    [Table("Payment")]
    public class Payment
    {
        public enum PaymentType
        {
            Card, 
            Cash,
            Paypal, 
            Cripto,
            Invoice
        }
        [Required]
        public int PaymentId { get; set; }

        [Required]
        public int RentalId { get;set; }

        public Rental ? Rental { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentType PaymentT { get;set; }

            
    

    }
}
