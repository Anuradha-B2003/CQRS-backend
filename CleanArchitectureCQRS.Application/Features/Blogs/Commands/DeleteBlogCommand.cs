using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Commands
{
   public record DeleteBlogCommand(int Id):IRequest<bool>;
    
}
