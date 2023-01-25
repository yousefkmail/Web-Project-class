using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Project.Models;

namespace Web_Project.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string id)
        {
            List<Game> games = new List<Game>();
            games.Add(new Game("over watch", "201812451", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltba0c762ec1e384bd/6387c01fc72c2b107a6f7db6/wow-dragonflight-rectangle-GC.jpg?format=webply&quality=80&auto=webp", "Pc"));
            games.Add(new Game("over watch", "201812451", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/bltdf9dd58b1d2893d5/6324a79fe337fa0dc7263db4/overwatch2.jpg?format=webply&quality=80&auto=webp", "Pc"));
            games.Add(new Game("over watch", "201812451", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/blt931304c1c6dc6569/6332970fed7dcc6a002802b8/WoTLK_game-card-WoWClassic.jpg?format=webply&quality=80&auto=webp", "Console"));
            games.Add(new Game("over watch", "201812451", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/blt71e1f3ec632b3fe3/61a5156d43af6d102dc88ace/d2.jpg?format=webply&quality=80&auto=webp", "Pc"));
            games.Add(new Game("over watch", "201812451", "https://blz-contentstack-images.akamaized.net/v3/assets/blta8f9a8e092360c6c/blt14732d868dcaaebd/6287cff46eb6de7d054a58c8/diablo-immortal.jpg?format=webply&quality=80&auto=webp", "Pc"));
            ViewData["Games"] = games;
            List<Game> filteredGames = new List<Game>();
            foreach (var game in games)
            {
                if (string.IsNullOrEmpty(id)) {

                    filteredGames.Add(game);


                }

                else if (game.type.ToLower() == id.ToLower()) {

                    filteredGames.Add(game);

                }



            }

            ViewData["Games"] = filteredGames;

            return View();
        }

        public IActionResult Terms_of_services()
        {
            return View();
        }

        public IActionResult About()
        {

            return View("Index");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}