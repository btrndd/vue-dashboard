using backend.Models;
using backend.DTOs;

namespace backend.Interfaces
{
  public interface IAuthService
  {
    Task<Auth> Create(Auth auth);
    Task<Auth> Update(int id, RequestEditUser model);
  }
}