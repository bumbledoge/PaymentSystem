namespace PayementSystem.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<Recipient> Recipients { get; set; }
        public ICollection<JobTag> JobTags { get; set; }
    }
}
