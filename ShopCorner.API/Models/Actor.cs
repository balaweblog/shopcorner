using FluentValidation.Attributes;
using ShopCorner.API.Validators.Store;

namespace ShopCorner.API.Models
{
    [Validator(typeof(ActorValidator))]
    public class Actor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}