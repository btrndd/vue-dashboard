using Microsoft.AspNetCore.Mvc;
using backend.DTOs;
using backend.Extensions;
using backend.Authorization;
using backend.Interfaces;

namespace backend.Controllers
{

  [Authorize]
  [Route("/login")]
  public class LoginController : ControllerBase
  {
    private readonly IUserService _service;

    public LoginController(IUserService service)
    {
      _service = service;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Login([FromBody] RequestLogin model)
    {
      if (!ModelState.IsValid)
        throw new ApplicationException(ModelState.GetErrors()[0]);

      var responseLogin = await _service.Login(model);
      return Ok(new ResultDTO<ResponseLogin>(responseLogin, "Login realizado com sucesso!"));
    }
  }
}

