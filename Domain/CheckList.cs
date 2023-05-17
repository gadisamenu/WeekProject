namespace Domain
{
    public class CheckList : BaseClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public bool Completed { get; set; }
    }
}