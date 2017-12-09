using FluentValidation;
using ShopCorner.API.Models;
using System.Net;

namespace ShopCorner.API.Validators.Store
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(e => e.Title)
              .NotEmpty().WithMessage("title cannot be empty")
              .Length(1, 255).WithMessage("title cannot exceed 255 characters.")
              .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.Description)
              .NotEmpty().WithMessage("description cannot be empty")
              .Length(1, 400).WithMessage("description cannot exceed 400 characters.")
              .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.ReleaseYear)
            .NotNull().WithMessage("release year cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.LanguageId)
          .NotNull().WithMessage("language id cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.RentalDuration)
          .NotNull().WithMessage("rental duration cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.RentalRate)
          .NotNull().WithMessage("rental rate cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.Length)
          .NotNull().WithMessage("movie length cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.ReplacementCost)
          .NotNull().WithMessage("active cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.CategoryId)
          .NotNull().WithMessage("category id cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.ActorId)
          .NotNull().WithMessage("actor id cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(e => e.ReplacementCost)
          .NotNull().WithMessage("replacement cost cannot be empty")
          .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}