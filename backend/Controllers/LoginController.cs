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
  [Route("/login")]
  public class LoginController : ControllerBase 
  {
    private readonly IUserRepository _repository;
    public readonly IMapper _mapper;
    
    public LoginController(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;        
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("")]
    public ActionResult Login(
      [FromServices] DataContext context,
      [FromBody] RequestLogin model)
    {
      if (!ModelState.IsValid)
          return BadRequest(new ResultDTO<ResponseLogin>(null, ModelState.GetErrors()));

      try
      {
        var authenticated = _repository.Login(model.Email);
        
        if (authenticated == null | authenticated.Password != model.Password)  
          return Unauthorized(new ResultDTO<ResponseLogin>(null, new List<string> { "Email ou senha inválido!" }));
        
        return Ok(new ResultDTO<ResponseLogin>(authenticated, new List<string> { "Login realizado com sucesso!" }));
             
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possível realizar o login." });
      }
    }
  }
}

