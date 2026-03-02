using CleanArchitectureCQRS.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Commands
{
    public class DeleteBlogCommandHandler
        : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IBlogrepo _blogrepo;

        public DeleteBlogCommandHandler(IBlogrepo blogrepo)
        {
            _blogrepo = blogrepo;
        }

        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await _blogrepo.DeleteAsync(request.Id);
        }
    }

}
