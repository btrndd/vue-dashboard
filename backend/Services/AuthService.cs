using backend.Models;
using backend.DTOs;
using backend.Interfaces;

namespace backend.Services
{
  public class AuthService : IAuthService
  {
    private readonly IAuthRepository _repository;
    public AuthService(IAuthRepository repository)
    {
      _repository = repository;
    }

    public async Task<Auth> Create(Auth auth)
    {
      var createdAuth = await _repository.Create(auth);

      if (createdAuth == null)
        throw new ApplicationException("Não foi possível criar o usuário.");

      return createdAuth;
    }

    public async Task<Auth> Update(int id, RequestEditUser model)
    {
      var updatedAuth = await _repository.Update(model, id);

      if (updatedAuth == null)
        throw new ApplicationException("Não foi possível editar o usuário.");

      return updatedAuth;
    }
  }
}

