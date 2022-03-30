using backend.Data;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using backend.Interfaces;

namespace backend.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<User> Create(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return user;
    }

    public async Task<List<ResponseGetUser>> GetAll()
    {
      return await _context
      .Users
      .AsNoTracking()
      .Include(x => x.Status)
      .Select(x => new ResponseGetUser
        { 
          Id = x.Id,
          Name = x.Name,
          LastName = x.LastName,
          Phone = x.Phone,
          Email = x.Email,
          BirthDate = x.BirthDate,
          Status = x.Status.Status
        })        
      .ToListAsync();  
    }

    public async Task<ResponseGetUser> GetById(int id)
    {
      return await _context.Users
      .Where(user => user.Id == id)
      .AsNoTracking()
      .Include(x => x.Status)
      .Select(x => new ResponseGetUser
        { 
          Id = x.Id,
          Name = x.Name,
          LastName = x.LastName,
          Phone = x.Phone,
          Email = x.Email,
          BirthDate = x.BirthDate,
          Status = x.Status.Status
        })          
      .FirstOrDefaultAsync();
    }

    public async Task<ResponseGetUser> GetByEmail(string email)
    {
      return await _context.Users
      .Where(user => user.Email == email)
      .AsNoTracking()
      .Include(x => x.Status)
      .Select(x => new ResponseGetUser
        { 
          Id = x.Id,
          Name = x.Name,
          LastName = x.LastName,
          Phone = x.Phone,
          Email = x.Email,
          BirthDate = x.BirthDate,
          Status = x.Status.Status
        })          
      .FirstOrDefaultAsync();
    }

    public async Task<User> Update(RequestEditUser model, int id)
    {

      var currUserModel = _context.Users.FirstOrDefault(x => x.Id == id);

      currUserModel.Name = model.Name;
      currUserModel.LastName = model.LastName;
      currUserModel.Email = model.Email;
      currUserModel.Phone = model.Phone;
      currUserModel.BirthDate = model.BirthDate;

      _context.Users.Update(currUserModel);

      await _context.SaveChangesAsync();
      return currUserModel;
    }

    public async Task<User> Remove(User user)
    {
      var result = _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return result.Entity;
    }
    public ResponseLogin Login(string email)
    {
      var currUserModel = _context.Users.FirstOrDefault(x => x.Email == email);
      var currAuthModel = _context.Auths.FirstOrDefault(x => x.UserId == currUserModel.Id);
      var authenticated = new ResponseLogin
      {
        Id = currAuthModel.Id,
        Email = currUserModel.Email,
        Password = currAuthModel.Password,
      };

      return authenticated;
    }
  }
}