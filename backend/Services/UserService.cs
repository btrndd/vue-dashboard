using backend.Data;
using backend.Models;
using backend.DTOs;
using backend.Repositories;
using AutoMapper;

namespace backend.Services 
{
  public class UserService 
  {
    private readonly IUserRepository _repository;
    public readonly IMapper _mapper;
    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<ResponseGetUser>> GetAll(DataContext context)
    {
        var users = await _repository.GetAll();
        return users;
    }  

  public async Task<User> Create(
      DataContext context,
      RequestCreateUser model)
    {
      var _mappedUser = _mapper.Map<User>(model);

      var checkIfEmailExists = await _repository.GetByEmail(model.Email);

      var _mappedResponseGetUser = _mapper.Map<User>(checkIfEmailExists);

      if (checkIfEmailExists == null)
      {
        var createdUser = await _repository.CreateUser(_mappedUser);

        var auth = new Auth
        { 
          UserId = createdUser.Id, 
          Password = model.Password,
          Status = model.Status
        };

        await _repository.CreateAuth(auth);

        return _mappedUser;
      }
      return _mappedResponseGetUser;
    }

    public async Task<ResponseGetUser> GetById(DataContext context, int id)
    {
      var user = await _repository.GetById(id);
      return user;
    }

    public async Task<User> Update(
      DataContext context,
      int id,
      RequestEditUser model)
    {         
      var result = await _repository.Update(model, id);
      return result;    
    }

    public async Task<Object> Remove(
      DataContext context,
      int id)
    {
      await _repository.Remove(id);
      return new { message = "O usuário foi removido com sucesso!" };
    }
  }
}

