using CleanArchitectureCQRS.Application.Blogs.Commands;
using CleanArchitectureCQRS.Application.Features.Blogs.Commands;
using CleanArchitectureCQRS.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitectureCQRS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureCQRS.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _mediator.Send(new GetAllBlogsQuery());
            return Ok(blogs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {

            if (id != command.Id)
                return BadRequest("Id mismatch");

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBlogCommand(id));

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
