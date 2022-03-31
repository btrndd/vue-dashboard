using backend.Models;
using backend.DTOs;

namespace backend.Interfaces
{
  public interface IAuthRepository
  {
    Task<Auth> Create(Auth auth);
    Task<Auth> Update(RequestEditUser model, int id);
  }
}