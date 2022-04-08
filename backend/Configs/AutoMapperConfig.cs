using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Configs
{
  public class AutoMapperConfig : Profile
  {
    public AutoMapperConfig()
    {
      CreateMap<RequestCreateUser, User>()
        .ForPath(dest => dest.Auth.Password, opt => opt.MapFrom(src => src.Password))
        .ForPath(dest => dest.Auth.Status, opt => opt.MapFrom(src => src.Status))
        .ReverseMap();
      CreateMap<RequestEditUser, User>()
        .ForPath(dest => dest.Auth.Password, opt => opt.MapFrom(src => src.Password))
        .ForPath(dest => dest.Auth.Status, opt => opt.MapFrom(src => src.Status))
        .ReverseMap();
      CreateMap<User, ResponseGetUser>()
        .ForMember(dest =>
        dest.Status,
        opt => opt.MapFrom(src => src.Auth.Status))
        .ReverseMap();
    }
  }
}