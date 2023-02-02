using System.ComponentModel.DataAnnotations;
using System;
namespace Web_Project.Models
{
  
    
    public class Game
    {
  

        public int GameId { get; set; }
        public string releaseDate { get; set; }
        public string name { get; set; }
        public string src { get; set; }
        public int GameStateId { get; set; }

        public int PlatformId { get; set; }
        public Platform? Platform { get; set; }

        public GameState? GameState { get; set; }


    }
}
