using FluentValidation;
using ShopCorner.API.Models;
using System.Net;

namespace ShopCorner.API.Validators.Store
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(e => e.FirstName)
              .NotEmpty().WithMessage("first name cannot be empty")
              .Length(1, 45).WithMessage("first name cannot exceed 45 characters.")
              .Matches(@"^[A-Za-z\-\.\s]+$").WithMessage("first name must contain charactes only.")
              .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.LastName)
              .NotEmpty().WithMessage("last name cannot be empty")
              .Length(1, 45).WithMessage("last name cannot exceed 45 characters.")
              .Matches(@"^[A-Za-z\-\.\s]+$").WithMessage("last name must contain charactes only.")
              .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("email cannot be empty")
                .EmailAddress().WithMessage("valid email address is required")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.StoreId)
             .NotNull().WithMessage("store id cannot be empty")
             .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.AddressId)
             .NotNull().WithMessage("address id cannot be empty")
             .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.Active)
             .NotNull().WithMessage("active cannot be empty")
             .WithErrorCode(HttpStatusCode.BadRequest.ToString());


        }
    }
}