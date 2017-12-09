using FluentValidation;
using ShopCorner.API.Models;
using System.Net;

namespace ShopCorner.API.Validators.Store
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(e => e.Name)
              .NotEmpty().WithMessage("name cannot be empty")
              .Length(1, 25).WithMessage("name cannot exceed 25 characters.")
              .Matches(@"^[A-Za-z\-\.\s]+$").WithMessage("name must contain charactes only.")
              .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}