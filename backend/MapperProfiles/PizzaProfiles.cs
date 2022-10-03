using AutoMapper;
using backend.Dtos;
using backend.Models;

namespace backend.MapperProfiles
{
    public class PizzaProfiles : Profile
    {
        public PizzaProfiles()
        {
            // Source --> Target
            CreateMap<PizzaDetail, PizzaReadDto>();
            CreateMap<PizzaCreateDto, PizzaDetail>();
        }
    }
}