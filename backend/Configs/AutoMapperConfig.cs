using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Configs
{
  public class AutoMapperConfig : Profile
  {
    public AutoMapperConfig()
    {
        CreateMap<User, RequestCreateUser>().ReverseMap();
        CreateMap<User, RequestEditUser>().ReverseMap();
        CreateMap<User, ResponseGetUser>().ReverseMap();
    }
  }
}