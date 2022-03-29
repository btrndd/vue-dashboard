
using backend.Models;
using backend.DTOs;
using backend.Data;

namespace backend.Interfaces
{
    public interface IUserService
    {
        Task<List<ResponseGetUser>> GetAll();
        Task<User> Create(RequestCreateUser model);
        Task<ResponseGetUser> GetById(int id);
        Task<ResponseGetUser> GetByEmail(string email);
        Task<User> Update(int id, RequestEditUser model);
        Task<User> Remove(int id);
        Task<ResponseLogin> Login(RequestLogin model);
    }
}