using CleanArchitectureCQRS.Domain.Entities;

namespace CleanArchitectureCQRS.Application.Interfaces
{
    public interface IBlogQueryRepository
    {
        Task<List<Blog>> GetAllAsync();
    }
}
