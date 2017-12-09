using FluentValidation;
using ShopCorner.API.Models;

namespace ShopCorner.API.Validators.Rental
{
    public class RentaDVDValidator:AbstractValidator<RentDVD>
    {
        public RentaDVDValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id cannot be empty").WithErrorCode(System.Net.HttpStatusCode.BadRequest.ToString());
            RuleFor(x => x.InventoryId).NotEmpty().WithMessage("Inventory Id cannot be empty");
            RuleFor(x => x.RentalId).NotEmpty().WithMessage("Rental Id cannot be empty");
            RuleFor(x => x.StaffId).NotEmpty().WithMessage("Staff Id cannot be empty");
        }
    }
}