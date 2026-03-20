using CleanArchitectureCQRS.Application.Features.Blogs.Commands;
using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Commands
{
    public class UpsertBlogsCommandHandler
        : IRequestHandler<UpsertBlogsCommand, List<Blog>>
    {
        private readonly IBlogrepo _blogrepo;

        public UpsertBlogsCommandHandler(IBlogrepo blogrepo)
        {
            _blogrepo = blogrepo;
        }

        public async Task<List<Blog>> Handle(
            UpsertBlogsCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<Blog>();

            foreach (var blog in request.Blogs)
            {
                if (blog.Id > 0)
                {
                    var updated = await _blogrepo.UpdateIfExistsAsync(blog);

                    if (updated != null)
                    {
                        result.Add(updated);
                    }
                    else
                    {
                        var created = await _blogrepo.CreateAsync(new Blog
                        {
                            Name=blog.Name,
                            Age=blog.Age,
                            Content=blog.Content
                        });
                        result.Add(created);
                    }
                }
                else
                {
                    var created = await _blogrepo.CreateAsync(new Blog
                    {
                        Name = blog.Name,
                        Age = blog.Age,
                        Content = blog.Content
                    });
                    result.Add(created);
                }
            }

            return result;
        }
    }
}
