using MediatR;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Commands
{
    public record BulkDeleteBlogCommand(List<int> Ids) : IRequest<bool>;
}
