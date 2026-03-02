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
            
                if (string.IsNullOrWhiteSpace(request.Name))
                    throw new ArgumentException("Name is required");

                if (string.IsNullOrWhiteSpace(request.Content))
                    throw new ArgumentException("Content is required");

                if (request.Age <= 0)
                    throw new ArgumentException("Age must be greater than 0");

                var blog = new Blog
                {
                    Name = request.Name,
                    Age = request.Age,
                    Content = request.Content
                };

                return await _blogrepo.CreateAsync(blog);
            
            //catch (Exception ex)
            //{
            //    throw new Exception($"Error creating blog: {ex.Message}");
            //}
        }
    }
}