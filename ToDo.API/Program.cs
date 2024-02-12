using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Configuration;
using ToDo.BLL.Mapping.Tasks;
using ToDo.BLL.MediatR.Tasks.Create;
using ToDo.DAL.Persistence;
using ToDo.DAL.Repositories.Interfaces.Base;
using ToDo.DAL.Repositories.Realizations.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// builder.Services.AddCustomServices();
// builder.Services.AddMediatRHandlers();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(IRepositoryWrapper), typeof(RepositoryWrapper));
var assemblyContainingHandlers = AppDomain.CurrentDomain.Load("Todo.BLL");
builder.Services.AddAutoMapper(assemblyContainingHandlers);
builder.Services.AddMediatR(assemblyContainingHandlers);


builder.Services.AddDbContext<ToDoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin"); 
app.MapControllers();
app.Run();


