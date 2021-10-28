namespace Luna.Commons.Models
{
    public class ModelBase : AuthorBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}