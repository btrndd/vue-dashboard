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
          .ForMember(dest =>
          dest.Status,
          opt => opt.Ignore()).ReverseMap();
        CreateMap<RequestEditUser, User>()
          .ForMember(dest =>
          dest.Status,
          opt => opt.Ignore()).ReverseMap();
        CreateMap<User, ResponseGetUser>()
          .ForMember(dest =>
          dest.Status,
          opt => opt.MapFrom(src => src.Status.Status));
        CreateMap<ResponseGetUser, User>()
          .ForMember(dest =>
          dest.Status,
          opt => opt.Ignore());
    }
  }
}