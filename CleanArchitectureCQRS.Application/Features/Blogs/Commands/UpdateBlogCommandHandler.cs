using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Commands
{
    public class UpdateBlogCommandHandler
       : IRequestHandler<UpdateBlogCommand, Blog?>
    {
        private readonly IBlogrepo _blogrepo;

        public UpdateBlogCommandHandler(IBlogrepo blogrepo)
        {
            _blogrepo = blogrepo;
        }

        public async Task<Blog?> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new Exception("Name is required");

            if (string.IsNullOrWhiteSpace(request.Content))
                throw new Exception("Content is required");

            if (request.Age <= 0)
                throw new Exception("Age must be greater than 0");
            var blog = new Blog
            {
                Name = request.Name,
                Age = request.Age,
                Content = request.Content
            };
            return await _blogrepo.UpdateAsync(request.Id, blog);
        }
    }
}
