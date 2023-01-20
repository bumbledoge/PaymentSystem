namespace PayementSystem.Models
{
    public class JobData
    {
        public IEnumerable<Job> Jobs { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<JobTag> JobTags { get; set; }
    }
}
