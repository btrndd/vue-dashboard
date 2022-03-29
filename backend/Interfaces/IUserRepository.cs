
using backend.Models;
using backend.DTOs;

namespace backend.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Update(RequestEditUser model, int id);
        Task<List<ResponseGetUser>> GetAll();
        Task<ResponseGetUser> GetById(int id);
        Task<ResponseGetUser> GetByEmail(string email);
        Task<User> Remove(User user);
        ResponseLogin Login(string email);
    }
}