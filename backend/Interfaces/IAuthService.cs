
using backend.Models;
using backend.DTOs;
using backend.Data;

namespace backend.Interfaces
{
    public interface IAuthService
    {
        Task<Auth> Create(Auth auth);
        Task<Auth> Update(int id, RequestEditUser model);
    }
}