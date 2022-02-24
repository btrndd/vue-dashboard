using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using backend.ViewModels;

namespace backend.Controllers {

  [Route("/users")]
  public class UserController : ControllerBase {
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<EditorUserViewModel>>> GetAll([FromServices] DataContext context)
    {
        var users = await context.Users
            .Join(
              context.Auths,
              user => user.Id,
              auth => auth.UserId,
              (user, auth) => new EditorUserViewModel
                {
                  Name = user.Name,
                  LastName = user.LastName,
                  Email = user.Email,
                  BirthDate = user.BirthDate
                }
              )
            .AsNoTracking()
            .ToListAsync();
        foreach (EditorUserViewModel model in users) {
          model.Password = "";
          model.Phone = "";
        }
        return users;
    }  

  [HttpPost]
  [Route("")]
  public async Task<ActionResult> Create(
      [FromServices] DataContext context,
      [FromBody] EditorUserViewModel model)
    {
      // Verifica se os dados são válidos
      if (!ModelState.IsValid)
          return BadRequest(ModelState);

      try
      {
          var user = new User 
          {
            Name = model.Name,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone,
            BirthDate = model.BirthDate
          };
          context.Users.Add(user);
          await context.SaveChangesAsync();

          var auth = new Auth
          { 
            UserId = user.Id,
            Password = model.Password,
            Status = model.Status
          };
          context.Auths.Add(auth);
          await context.SaveChangesAsync();
          return Created("/users", new ResultViewModel<User>(user).Data);
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível criar o usuário" });

      }
    }
  }
}

