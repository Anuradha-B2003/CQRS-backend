using CleanArchitectureCQRS.Domain.Entities;
//using CleanArchitectureCQRS.Domain.Entities.CleanArchitectureCQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Blogs.Commands
{
    public record CreateBlogCommand(string Name, int Age, string Content) : IRequest<Blog>;
}
