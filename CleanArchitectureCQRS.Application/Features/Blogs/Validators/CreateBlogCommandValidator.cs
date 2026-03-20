using CleanArchitectureCQRS.Application.Blogs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitectureCQRS.Application.Features.Blogs.Validators
{
    public class CreateBlogCommandValidator
       : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required");

            RuleFor(x => x.Age)
                .GreaterThan(0).WithMessage("Age must be greater than 0");
        }
    }
}
