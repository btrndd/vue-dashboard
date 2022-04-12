using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using backend.Repositories;
using backend.Middlewares;
using backend.Interfaces;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop Api", Version = "v1" }));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
  dataContext.Database.Migrate();
}


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API V1"));
  app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseMiddleware<BasicAuthMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
