namespace Domain
{
    public class ETask : BaseClass
    {
        public User Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }
        public ICollection<CheckList> CheckLists { get; set; }
    }

}