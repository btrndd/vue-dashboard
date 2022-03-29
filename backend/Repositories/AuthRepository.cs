using backend.Data;
using backend.Models;
using backend.DTOs;
using backend.Interfaces;

namespace backend.Repositories
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Auth> Create(Auth auth)
    {
        _context.Auths.Add(auth);
        await _context.SaveChangesAsync();
        return auth;
    }

    public async Task<Auth> Update(RequestEditUser model, int id)
    {
      var currAuthModel = _context.Auths.FirstOrDefault(x => x.UserId == id);
      
      currAuthModel.Status = model.Status;
      if (model.Password != null) {
        var encryptPassword = MD5Hash.CalculaHash(model.Password);
        currAuthModel.Password = encryptPassword;
      }

      _context.Auths.Update(currAuthModel);

      await _context.SaveChangesAsync();
      return currAuthModel;
    }
  }
}