using System;
using CleanArchitectureCQRS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Domain.Interfaces
{
    public interface IBlogrepo
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<Blog?> UpdateAsync(int id, Blog blog);
        Task<bool> DeleteAsync(int id);
    }
}
