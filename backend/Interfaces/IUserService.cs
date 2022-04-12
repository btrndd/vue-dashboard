using backend.DTOs;
using backend.Models;

namespace backend.Interfaces
{
  public interface IUserService
  {
    Task<List<ResponseGetUser>> GetAll();
    Task<ResponseGetUser> Create(RequestCreateUser model);
    Task<ResponseGetUser> GetById(int id);
    Task<User> GetByEmail(string email);
    Task<ResponseGetUser> Update(int id, RequestEditUser model);
    Task<ResponseGetUser> Remove(int id);
  }
}