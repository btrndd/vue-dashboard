using backend.Models;
using backend.DTOs;
using backend.Interfaces;
using AutoMapper;

namespace backend.Services 
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _repository;
    private readonly IAuthService _authService;
    public readonly IMapper _mapper;
    public UserService(IUserRepository repository, IAuthService service, IMapper mapper)
    {
        _repository = repository;
        _authService = service;
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

  public async Task<ResponseGetUser> Create(RequestCreateUser model)
    {
      var _mappedUser = _mapper.Map<User>(model);

      var checkIfEmailExists = await _repository.GetByEmail(model.Email);

      if (checkIfEmailExists != null)
        throw new ApplicationException("O email inserido já está em uso.");

      var _mappedResponseGetUser = _mapper.Map<User>(checkIfEmailExists);
      
      var createdUser = await _repository.Create(_mappedUser);

      var auth = new Auth
      { 
        UserId = createdUser.Id, 
        Password = MD5Hash.CalculaHash(model.Password),
        Status = model.Status
      };

      var createdAuth = await _authService.Create(auth);

      if (createdUser == null)
        throw new ApplicationException("Não foi possível criar o usuário.");

      var resultUser = _mapper.Map<ResponseGetUser>(_mappedUser);

      return resultUser;
    }

    public async Task<ResponseGetUser> GetById(int id)
    {
      var user = await _repository.GetById(id);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");
      
      return user;
    }
    public async Task<ResponseGetUser> GetByEmail(string email)
    {
      var user = await _repository.GetByEmail(email);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");
      
      return user;
    }

    public async Task<ResponseGetUser> Update(
      int id,
      RequestEditUser model)
    {         
      var user = await _repository.GetById(id);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");

      var userResult = await _repository.Update(model, id);
      if (userResult == null)
        throw new ApplicationException("Não foi possível editar o usuário.");

      var authResult = await _authService.Update(id, model);  

      var mapUser = _mapper.Map<ResponseGetUser>(userResult);    

      return mapUser;
    }

    public async Task<ResponseGetUser> Remove(int id)
    {
      var user = await _repository.GetById(id);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar esse usuário.");

      var _mappedResponseGetUser = _mapper.Map<User>(user);

      var result = await _repository.Remove(_mappedResponseGetUser);
      if (result == null)
        throw new ApplicationException("Não foi possível remover o usuário.");
      
      var mapResult = _mapper.Map<ResponseGetUser>(result);

      return mapResult;
    }

    public async Task<ResponseLogin> Login(RequestLogin model)
    {
      var user = await _repository.GetByEmail(model.Email);
      if (user == null)
        throw new UnauthorizedAccessException("Email ou senha inválido!");

      var authenticated = _repository.Login(model.Email);

      var encryptPassword = MD5Hash.CalculaHash(model.Password);
        
      if (authenticated.Password != encryptPassword)
        throw new UnauthorizedAccessException("Email ou senha inválido!");

      if (authenticated == null)
        throw new ApplicationException("Oops! Aconteceu algo de errado.");
      
      return authenticated;
    }
  }
}

