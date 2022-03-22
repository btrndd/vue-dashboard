using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.DTOs;
using backend.Extensions;
using backend.Repositories;
using AutoMapper;
using backend.Authorization;

namespace backend.Controllers {
  
  [Authorize]
  [Route("/users")]
  public class UserController : ControllerBase {
    private readonly IUserRepository _repository;
    public readonly IMapper _mapper;
    public UserController(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<ResponseGetUser>>> GetAll([FromServices] DataContext context)
    {
      try
      {
        var users = await _repository.GetAll();
        return Ok(users);
      }
      catch (Exception) 
      {
        return BadRequest(new { message = "Oops, parece que ainda não existem usuários cadastrados. :(" });
      }
    }  

  [HttpPost]
  [Route("")]
  public async Task<ActionResult> Create(
      [FromServices] DataContext context,
      [FromBody] RequestCreateUser model)
    {
      if (!ModelState.IsValid)
          return BadRequest(new ResultDTO<User>(null, ModelState.GetErrors()));

      try
      {
          var _mappedUser = _mapper.Map<User>(model);

          var checkIfEmailExists = await _repository.GetByEmail(model.Email);

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

            return Created("/users", new ResultDTO<User>(_mappedUser, new List<string> { "Usuário criado com sucesso!" }));
          }
        return BadRequest(new { message = "O email inserido já está em uso." });
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível criar o usuário." });
      }
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseGetUser>> GetById([FromServices] DataContext context, int id)
    {
      try 
      {
        var user = await _repository.GetById(id);
        return Ok(user);
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possível encontrar o usuário." });
      }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> Update(
      [FromServices] DataContext context,
      int id,
      [FromBody] RequestEditUser model)
    {      
      if (!ModelState.IsValid)
          return BadRequest(new ResultDTO<User>(null, ModelState.GetErrors()));

      try
      {          
          var result = await _repository.Update(model, id);
          return Ok(new ResultDTO<User>(result, new List<string> { "Usuário editado com sucesso!" }));
      }
      catch (ArgumentNullException)
      {
          return NotFound(new { message = "Usuário não encontrado." });
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível editar o usuário." });
      }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> Remove(
      [FromServices] DataContext context,
      int id)
    {
      try
      {
          await _repository.Remove(id);
          return Ok(new { message = "O usuário foi removido com sucesso!" });
      }
      catch (ArgumentNullException)
      {
          return NotFound(new { message = "Usuário não encontrado." });
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível remover o usuário." });
      }
    }
  }
}

