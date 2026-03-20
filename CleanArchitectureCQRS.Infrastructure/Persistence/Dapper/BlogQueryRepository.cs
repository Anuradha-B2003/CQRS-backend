using CleanArchitectureCQRS.Application.Interfaces;
using CleanArchitectureCQRS.Domain.Entities;
using Dapper;

namespace CleanArchitectureCQRS.Infrastructure.Persistence.Dapper
{
    public class BlogQueryRepository : IBlogQueryRepository
    {
        private readonly DapperContext _context;

        public BlogQueryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            var query = "SELECT Id, Name, Age, Content FROM Blogs";

            using var connection = _context.CreateConnection();

            var blogs = await connection.QueryAsync<Blog>(query);

            return blogs.ToList();
        }
    }
}
