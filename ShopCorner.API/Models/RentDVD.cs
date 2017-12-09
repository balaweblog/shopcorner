using FluentValidation.Attributes;
using ShopCorner.API.Validators.Rental;

namespace ShopCorner.API.Models
{
    [Validator(typeof(RentaDVDValidator))]
    public class RentDVD
    {
        public int InventoryId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int RentalId { get; set; }
    }
}