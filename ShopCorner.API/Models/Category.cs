using FluentValidation.Attributes;
using ShopCorner.API.Validators.Store;

namespace ShopCorner.API.Models
{
    [Validator(typeof(CategoryValidator))]
    public class Category
    {
        public string Name { get; set; }
    }
}