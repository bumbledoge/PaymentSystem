namespace PayementSystem.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string TagName { get; set; }

        //legaturi
        public ICollection<PaymentTag>? PaymentTags { get; set; }
    }
}
