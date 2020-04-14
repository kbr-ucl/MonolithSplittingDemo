using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Service.Api.Model;
using MvcMovie.Service.Contract.Dtos;
using MvcMovie.Service.Domain;
using MvcMovie.Service.Infrastructure.Database;

namespace MvcMovie.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MovieDto> Get()
        {
            return _movieService.GetAll().Select(a => Mapper.Map(a));
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public MovieDto Get(int id)
        {
            return Mapper.Map(_movieService.Get(id));
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] MovieDto value)
        {
            _movieService.Create(Mapper.Map(value));
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] MovieDto value)
        {
            _movieService.Update(Mapper.Map(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _movieService.Delete(id);
        }
    }
}