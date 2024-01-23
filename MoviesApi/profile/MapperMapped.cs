using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MoviesApi.DTO;
using MoviesApi.Models;

namespace MoviesApi.profile
{
    public class MapperMapped :Profile 
    {
        public MapperMapped()
        {
            CreateMap<GenraModelDto, Genras>().ReverseMap();
            CreateMap<Movie, MovieModelDto>().ReverseMap();
            CreateMap<Movie, MOvieDetailedDTO>().ReverseMap();
            CreateMap<Movie, ToupdateDto>().ReverseMap();


        }
    }
}
