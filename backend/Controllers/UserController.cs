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
    public async Task<ActionResult<List<GetUsersViewModel>>> GetAll([FromServices] DataContext context)
    {
        var users = await context.Users
            .Join(
              context.Auths,
              user => user.Id,
              auth => auth.UserId,
              (user, auth) => new GetUsersViewModel
                { 
                  Id = user.Id,
                  Name = user.Name,
                  LastName = user.LastName,
                  Email = user.Email,
                  Phone = user.Phone,
                  BirthDate = String.Format("{0:dd/MM/yyyy}", user.BirthDate),
                  Status = auth.Status
                }
              )
            .AsNoTracking()
            .ToListAsync();
        return Ok(users);
    }  

  [HttpPost]
  [Route("")]
  public async Task<ActionResult> Create(
      [FromServices] DataContext context,
      [FromBody] CreateUserViewModel model)
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
            BirthDate = DateTime.ParseExact(model.BirthDate, "dd/MM/yyyy", null)
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
          return Created("/users", user);
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível criar o usuário" });
      }
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<GetUsersViewModel>> GetById([FromServices] DataContext context, int id)
    {
        var user = await context.Users
            .Where(user => user.Id == id)
            .Join(
              context.Auths,
              user => user.Id,
              auth => auth.UserId,
              (user, auth) => new GetUsersViewModel
                {
                  Id = user.Id,
                  Name = user.Name,
                  LastName = user.LastName,
                  Email = user.Email,
                  Phone = user.Phone,
                  BirthDate = String.Format("{0:dd/MM/yyyy}", user.BirthDate),
                  Status = auth.Status
                }
              )
            .AsNoTracking()            
            .FirstOrDefaultAsync();
        return Ok(user);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult> Update(
      [FromServices] DataContext context,
      int id,
      [FromBody] CreateUserViewModel model)
    {
      var currUserModel = context.Users.FirstOrDefault(x => x.Id == id);
      var currAuthModel = context.Auths.FirstOrDefault(x => x.UserId == id);
      
      if (!ModelState.IsValid)
          return BadRequest(ModelState);

      try
      {          
          currUserModel.Name = model.Name;
          currUserModel.LastName = model.LastName;
          currUserModel.Email = model.Email;
          currUserModel.Phone = model.Phone;
          currUserModel.BirthDate = DateTime.ParseExact(model.BirthDate, "dd/MM/yyyy", null);         

          currAuthModel.Password = model.Password;
          currAuthModel.Status = model.Status;

          context.Users.Update(currUserModel);
          context.Auths.Update(currAuthModel);

          await context.SaveChangesAsync();
          return Ok(currUserModel);
      }
      catch (ArgumentNullException)
      {
          return NotFound(new { message = "Usuário não encontrado" });
      }
      catch (Exception)
      {
          return BadRequest(new { message = "Não foi possível atualizar o usuário" });
      }
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult> Remove(
      [FromServices] DataContext context,
      int id)
    {
      var currUserModel = context.Users.FirstOrDefault(x => x.Id == id);

      try
      {          
          context.Users.Remove(currUserModel);
          await context.SaveChangesAsync();
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

