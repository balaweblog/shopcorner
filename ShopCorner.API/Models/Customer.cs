using FluentValidation.Attributes;
using ShopCorner.API.Validators.Store;

namespace ShopCorner.API.Models
{
    [Validator(typeof(CustomerValidator))]
    public class Customer
    {
        public int StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
        public int Active { get; set; }
    }
}