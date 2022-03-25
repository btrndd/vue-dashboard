using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using backend.DTOs;
using backend.Extensions;
using backend.Authorization;
using backend.Services;

namespace backend.Controllers {
  
  [Authorize]
  [Route("/users")]
  public class UserController : ControllerBase {
    private readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<ResponseGetUser>>> GetAll([FromServices] DataContext context)
    {
      try
      {
        var users = await _service.GetAll(context);
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
        var createdUser = await _service.Create(context, model);
        return Created("/users", new ResultDTO<User>(createdUser, new List<string> { "Usuário criado com sucesso!" }));
      }
      catch (ArgumentNullException) 
      {
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
        var user = await _service.GetById(context, id);
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
          var result = await _service.Update(context, id, model);
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
          var result = await _service.Remove(context, id);
          return Ok(result);
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

