namespace Domain
{
    public class Task : BaseClass
    {
        public int Owner { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Completed { get; set; }
    }

}