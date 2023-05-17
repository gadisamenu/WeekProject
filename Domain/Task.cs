namespace Domain
{
    public class Task
    {
        public int Id { get; set; }
        public int Owner { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Completed { get; set; }
    }
   
}