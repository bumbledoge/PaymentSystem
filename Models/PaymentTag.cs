namespace PayementSystem.Models
{
    public class PaymentTag
    {
        public int ID { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
    }
}
