namespace PayementSystem.Models
{
    public class PaymentData
    {
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<PaymentTag> PaymentTags { get; set; }
    }
}
