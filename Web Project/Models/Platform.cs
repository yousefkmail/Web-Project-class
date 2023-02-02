namespace Web_Project.Models
{
    public class Platform
    {
        public string? Name { get; set; }
        public int Id { get; set; }
     public   List<Game> Games { get; } = new ();
    }
}
