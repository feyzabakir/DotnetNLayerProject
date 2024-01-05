using DotnetNLayerProject.Core.Repositories;
using DotnetNLayerProject.Core.Services;
using DotnetNLayerProject.Core.UnitOfWorks;
using DotnetNLayerProject.Repository;
using DotnetNLayerProject.Repository.Repositories;
using DotnetNLayerProject.Repository.UnitOfWork;
using DotnetNLayerProject.Service.Mapping;
using DotnetNLayerProject.Service.Services;
using DotnetNLayerProject.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IBlogService,BlogService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IWriterService,WriterService>();

//Fluent Validations
builder.Services.AddControllers()
    .AddFluentValidation(x =>
    {
        x.RegisterValidatorsFromAssemblyContaining<BlogDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<CategoryDtoValidator>();
        x.RegisterValidatorsFromAssemblyContaining<WriterDtoValidator>();
    });

//AppDbContext islemleri
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
