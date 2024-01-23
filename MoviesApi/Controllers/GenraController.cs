using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.DTO;
using MoviesApi.Models;
using MoviesApi.Repos;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenraController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly Repos.IGnericREPOSITORY<Genras> gnericREPOSITORY;

        public GenraController(IMapper mapper,IGnericREPOSITORY<Genras> gnericREPOSITORY)
        {
            this.mapper = mapper;
            this.gnericREPOSITORY = gnericREPOSITORY;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var get= await gnericREPOSITORY.GetAllTasksAsync();
            return Ok(get);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(GenraModelDto dto)
        {
            var genras= new Genras()
            {
                GenraName = dto.GenraName

            };
          
            await gnericREPOSITORY.addAsync(genras);
            return Ok(genras);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,GenraModelDto dto)
        {
            var mapped = mapper.Map<GenraModelDto, Genras>(dto);
            mapped.ID = id;
            if (mapped is not null)
            {
                gnericREPOSITORY.UpdateAsync(mapped);
                return Ok(mapped);
            }
            return NotFound();
           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genras = new Genras();
            genras.ID = id;
            if (genras is not null)
            {
                gnericREPOSITORY.Delete(genras);
                return Ok();
            }
            return NotFound();

        }


    }
}
