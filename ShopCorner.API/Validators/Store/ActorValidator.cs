using FluentValidation;
using ShopCorner.API.Models;
using System.Net;

namespace ShopCorner.API.Validators.Store
{
    public class ActorValidator: AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("actor first name cannot be empty")
                .Length(1,45).WithMessage("first name cannot exceed 45 characters.")
                .Matches(@"^[A-Za-z\-\.\s]+$").WithMessage("name must contain characters only")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("actor last name cannot be empty")
                .Length(1,45).WithMessage("last name cannot exceed 45 characters.")
                .Matches(@"^[A-Za-z\-\.\s]+$").WithMessage("name must contain characters only")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}