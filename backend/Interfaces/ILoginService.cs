using backend.Models;
using backend.DTOs;

namespace backend.Interfaces
{
  public interface ILoginService
  {
    Task<ResponseLogin> Login(RequestLogin model);
  }
}