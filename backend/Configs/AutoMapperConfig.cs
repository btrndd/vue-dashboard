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
      CreateMap<User, ResponseLogin>()
        .ForMember(dest =>
        dest.Id,
        opt => opt.MapFrom(src => src.Auth.Id))
        .ForMember(dest =>
        dest.Email,
        opt => opt.MapFrom(src => src.Email))
        .ForMember(dest =>
        dest.Password,
        opt => opt.MapFrom(src => src.Auth.Password))
        .ReverseMap();
    }
  }
}