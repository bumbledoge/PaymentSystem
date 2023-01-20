using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;

namespace PayementSystem.Models
{
    public class Payment
    {
        public int ID { get; set; }
        [Display(Name = "Value")]
        public int Value { get; set; }

        public string Description { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        // legaturi
        public int ?RecipientID { get; set; }
        public Recipient Recipient { get; set; }
        public ICollection<PaymentTag> PaymentTags { get; set; }
    }
}
