using backend.DTOs;

namespace backend.Interfaces
{
  public interface IUserService
  {
    Task<List<ResponseGetUser>> GetAll();
    Task<ResponseGetUser> Create(RequestCreateUser model);
    Task<ResponseGetUser> GetById(int id);
    Task<ResponseGetUser> Update(int id, RequestEditUser model);
    Task<ResponseGetUser> Remove(int id);
    Task<ResponseLogin> Login(RequestLogin model);
  }
}