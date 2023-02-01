namespace Web_Project.Models
{
    public class GameState
    {
        public int Id { get; set; }

        public string Name { get; set; }


        List<Game> Games { get; } = new();

    }
}
