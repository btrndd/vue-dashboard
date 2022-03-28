using backend.Data;
using backend.Models;
using backend.DTOs;
using backend.Interfaces;
using AutoMapper;

namespace backend.Services 
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _repository;
    public readonly IMapper _mapper;
    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<ResponseGetUser>> GetAll()
    {
        var users = await _repository.GetAll();
        if (users == null) {
          throw new ApplicationException("Oops, parece que ainda não existem usuários cadastrados. :(");
        }
        return users;
    }  

  public async Task<User> Create(RequestCreateUser model)
    {
      var _mappedUser = _mapper.Map<User>(model);

      var checkIfEmailExists = await _repository.GetByEmail(model.Email);

      var _mappedResponseGetUser = _mapper.Map<User>(checkIfEmailExists);

      if (checkIfEmailExists == null)
        throw new ApplicationException("O email inserido já está em uso.");
      
      var createdUser = await _repository.CreateUser(_mappedUser);

      var auth = new Auth
      { 
        UserId = createdUser.Id, 
        Password = model.Password,
        Status = model.Status
      };

      var createdAuth = await _repository.CreateAuth(auth);

      if (createdUser == null | createdAuth == null)
        throw new ApplicationException("Não foi possível criar o usuário.");

      return _mappedUser;
    }

    public async Task<ResponseGetUser> GetById(int id)
    {
      var user = await _repository.GetById(id);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");
      
      return user;
    }

    public async Task<User> Update(
      int id,
      RequestEditUser model)
    {         
      var user = await _repository.GetById(id);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");

      var result = await _repository.Update(model, id);
      if (result == null)
        throw new ApplicationException("Não foi possível editar o usuário.");

      return result;    
    }

    public async Task<User> Remove(int id)
    {
      var user = await _repository.GetById(id);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar esse usuário.");

      var _mappedResponseGetUser = _mapper.Map<User>(user);

      var result = await _repository.Remove(_mappedResponseGetUser);
      if (result == null)
        throw new ApplicationException("Não foi possível remover o usuário.");

      return result;
    }

    public async Task<ResponseLogin> Login(RequestLogin model)
    {
      var user = await _repository.GetByEmail(model.Email);
      if (user == null)
        throw new UnauthorizedAccessException("Email ou senha inválido!");

      var authenticated = _repository.Login(model.Email);
        
      if (authenticated.Password != model.Password)
        throw new UnauthorizedAccessException("Email ou senha inválido!");

      if (authenticated == null)
        throw new ApplicationException("Oops! Aconteceu algo de errado.");
      
      return authenticated;
    }
  }
}

