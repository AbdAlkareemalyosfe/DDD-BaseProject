using Microsoft.EntityFrameworkCore;
using Repositories.RespoServices;
using Services.ServiceServices;
using SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RepoExtension.AddMyServices(builder.Services);
ServiceExtension.AddMyServices(builder.Services);

// Add Connection to database

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(
    option => option.AllowAnyHeader()
               .AllowAnyOrigin()
               .AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
