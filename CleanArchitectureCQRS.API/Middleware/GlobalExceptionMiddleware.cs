using CleanArchitectureCQRS.API.Responses;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace CleanArchitectureCQRS.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var errors = ex.Errors.Select(e => e.ErrorMessage);

                await context.Response.WriteAsJsonAsync(
        ApiResponse<object>.FailureResponse("Validation failed", errors)
    );
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = 400;

                await context.Response.WriteAsJsonAsync(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsJsonAsync(
                    ApiResponse<object>.FailureResponse("Internal server error")
                );
            }
        }
    }
}
