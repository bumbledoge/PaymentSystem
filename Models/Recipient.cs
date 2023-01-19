namespace PayementSystem.Models
{
    public class Recipient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        //legaturi
        public ICollection<Payment> Payments { get; set; }
    }
}
