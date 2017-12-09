using FluentValidation;
using ShopCorner.API.Models;
using System.Net;

namespace ShopCorner.API.Validators.Store
{
    public class CityValidator: AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(e => e.CityName)
              .NotEmpty().WithMessage("city name cannot be empty")
              .Length(1, 50).WithMessage("city name cannot exceed 50 characters.")
              .Matches(@"^[A-Za-z\-\.\s]+$").WithMessage("city name must contain charactes only.")
              .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(e => e.CountryId)
             .NotEmpty().WithMessage("country Id cannot be empty")
             .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}