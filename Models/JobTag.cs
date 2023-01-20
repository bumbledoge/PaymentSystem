namespace PayementSystem.Models
{
    public class JobTag
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public Job Job { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
    }
}
