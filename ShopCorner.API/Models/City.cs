using FluentValidation.Attributes;
using ShopCorner.API.Validators.Store;

namespace ShopCorner.API.Models
{
    [Validator(typeof(CityValidator))]
    public class City
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}