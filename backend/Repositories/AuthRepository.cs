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
      var createdAuth = _context.Auths.Add(auth);
      await _context.SaveChangesAsync();
      return createdAuth.Entity;
    }

    public async Task<Auth> Update(RequestEditUser model, int id)
    {
      var currentAuth = _context.Auths.FirstOrDefault(x => x.UserId == id);

      currentAuth.Status = model.Status;
      if (model.Password != null)
      {
        var encryptedPassword = MD5Hash.CalculaHash(model.Password);
        currentAuth.Password = encryptedPassword;
      }

      _context.Auths.Update(currentAuth);

      await _context.SaveChangesAsync();
      return currentAuth;
    }
  }
}