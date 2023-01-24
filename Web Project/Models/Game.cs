namespace Web_Project.Models
{
    public class Game
    {


        public string releaseDate { get; set; }
        public string name { get; set; }
        public string src { get; set; }

        public string type { get; set; }
        public Game( string name, string releaseDate, string src, string type)
        {
            this.releaseDate = releaseDate;
            this.name = name;
            this.src = src;
            this.type = type;
        }
    }
}
