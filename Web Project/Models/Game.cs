using System.ComponentModel.DataAnnotations;
using System;
namespace Web_Project.Models
{
     
    public enum GameStatus
    {

        Upcoming ,
        EarlyAccess,
        Released

    }
    
    public class Game
    {
  

        public int Id { get; set; }
        public string releaseDate { get; set; }
        public string name { get; set; }
        public string src { get; set; }

        public string type { get; set; }


        public GameStatus GameStatus { get; set; }
        public Game()
        {

        }
    }
}
