using CleanArchitectureCQRS.Domain.Interfaces;
using CleanArchitectureCQRS.Infrastructure.Data;
using CleanArchitectureCQRS.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureCQRS.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitectureCQRS.Application.Blogs.Commands;

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

var app = builder.Build();

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
