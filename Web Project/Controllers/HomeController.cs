using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewData["bool"] = string.IsNullOrEmpty(HttpContext.Session.GetString("uid"));
            var games = context.Games.Include(s => s.GameState).
                Include(s => s.Platform).Where(s=>s.Platform.Name==id);

            var games2 = context.Games.Include(s => s.GameState).
                      Include(s => s.Platform);
            List<Game> filteredGames = new List<Game>();
            if (string.IsNullOrEmpty(id))
            {

                filteredGames = games2.ToList();
            }
            else
            {
                filteredGames = games.ToList();

            }
         
            ViewData["Games"] = filteredGames;

            return View();
        }

        public IActionResult Login() { 
         return View();
        }

        [HttpPost]
        public IActionResult Login([Bind("Name,Password")] Admin admin) {
            if(context.admins.FirstOrDefault(a=>a.Name ==admin.Name && a.Password == admin.Password)!=null)
            {

                HttpContext.Session.SetString("uid" , admin.Name );

                return Redirect("/");

            }
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