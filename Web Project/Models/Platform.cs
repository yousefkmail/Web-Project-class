namespace Web_Project.Models
{
    public class Platform
    {
        public string Name { get; set; }
        public int Id { get; set; }
        List<Game> games { get; } = new ();
    }
}
