using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.DTO;
using MoviesApi.Helper;
using MoviesApi.Models;
using MoviesApi.Repos;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly Repos.IGnericREPOSITORY<Movie> gnericREPOSITORY;
        private readonly IMoviesInterface movierepo;

        public MoviesController(ApplicationDbContext dbContext, IMapper mapper, IGnericREPOSITORY<Movie> gnericREPOSITORY, IMoviesInterface Movierepo)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.gnericREPOSITORY = gnericREPOSITORY;
            movierepo = Movierepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var get = await dbContext.movies.Include(m => m.genras).Select(m => new MOvieDetailedDTO
            {
                GenraId = m.GenraId,
                GenraName = m.genras.GenraName,
                MovieName = m.MovieName,
                Poster = m.Poster,
                Rate = m.Rate,
                StoryLine = m.StoryLine,
                Title = m.Title
            }).ToListAsync();
            return Ok(get);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var f = await gnericREPOSITORY.GetById(id);
            if (f is not null)
            {

                var get = await dbContext.movies.Include(m => m.genras).Select(m => new MOvieDetailedDTO
                {
                    GenraId = m.GenraId,
                    GenraName = m.genras.GenraName,
                    MovieName = m.MovieName,
                    Poster = m.Poster,
                    Rate = m.Rate,
                    StoryLine = m.StoryLine,
                    Title = m.Title
                }).ToListAsync();


                return Ok(get);

            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] MovieModelDto dto)
        {

            if (dto is not null)
            {
                var mapped = mapper.Map<MovieModelDto, Movie>(dto);
                mapped.Poster = DocumentSetting.UploadFile(dto.formFile, "Images");
                await gnericREPOSITORY.addAsync(mapped);
                return Ok(mapped);
            }
            return NotFound();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            if (Id > 0)
            {

                var movie=dbContext.movies.Find(Id);
                gnericREPOSITORY.Delete(movie);
                return Ok(movie);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,[FromForm]ToupdateDto dTO)
        {
            
            var mapped = mapper.Map<ToupdateDto,Movie>(dTO);
            mapped.ID = id;
            if (mapped is not null)
            {
                gnericREPOSITORY.UpdateAsync(mapped);
                return Ok(mapped);
            }
            return NotFound();
        }
        
    }
}

   
