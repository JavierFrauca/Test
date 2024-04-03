using AutoMapper;
using TEST.Dtos;
using TEST.Models;

namespace TEST.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Tabla1, Tabla1Dto>().ReverseMap();
            CreateMap<Tabla2, Tabla2Dto>().ReverseMap();
            CreateMap<Tabla3, Tabla3Dto>().ReverseMap();
        }
    }
}
