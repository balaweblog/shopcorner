using FluentValidation.Attributes;
using ShopCorner.API.Validators.Store;

namespace ShopCorner.API.Models
{
    [Validator(typeof(CountryValidator))]
    public class Country
    {
        public string CountryName { get; set; }
    }
}