using CleanArchitectureCQRS.Domain.Entities;
//using CleanArchitectureCQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsQuery : IRequest<List<Blog>>
    {
    }
}
