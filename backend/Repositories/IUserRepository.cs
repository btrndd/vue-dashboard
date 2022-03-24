
using backend.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<Auth> CreateAuth(Auth auth);
        Task<User> Update(RequestEditUser model, int id);
        Task<List<ResponseGetUser>> GetAll();
        Task<ResponseGetUser> GetById(int id);
        Task<ResponseGetUser> GetByEmail(string email);
        Task<User> Remove(int id);
        ResponseLogin Login(string email);
    }
}