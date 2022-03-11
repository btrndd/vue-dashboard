using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.DTOs;
using backend.Extensions;
using backend.Repositories;
using AutoMapper;

namespace backend.Controllers {

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
        var users = await _repository.GetAll();
        return Ok(users);
    }  

  [HttpPost]
  [Route("")]
  public async Task<ActionResult> Create(
      [FromServices] DataContext context,
      [FromBody] RequestCreateUser model)
    {
      // Verifica se os dados são válidos
      if (!ModelState.IsValid)
          return BadRequest(new ResultDTO<User>(null, ModelState.GetErrors()));

      try
      {
          var _mappedUser = _mapper.Map<User>(model);
          
          var createdUser = await _repository.CreateUser(_mappedUser);

          var auth = new Auth
          { 
            UserId = createdUser.Id, 
            Password = model.Password,
            Status = model.Status
          };

          await _repository.CreateAuth(auth);

          return Created("/users", _mappedUser);
      }
      catch (Exception)
      {
          return BadRequest(new ResultDTO<User>(null, ModelState.GetErrors()));
      }
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseGetUser>> GetById([FromServices] DataContext context, int id)
    {
        var user = await _repository.GetById(id);
        return Ok(user);
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
          return Ok(result);
      }
      catch (ArgumentNullException)
      {
          return NotFound(new { message = "Usuário não encontrado" });
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível editar o usuário" });
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
          return Ok(new { message = "O usuário foi removido com sucesso" });
      }
      catch (ArgumentNullException)
      {
          return NotFound(new { message = "Usuário não encontrado" });
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível remover o usuário" });
      }
    }
  }
}

