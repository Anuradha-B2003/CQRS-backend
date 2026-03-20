using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitectureCQRS.Application.Interfaces;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsHandler : IRequestHandler<GetAllBlogsQuery, List<Blog>>
    {
        private readonly IBlogQueryRepository _blogQueryRepository;

        public GetAllBlogsHandler(IBlogQueryRepository blogQueryRepository)
        {
            _blogQueryRepository = blogQueryRepository;
        }

        public async Task<List<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return await _blogQueryRepository.GetAllAsync();
        }
    }
}
