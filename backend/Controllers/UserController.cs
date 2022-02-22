using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers {

  [Route("/users")]
  public class UserController : ControllerBase {
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
    {
        var users = await context
            .Users
            .AsNoTracking()
            .ToListAsync();
        return users;
    }  

  [HttpPost]
  [Route("")]
  public async Task<ActionResult<User>> Post(
      [FromServices] DataContext context,
      [FromBody]User model)
    {
      // Verifica se os dados são válidos
      if (!ModelState.IsValid)
          return BadRequest(ModelState);

      try
      {
          context.Users.Add(model);
          await context.SaveChangesAsync();
          return model;
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível criar o usuário" });

      }
    }
  }
}

