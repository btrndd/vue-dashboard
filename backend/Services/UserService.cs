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

      if (users == null)
        throw new ApplicationException("Oops, parece que ainda não existem usuários cadastrados. :(");

      return users;
    }

    public async Task<ResponseGetUser> Create(RequestCreateUser model)
    {
      var user = await _repository.GetByEmail(model.Email);

      if (user != null)
        throw new ApplicationException("O email inserido já está em uso.");

      var mappedFromModelUser = _mapper.Map<User>(model);

      var createdUser = await _repository.Create(mappedFromModelUser);

      var auth = new Auth
      {
        UserId = createdUser.Id,
        Password = MD5Hash.CalculaHash(model.Password),
        Status = model.Status
      };

      var createdAuth = await _authService.Create(auth);

      if (createdUser == null)
        throw new ApplicationException("Não foi possível criar o usuário.");

      var mappedToResponseUser = _mapper.Map<ResponseGetUser>(createdUser);

      return mappedToResponseUser;
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

    public async Task<ResponseGetUser> Update(int id, RequestEditUser model)
    {
      var user = await _repository.GetById(id);

      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");

      var updatedUser = await _repository.Update(model, id);

      if (updatedUser == null)
        throw new ApplicationException("Não foi possível editar o usuário.");

      var updatedAuth = await _authService.Update(id, model);

      if (updatedAuth == null)
        throw new ApplicationException("Não foi possível editar o usuário.");

      var mappedToResponseUser = _mapper.Map<ResponseGetUser>(updatedUser);

      return mappedToResponseUser;
    }

    public async Task<ResponseGetUser> Remove(int id)
    {
      var user = await _repository.GetById(id);

      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar esse usuário.");

      var mappedFromResponseUser = _mapper.Map<User>(user);

      var removedUser = await _repository.Remove(mappedFromResponseUser);

      if (removedUser == null)
        throw new ApplicationException("Não foi possível remover o usuário.");

      var mappedToResponseUser = _mapper.Map<ResponseGetUser>(removedUser);

      return mappedToResponseUser;
    }

    public async Task<ResponseLogin> Login(RequestLogin model)
    {
      var user = await _repository.GetByEmail(model.Email);
      
      if (user == null)
        throw new UnauthorizedAccessException("Email ou senha inválido!");

      var responseLogin = _repository.Login(model.Email);

      var encryptedPassword = MD5Hash.CalculaHash(model.Password);

      if (responseLogin.Password != encryptedPassword)
        throw new UnauthorizedAccessException("Email ou senha inválido!");

      if (responseLogin == null)
        throw new ApplicationException("Oops! Aconteceu algo de errado.");

      return responseLogin;
    }
  }
}

