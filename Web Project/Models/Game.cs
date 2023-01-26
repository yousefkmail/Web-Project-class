using System.ComponentModel.DataAnnotations;

namespace Web_Project.Models
{

    
    public class Game
    {
        

        public int Id { get; set; }

        public string releaseDate { get; set; }
        public string name { get; set; }
        public string src { get; set; }

        public string type { get; set; }
        public Game(string name, string releaseDate, string src, string type , int Id)
        {
            this.releaseDate = releaseDate;
            this.name = name;
            this.src = src;
            this.type = type;
            this.Id = Id;
        }

        public Game()
        {
            this.releaseDate ="0/0";
            this.name = "None";
            this.src = "";
            this.type = "Pc";
        }
    }
}
