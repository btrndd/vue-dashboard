using backend.Models;
using backend.DTOs;

namespace backend.Interfaces
{
  public interface IUserRepository
  {
    Task<User> Create(User user);
    Task<User> Update(User model);
    Task<List<ResponseGetUser>> GetAll();
    Task<User> GetById(int id);
    Task<User> GetByEmail(string email);
    Task<User> Remove(User user);
  }
}