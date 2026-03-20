using CleanArchitectureCQRS.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Commands
{
    public class BulkDeleteBlogCommandHandler
        : IRequestHandler<BulkDeleteBlogCommand, bool>
    {
        private readonly IBlogrepo _blogrepo;

        public BulkDeleteBlogCommandHandler(IBlogrepo blogrepo)
        {
            _blogrepo = blogrepo;
        }

        public async Task<bool> Handle(BulkDeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await _blogrepo.BulkDeleteAsync(request.Ids);
        }
    }
}
