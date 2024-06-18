using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RaceForCreationDto, Race>();
        CreateMap<Race, RaceDto>();
        CreateMap<RaceForUpdateDto, Race>();
        CreateMap<Animal, AnimalDto>();
        CreateMap<AnimalForUpdateDto, Animal>();
        CreateMap<AnimalForCreationDto, Animal>();
        CreateMap<UserForRegistrationDto, User>();
    }
}