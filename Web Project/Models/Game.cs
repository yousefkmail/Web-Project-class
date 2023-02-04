using System.ComponentModel.DataAnnotations;
using System;
namespace Web_Project.Models
{
  
    
    public class Game
    {
  

        public int GameId { get; set; }
        [Required(ErrorMessage ="Please pick Release date")]
        public string releaseDate { get; set; }

        [Required(ErrorMessage = "Please Enter the game name")]

        public string name { get; set; }

        [Required(ErrorMessage = "Please insert image link")]

        public string src { get; set; }

        [Required(ErrorMessage = "Please pick Game state")]

        public int GameStateId { get; set; }
        [Required(ErrorMessage = "Please pick Platform")]

        public int PlatformId { get; set; }
        public Platform? Platform { get; set; }

        public GameState? GameState { get; set; }


    }
}
