using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Project.Models;

namespace Web_Project.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameContext _context;

        public GamesController(GameContext context)
        {
            _context = context;
        }

       

        // GET: Games
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("uid")))
                return RedirectToAction("Login", "Home");
            var gameContext = _context.Games.Include(g => g.GameState).Include(g => g.Platform);
            return View(await gameContext.ToListAsync());
        }

        // GET: Games/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("uid")))
                return RedirectToAction("Login", "Home");
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.GameState)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create

        public IActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("uid")))
                return RedirectToAction("Login", "Home");
            ViewData["GameState"] = new SelectList(_context.gameStates, "Id", "Name");
            ViewData["Platform"] = new SelectList(_context.Platforms, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("GameId,releaseDate,name,src,GameStateId,PlatformId")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameState"] = new SelectList(_context.gameStates, "Id", "Name");
            ViewData["Platform"] = new SelectList(_context.Platforms, "Id", "Name");
            return View(game);
        }

        public IActionResult Game(int? id) {
          Game? game =  _context.Games.FirstOrDefault(a => a.GameId == id);
            if(game == null)
            
                return Redirect("/");

            
        return View(game);
        
        }

    
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            if (_context.Games == null)
            {
                return Problem("Entity set 'GameContext.Games'  is null.");
            }
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
            }
            
            await _context.SaveChangesAsync();
            return Redirect("/");
        }

        private bool GameExists(int id)
        {
          return (_context.Games?.Any(e => e.GameId == id)).GetValueOrDefault();
        }
    }
}
