using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureCQRS.Application.Blogs.Commands
{
    public class CreateBlogCommandHandler
        : IRequestHandler<CreateBlogCommand, Blog>
    {
        private readonly IBlogrepo _blogrepo;

        public CreateBlogCommandHandler(IBlogrepo blogrepo)
        {
            _blogrepo = blogrepo;
        }

        public async Task<Blog> Handle(
            CreateBlogCommand request,
            CancellationToken cancellationToken)
        {
            

                var blog = new Blog
                {
                    Name = request.Name,
                    Age = request.Age,
                    Content = request.Content
                };

                return await _blogrepo.CreateAsync(blog);
            
           
        }
    }
}