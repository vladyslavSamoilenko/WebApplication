using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_projekt.Models.Movies;
using ASP_projekt.Utilities;

namespace ASP_projekt.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesContext _context;

        public MovieController(MoviesContext context)
        {
            _context = context;
            int totalCount = _context.Movies.Count();
        }

        // GET: Movie
        public IActionResult Index(int page = 1, int size = 20)
        {
            var moviesPage = PagingListAsync<Movie>.Create(
                (p, s) => _context.Movies
                    .OrderBy(m => m.Title)
                    .Skip((p - 1) * s)
                    .Take(s)
                    .AsAsyncEnumerable(),
                _context.Movies.Count(),
                page,
                size);

            return View(moviesPage);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Budget,Homepage,Overview,Popularity,ReleaseDate,Revenue,Runtime,MovieStatus,Tagline,VoteAverage,VoteCount")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,Budget,Homepage,Overview,Popularity,ReleaseDate,Revenue,Runtime,MovieStatus,Tagline,VoteAverage,VoteCount")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Movies.Any(e => e.MovieId == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movie =  _context.Movies
                .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Person) 
                .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Gender) 
                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [HttpGet]
        public IActionResult AddToCast(int movieId)
        {
        ViewBag.MovieId = movieId;
        ViewBag.Genders = _context.Genders.ToList();
        ViewBag.Actors = _context.People.ToList();
        Console.WriteLine($"Setting ViewBag.MovieId: {movieId}");
         return View();
        }

    [HttpPost]
    public async Task<IActionResult> AddToCast(int movieId, string characterName, string personName, int genderId, int castOrder)
    {
 
    var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);
        if (movie == null)
        {
            Console.WriteLine($"Received MovieId: {movieId}");
             return NotFound("Film not found.");
             
        }

    
    var person = _context.People.FirstOrDefault(p => p.PersonName == personName);
    if (person == null)
    {
        person = new Person
        {
            PersonName = personName
        };

        _context.People.Add(person);
        await _context.SaveChangesAsync(); 
    }

    
    var existingCast = _context.MovieCasts.FirstOrDefault(mc =>
        mc.MovieId == movieId && mc.PersonId == person.PersonId);

    if (existingCast != null)
    {
        ModelState.AddModelError("", "Actor was added early ");
        ViewBag.MovieId = movieId;
        ViewBag.Genders = _context.Genders.ToList();
        return View();
    }

    
    var castMember = new MovieCast
    {
        MovieId = movieId,
        CharacterName = characterName,
        PersonId = person.PersonId,
        GenderId = genderId,
        CastOrder = castOrder
    };

            
            _context.MovieCasts.Add(castMember);
             await _context.SaveChangesAsync();

            
            return RedirectToAction("Details", new { id = movieId });
        }

    }
    
}
