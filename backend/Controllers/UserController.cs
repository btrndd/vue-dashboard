using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DTOs;
using backend.Extensions;
using backend.Authorization;
using backend.Interfaces;

namespace backend.Controllers 
{
  
  [Authorize]
  [Route("/users")]
  public class UserController : ControllerBase 
  {
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
      _service = service;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<ResponseGetUser>>> GetAll()
    {
      var users = await _service.GetAll();
      return Ok(users);
    }  

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Create([FromBody] RequestCreateUser model)
    {
      if (!ModelState.IsValid)
        throw new ApplicationException(ModelState.GetErrors()[0]);

      var createdUser = await _service.Create(model);

      return Created("/users", new ResultDTO<ResponseGetUser>(createdUser, "Usuário criado com sucesso!"));
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ResponseGetUser>> GetById(int id)
    {
      var user = await _service.GetById(id);
      return Ok(user);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> Update(
      int id,
      [FromBody] RequestEditUser model)
    {      
      if (!ModelState.IsValid)
        throw new ApplicationException(ModelState.GetErrors()[0]);

      var result = await _service.Update(id, model);
      return Ok(new ResultDTO<ResponseGetUser>(result, "Usuário editado com sucesso!"));
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> Remove(int id)
    {
      var result = await _service.Remove(id);
      return Ok(new ResultDTO<ResponseGetUser>(result, "O usuário foi removido com sucesso!"));
    }
  }
}

