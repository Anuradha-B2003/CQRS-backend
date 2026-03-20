using CleanArchitectureCQRS.API.Middleware;
using CleanArchitectureCQRS.Application.Behaviors;
using CleanArchitectureCQRS.Application.Blogs.Commands;
using CleanArchitectureCQRS.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitectureCQRS.Application.Features.Blogs.Validators;
using CleanArchitectureCQRS.Application.Interfaces;
using CleanArchitectureCQRS.Domain.Interfaces;
using CleanArchitectureCQRS.Infrastructure.Data;
using CleanArchitectureCQRS.Infrastructure.Persistence.Dapper;
using CleanArchitectureCQRS.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<BlogDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BlogDBContext")
        ?? throw new InvalidOperationException("Connection string not found.")
    ));

// Register Repository
builder.Services.AddTransient<IBlogrepo, BlogRepository>();

// Register MediatR (for CQRS)
builder.Services.AddMediatR(typeof(CreateBlogCommand).Assembly);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers()
//    .AddFluentValidation();


builder.Services.AddValidatorsFromAssemblyContaining<CreateBlogCommandValidator>();

builder.Services.AddValidatorsFromAssembly(
    typeof(CreateBlogCommandValidator).Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IBlogQueryRepository, BlogQueryRepository>();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();



//var app = builder.Build();



app.Run();
