using FluentValidation.Attributes;
using ShopCorner.API.Validators.Store;

namespace ShopCorner.API.Models
{
    [Validator(typeof(FilmValidator))]
    public class Film
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalRate { get; set; }

        public int Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public int ActorId { get; set; }
        public int CategoryId { get; set; }
    }
}