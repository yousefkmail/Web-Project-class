using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Project.Models;

namespace Web_Project.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;
        public GameContext context { get; private set; }    

        public HomeController(ILogger<HomeController> logger , GameContext context)
        {
            _logger = logger;
            this.context = context;
         
        }

        public IActionResult Index(string id)
        {
      
            List<Game> filteredGames = new List<Game>();
            foreach (var game in context.Games.ToList())
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

        public IActionResult Games() {
            ViewData["Games"] = context.Games.ToList();
        return View("GamesDescriptions");
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