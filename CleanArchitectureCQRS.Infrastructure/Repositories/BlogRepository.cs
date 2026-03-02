using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Domain.Interfaces;
using CleanArchitectureCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Infrastructure.Repositories
{
    public class BlogRepository : IBlogrepo
    {
        private readonly BlogDBContext _context;

        public BlogRepository(BlogDBContext context)
        {
            _context = context;
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
                if(blog==null)
                {
                    return false;
            }
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs
                .FindAsync(id);
        }

        public async Task<Blog?> UpdateAsync(int id, Blog blog)
        {
            var existingBlog = await _context.Blogs.FindAsync(id);

            if (existingBlog == null)
                return null;

            existingBlog.Name = blog.Name;
            existingBlog.Age = blog.Age;
            existingBlog.Content = blog.Content;

            await _context.SaveChangesAsync();

            return existingBlog;

        }
    }
}
