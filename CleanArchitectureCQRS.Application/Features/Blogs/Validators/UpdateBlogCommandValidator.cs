using FluentValidation;
using CleanArchitectureCQRS.Application.Features.Blogs.Commands;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Validators
{
    public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Valid Id is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0");
        }
    }
}
