using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Service.Contract.Services;
using MvcMovie.Ui.Mvc.Models;

namespace MvcMovie.Ui.Mvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            // Hent data
            var moviesDtos = await _movieService.GetMoviesAsync().ConfigureAwait(false);
            return View(Mapper.Map(moviesDtos));
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _movieService.GetMovieAsync(id.Value).ConfigureAwait(false);

            if (movie == null) return NotFound();

            return View(Mapper.Map(movie));
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View(new MovieViewModel
            {
                Genre = "Action",
                Price = 1.99M,
                ReleaseDate = DateTime.Now,
                Title = "Conan"
            });
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")]
            MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(Mapper.Map(movie)).ConfigureAwait(false);

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _movieService.GetMovieAsync(id.Value).ConfigureAwait(false);
            if (movie == null) return NotFound();
            return View(Mapper.Map(movie));
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,RowVersion")]
            MovieViewModel movie)
        {
            if (id != movie.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _movieService.UpdateAsync(id, Mapper.Map(movie)).ConfigureAwait(false);
                }
                catch (DBConcurrencyException e)
                {
                    ModelState.AddModelError("", "Data er blevet opdateret af andre i mellemtiden");
                    return View(movie);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var movie = await _movieService.GetMovieAsync(id.Value).ConfigureAwait(false);
            if (movie == null) return NotFound();

            return View(Mapper.Map(movie));
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.RemoveAsync(id).ConfigureAwait(false);

            return RedirectToAction(nameof(Index));
        }
    }
}