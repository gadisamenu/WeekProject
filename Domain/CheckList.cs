namespace Domain
{
    public class CheckList : BaseClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ETask Task { get; set; }
        public bool Completed { get; set; }

    }
}