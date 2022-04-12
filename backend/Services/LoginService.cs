using backend.Models;
using backend.DTOs;
using backend.Interfaces;
using AutoMapper;

namespace backend.Services
{
  public class LoginService : ILoginService
  {
    private readonly IUserService _service;
    private readonly IMapper _mapper;

    public LoginService(IUserService service, IMapper mapper)
    {
      _service = service;
      
      _mapper = mapper;
    }
    public async Task<ResponseLogin> Login(RequestLogin model)
    {
      var user = await _service.GetByEmail(model.Email);
      
      if (user == null)
        throw new UnauthorizedAccessException("Email ou senha inválido!");

      var encryptedPassword = MD5Hash.CalculaHash(model.Password);

      if (user.Auth.Password != encryptedPassword)
        throw new UnauthorizedAccessException("Email ou senha inválido!");
      
      var mappedToResponseLogin = _mapper.Map<ResponseLogin>(user);

      return mappedToResponseLogin;
    }
  }
}

