using System.Net.Http;
using System.Web.Http;
using ShopCorner.DB;
using ShopCorner.DB.Models;
using ShopCorner.API.Models;
using System;
using System.Net;
using ShopCorner.API.Validators.Rental;

namespace ShopCorner.API.Controllers
{
    public class RentalController : ApiController
    {
        private static dvdrentalentities dvdrentalentities;
        private static RentaDVDValidator rentalvalidator;
        public RentalController()
        {
            dvdrentalentities = new dvdrentalentities();
            rentalvalidator = new Validators.Rental.RentaDVDValidator();
        }

        [HttpPost]
        public HttpResponseMessage RentaDVD([FromBody]RentDVD rentdvd)
        {
                HttpResponseMessage response =null;
                bool isInventoryExists = dvdrentalentities.IsInventoryinStock(rentdvd.InventoryId);
                decimal dc = dvdrentalentities.GetCustomerBalance(rentdvd.CustomerId);
                if (isInventoryExists)
                {
                    dvdrentalentities.Rentals.Add(new Rental()
                    {
                        RentalDate = DateTime.Now,
                        InventoryId = rentdvd.InventoryId,
                        CustomerId = rentdvd.CustomerId,
                        StaffId = rentdvd.StaffId
                    });

                    dvdrentalentities.Payments.Add(new Payment()
                    {
                        CustomerId = rentdvd.CustomerId,
                        StaffId = rentdvd.StaffId,
                        RentalId = rentdvd.RentalId,
                        PaymentDate = DateTime.Now
                    });
                    response = Request.CreateResponse(HttpStatusCode.OK, "DVD rented successfully");
                }
            return response;
        }
    }
}
