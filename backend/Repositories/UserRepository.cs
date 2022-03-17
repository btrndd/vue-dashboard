using backend.Data;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }


        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Auth> CreateAuth(Auth auth)
        {
            _context.Auths.Add(auth);
            await _context.SaveChangesAsync();
            return auth;
        }

        public async Task<List<ResponseGetUser>> GetAll()
        {
            return await _context.Users
            .Join(
              _context.Auths,
              user => user.Id,
              auth => auth.UserId,
              (user, auth) => new ResponseGetUser
                { 
                  Id = user.Id,
                  Name = user.Name,
                  LastName = user.LastName,
                  Phone = user.Phone,
                  Email = user.Email,
                  BirthDate = user.BirthDate,
                  Status = auth.Status
                }
              )
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<ResponseGetUser> GetById(int id)
        {
            return await _context.Users
            .Where(user => user.Id == id)
            .Join(
              _context.Auths,
              user => user.Id,
              auth => auth.UserId,
              (user, auth) => new ResponseGetUser
                { 
                  Id = user.Id,
                  Name = user.Name,
                  LastName = user.LastName,
                  Phone = user.Phone,
                  Email = user.Email,
                  BirthDate = user.BirthDate,
                  Status = auth.Status
                }
              )
            .AsNoTracking()            
            .FirstOrDefaultAsync();
        }

        public async Task<User> Update(RequestEditUser model, int id)
        {

          var currUserModel = _context.Users.FirstOrDefault(x => x.Id == id);
          var currAuthModel = _context.Auths.FirstOrDefault(x => x.UserId == id);

          currUserModel.Name = model.Name;
          currUserModel.LastName = model.LastName;
          currUserModel.Email = model.Email;
          currUserModel.Phone = model.Phone;
          currUserModel.BirthDate = model.BirthDate;
          
          currAuthModel.Status = model.Status;

          _context.Users.Update(currUserModel);
          _context.Auths.Update(currAuthModel);

          await _context.SaveChangesAsync();
          return currUserModel;
        }

        public async Task<User> Remove(int id)
        {
          var currUserModel = _context.Users.FirstOrDefault(x => x.Id == id);

          _context.Users.Remove(currUserModel);
          await _context.SaveChangesAsync();
          return currUserModel;
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