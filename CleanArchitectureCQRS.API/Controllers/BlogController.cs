using CleanArchitectureCQRS.API.Responses;
using CleanArchitectureCQRS.Application.Blogs.Commands;
using CleanArchitectureCQRS.Application.Features.Blogs.Commands;
using CleanArchitectureCQRS.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitectureCQRS.Domain.Entities;
using CleanArchitectureCQRS.Infrastructure.Repositories;
using FluentValidation;
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
            return Ok(ApiResponse<IEnumerable<Blog>>
        .SuccessResponse(blogs, "Blogs retrieved successfully"));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
           
                var result = await _mediator.Send(command);
                return Ok(ApiResponse<Blog>.SuccessResponse(result, "Blog created successfully"));
            
           
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {

            if (id != command.Id)
                return BadRequest(ApiResponse<string>
            .FailureResponse("Id mismatch")); ;

            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound(ApiResponse<string>
            .FailureResponse("Blog not found")); ;

            return Ok(ApiResponse<Blog>.SuccessResponse(result, "Blog updated successfully"));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBlogCommand(id));

            if (!result)
                return NotFound(ApiResponse<string>
        .FailureResponse("Blog not found"));

            return Ok(ApiResponse<string>
        .SuccessResponse(null, "Blog deleted successfully"));
        }
        [HttpPost]
        public async Task<IActionResult> BulkDelete(BulkDeleteBlogCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound(ApiResponse<string>
                    .FailureResponse("No blogs found to delete"));

            return Ok(ApiResponse<string>
                .SuccessResponse(null, "Blogs deleted successfully"));
        }
        [HttpPost("Upsert")]
        public async Task<IActionResult> Upsert(UpsertBlogsCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(ApiResponse<List<Blog>>.SuccessResponse(
                result,
                "Blogs upserted successfully"
            ));
        }

    }
}
