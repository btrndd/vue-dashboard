using backend.Models;
using backend.DTOs;
using backend.Interfaces;
using AutoMapper;

namespace backend.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository repository, IMapper mapper)
    {
      _repository = repository;
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
      var user = _repository.GetByEmail(model.Email);

      if (user.Result is not null && user.Result.Email == model.Email)
        throw new ApplicationException("O email inserido já está em uso.");

      var encryptedPassword = MD5Hash.CalculaHash(model.Password);
      model.Password = encryptedPassword;

      var mappedFromModelUser = _mapper.Map<User>(model);

      var createdUser = await _repository.Create(mappedFromModelUser);

      if (createdUser == null)
        throw new ApplicationException("Não foi possível criar o usuário.");

      var mappedToResponseUser = _mapper.Map<ResponseGetUser>(createdUser);

      return mappedToResponseUser;
    }

    public async Task<ResponseGetUser> GetById(int id)
    {
      var user = await _repository.GetById(id);

      var mappedToResponseUser = _mapper.Map<ResponseGetUser>(user);

      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");

      return mappedToResponseUser;
    }

    public async Task<User> GetByEmail(string email)
    {
      var user = await _repository.GetByEmail(email);

      return user;
    }

    public async Task<ResponseGetUser> Update(int id, RequestEditUser model)
    {
      var user = await _repository.GetById(id);
      if (user == null)
        throw new KeyNotFoundException("Não foi possível encontrar o usuário.");

      if (model.Password != null)
      {
        var encryptedPassword = MD5Hash.CalculaHash(model.Password);
        model.Password = encryptedPassword;
      } else 
      {
        model.Password = user.Auth.Password;
      }

      User mappedFromModelUser = _mapper.Map(model, user);

      var updatedUser = await _repository.Update(mappedFromModelUser);

      if (updatedUser == null)
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
  }
}

