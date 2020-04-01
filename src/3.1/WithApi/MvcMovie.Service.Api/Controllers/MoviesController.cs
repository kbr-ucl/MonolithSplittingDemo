using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Service.Api.Data;
using MvcMovie.Service.Contract.Dtos;

namespace MvcMovie.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MvcMovieContext _context;

        public MoviesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieDto> Get()
        {
            return _context.Movie.Select(a => Mapper.Map(a));
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public MovieDto Get(int id)
        {
            return Mapper.Map(_context.Movie.Find(id));
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] MovieDto value)
        {
            _context.Movie.Add(Mapper.Map(value));
            _context.SaveChanges();
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MovieDto value)
        {
            _context.Movie.Update(Mapper.Map(value));
            _context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Movie.Remove(_context.Movie.Find(id));
            _context.SaveChanges();
        }
    }
}