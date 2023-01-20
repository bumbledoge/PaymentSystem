using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace PayementSystem.Models
{
    public class Recipient
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        //legaturi
        public ICollection<Payment> Payments { get; set; }

        public int JobID { get; set; }
        public Job Job { get; set; }
    }
}
