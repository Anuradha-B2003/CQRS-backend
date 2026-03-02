using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsHandler : IRequestHandler<GetAllBlogsQuery, List<Blog>>
    {
        private readonly IBlogrepo _blogrepo;

        public GetAllBlogsHandler(IBlogrepo blogrepo)
        {
            _blogrepo = blogrepo;
        }

        public async Task<List<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _blogrepo.GetAllAsync();
        }
    }
}
