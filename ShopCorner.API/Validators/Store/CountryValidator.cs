using FluentValidation;
using ShopCorner.API.Models;
using System.Net;

namespace ShopCorner.API.Validators.Store
{
    public class CountryValidator: AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(e => e.CountryName)
              .NotEmpty().WithMessage("country name cannot be empty")
              .Length(1, 50).WithMessage("country name cannot exceed 50 characters.")
              .Matches(@"^[A-Za-z\-\.\s]+$").WithMessage("country name must contain charactes only.")
              .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}