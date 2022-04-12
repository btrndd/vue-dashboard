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
      .Include(x => x.Auth)
      .Select(x => new ResponseGetUser
      {
        Id = x.Id,
        Name = x.Name,
        LastName = x.LastName,
        Phone = x.Phone,
        Email = x.Email,
        BirthDate = x.BirthDate,
        Status = x.Auth.Status
      })
      .ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
      return await _context.Users
      .Where(user => user.Id == id)
      .AsNoTracking()
      .Include(x => x.Auth)
      .FirstOrDefaultAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
      return await _context.Users
      .Where(user => user.Email == email)
      .AsNoTracking()
      .Include(x => x.Auth)
      .FirstOrDefaultAsync();
    }

    public async Task<User> Update(User user)
    {
      var updatedUser = _context.Users.Update(user);
      await _context.SaveChangesAsync();
      return updatedUser.Entity;
    }

    public async Task<User> Remove(User user)
    {
      var removedUser = _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return removedUser.Entity;
    }
  }
}