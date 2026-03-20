using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CleanArchitectureCQRS.Domain.Entities;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Commands
{
    public record UpsertBlogsCommand (List<Blog> Blogs): IRequest<List<Blog>>;
}
