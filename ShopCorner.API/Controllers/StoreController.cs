using ShopCorner.API.Models;
using ShopCorner.DB;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopCorner.API.Controllers
{
    [RoutePrefix("api/store")]
    public class StoreController : ApiController
    {
        private static dvdrentalentities dvdrentalentities;
        private static HttpResponseMessage response;
        public StoreController()
        {
        
            dvdrentalentities = new dvdrentalentities();
            response = new HttpResponseMessage();
        }
        #region Actor Verbs
        [HttpGet]
        [Route("actor")]
        public HttpResponseMessage GetActors()
        {
            var actors = dvdrentalentities.Actors.ToList();
            response = actors.Count > 1 ? Request.CreateResponse(HttpStatusCode.OK, actors) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No actors available");
            return response;
        }
        [HttpGet]
        [Route("actor/{firstname}")]
        public HttpResponseMessage GetActorsbyFirstName([FromUri]string firstname)
        {
            var actors = dvdrentalentities.Actors.Where(e=>e.First_Name == firstname).ToList();
            response = actors.Count > 0 ? Request.CreateResponse(HttpStatusCode.OK, actors) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No actors available for the requested first name");
            return response;
        }
        [HttpPost]
        [Route("actor")]
        public HttpResponseMessage PostActor([FromBody]Actor actor)
        {
            var actors = dvdrentalentities.Actors.Where(e => e.First_Name == actor.FirstName && e.Last_Name == actor.LastName);
            if (actors.Count() > 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, "Actor available already");
                return response;
            }
            dvdrentalentities.Actors.Add(new DB.Models.Actor() { First_Name = actor.FirstName, Last_Name = actor.LastName });
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "Actor added");
            return response;
        }
        [HttpPut]
        [Route("actor")]
        public HttpResponseMessage PutActors([FromBody]Actor actor, string firstname)
        {
            var actors = dvdrentalentities.Actors.Where(e => e.First_Name == firstname);
            if (actors.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Actor not found for update");
                return response;
            }
            dvdrentalentities.Actors.Where(e => e.First_Name == firstname).ToList().ForEach(x => { x.Last_Name = actor.LastName; x.First_Name = actor.FirstName;});
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "Actor updated");
            return response;
        }
        [HttpDelete]
        [Route("actors")]
        public HttpResponseMessage DeleteActor(string firstname,string lastname)
        {
            var actors = dvdrentalentities.Actors.Where(e => e.First_Name == firstname && e.Last_Name == lastname).ToList();
            if(actors.Count()<1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Actor not found for delete");
                return response;
            }
            dvdrentalentities.Actors.RemoveRange(actors);
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK,"Actor deleted");
            return response;
        }
        #endregion Actor Verbs

        #region Category Verbs
        [HttpGet]
        [Route("category")]
        public HttpResponseMessage GetCategories()
        {
            var categories = dvdrentalentities.Categories.ToList();
            response = categories.Count > 1 ? Request.CreateResponse(HttpStatusCode.OK, categories) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No categories available");
            return response;
        }
        [HttpGet]
        [Route("category/{name}")]
        public HttpResponseMessage GetCategorybyName([FromUri]string name)
        {
            var category = dvdrentalentities.Categories.Where(e => e.Name == name).ToList();
            response = category.Count > 0 ? Request.CreateResponse(HttpStatusCode.OK, category) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No categories available for the given category name");
            return response;
        }
        [HttpPost]
        [Route("category")]
        public HttpResponseMessage PostCategory([FromBody]Category category)
        {
            var categories = dvdrentalentities.Categories.Where(e => e.Name == category.Name);
            if (categories.Count() > 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, "category available already");
                return response;
            }
            dvdrentalentities.Categories.Add(new DB.Models.Category() { Name = category.Name});
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "category added");
            return response;
        }
        [HttpPut]
        [Route("category")]
        public HttpResponseMessage PutCategory([FromBody]Category category, string name)
        {
            var categories = dvdrentalentities.Categories.Where(e => e.Name == name);
            if (categories.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category not found for update");
                return response;
            }
            dvdrentalentities.Categories.Where(e => e.Name == name).ToList().ForEach(x => { x.Name = category.Name;});
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "category updated");
            return response;
        }
        [HttpDelete]
        [Route("category")]
        public HttpResponseMessage DeleteCategory(string name)
        {
            var categories = dvdrentalentities.Categories.Where(e => e.Name == name).ToList();
            if (categories.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "category not found for delete");
                return response;
            }
            dvdrentalentities.Categories.RemoveRange(categories);
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "categories deleted");
            return response;
        }
        #endregion Actor Verbs

        #region Country Verbs
        [HttpGet]
        [Route("country")]
        public HttpResponseMessage Getcountries()
        {
            var countries = dvdrentalentities.Countries.ToList();
            response = countries.Count > 1 ? Request.CreateResponse(HttpStatusCode.OK, countries) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No country available");
            return response;
        }
        [HttpGet]
        [Route("country/{countryname}")]
        public HttpResponseMessage GetCountrybyName([FromUri]string countryname)
        {
            var country = dvdrentalentities.Countries.Where(e => e.CountryName == countryname).ToList();
            response = country.Count > 0 ? Request.CreateResponse(HttpStatusCode.OK, country) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No country available for the given country name");
            return response;
        }
        [HttpPost]
        [Route("country")]
        public HttpResponseMessage PostCountry([FromBody]Country country)
        {
            var countries = dvdrentalentities.Countries.Where(e => e.CountryName == country.CountryName);
            if (countries.Count() > 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, "country available already");
                return response;
            }
            dvdrentalentities.Countries.Add(new DB.Models.Country() { CountryName = country.CountryName });
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "country added");
            return response;
        }
        [HttpPut]
        [Route("country")]
        public HttpResponseMessage PutCountry([FromBody]Country country, string countryname)
        {
            var countries = dvdrentalentities.Countries.Where(e => e.CountryName == countryname);
            if (countries.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "country not found for update");
                return response;
            }
            dvdrentalentities.Countries.Where(e => e.CountryName == countryname).ToList().ForEach(x => { x.CountryName = country.CountryName; });
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "country updated");
            return response;
        }
        [HttpDelete]
        [Route("country")]
        public HttpResponseMessage DeleteCountry(string countryname)
        {
            var countries = dvdrentalentities.Countries.Where(e => e.CountryName == countryname).ToList();
            if (countries.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "country not found for delete");
                return response;
            }
            dvdrentalentities.Countries.RemoveRange(countries);
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "country deleted");
            return response;
        }
        #endregion Country Verbs

        #region City Verbs
        [HttpGet]
        [Route("city")]
        public HttpResponseMessage GetCities()
        {
            var cities = dvdrentalentities.Cities.ToList();
            response = cities.Count > 1 ? Request.CreateResponse(HttpStatusCode.OK, cities) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No city available");
            return response;
        }
        [HttpGet]
        [Route("city/{cityname}")]
        public HttpResponseMessage GetCitybyName([FromUri]string cityname)
        {
            var city = dvdrentalentities.Cities.Where(e => e.CityName == cityname).ToList();
            response = city.Count > 0 ? Request.CreateResponse(HttpStatusCode.OK, city) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No city available for the given city name");
            return response;
        }
        [HttpPost]
        [Route("city")]
        public HttpResponseMessage PostCity([FromBody]City city)
        {
            var cities = dvdrentalentities.Cities.Where(e => e.CityName == city.CityName);
            if (cities.Count() > 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, "city available already");
                return response;
            }
            dvdrentalentities.Cities.Add(new DB.Models.City() { CityName = city.CityName ,CountryId = city.CountryId});
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "city added");
            return response;
        }
        [HttpPut]
        [Route("city")]
        public HttpResponseMessage PutCity([FromBody]City country, string cityname)
        {
            var cities = dvdrentalentities.Cities.Where(e => e.CityName == cityname);
            if (cities.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "city not found for update");
                return response;
            }
            dvdrentalentities.Cities.Where(e => e.CityName == cityname).ToList().ForEach(x => { x.CityName = country.CityName; x.CountryId = country.CountryId; });
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "city updated");
            return response;
        }
        [HttpDelete]
        [Route("city")]
        public HttpResponseMessage DeleteCity(string cityname)
        {
            var cities = dvdrentalentities.Cities.Where(e => e.CityName == cityname).ToList();
            if (cities.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "city not found for delete");
                return response;
            }
            dvdrentalentities.Cities.RemoveRange(cities);
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "city deleted");
            return response;
        }
        #endregion City Verbs

        #region Customer Verbs
        [HttpGet]
        [Route("customer")]
        public HttpResponseMessage GetCustomer()
        {
            var customers = dvdrentalentities.Customers.ToList();
            response = customers.Count > 1 ? Request.CreateResponse(HttpStatusCode.OK, customers) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No customer available");
            return response;
        }
        [HttpGet]
        [Route("customer/{emailaddress}")]
        public HttpResponseMessage GetCustomerbyEmail([FromUri]string emailaddress)
        {
            var customer = dvdrentalentities.Customers.Where(e => e.Email == emailaddress).ToList();
            response = customer.Count > 0 ? Request.CreateResponse(HttpStatusCode.OK, customer) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No customer available for the given email address.");
            return response;
        }
        [HttpPost]
        [Route("customer")]
        public HttpResponseMessage PostCustomer([FromBody]Customer cust)
        {
            var customer = dvdrentalentities.Customers.Where(e => e.Email == cust.Email);
            if (customer.Count() > 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, "customer available already");
                return response;
            }
            dvdrentalentities.Customers.Add(new DB.Models.Customer() { Email = cust.Email,FirstName = cust.FirstName,LastName = cust.LastName,
            Active = cust.Active,AddressId = cust.AddressId,StoreId = cust.StoreId});
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "customer added");
            return response;
        }
        [HttpPut]
        [Route("customer")]
        public HttpResponseMessage PutCustomer([FromBody]Customer customer, string emailaddress)
        {
            var customers = dvdrentalentities.Customers.Where(e => e.Email == emailaddress);
            if (customers.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "customer not found for update");
                return response;
            }
            dvdrentalentities.Customers.Where(e => e.Email == emailaddress).ToList().ForEach(x => { x.Email = customer.Email; x.FirstName = customer.FirstName;
                x.LastName = customer.LastName;x.Active = customer.Active;x.AddressId = customer.AddressId;x.StoreId = customer.StoreId;
            });
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "customer updated");
            return response;
        }
        [HttpDelete]
        [Route("customer")]
        public HttpResponseMessage DeleteCustomer(string emailaddress)
        {
            var customers = dvdrentalentities.Customers.Where(e => e.Email == emailaddress).ToList();
            if (customers.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "customer not found for delete");
                return response;
            }
            dvdrentalentities.Customers.RemoveRange(customers);
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "customer deleted");
            return response;
        }
        #endregion Customer Verbs

        #region Film Verbs
        [HttpGet]
        [Route("film")]
        public HttpResponseMessage GetFilms()
        {
            var films = dvdrentalentities.Films.ToList();
            response = films.Count > 1 ? Request.CreateResponse(HttpStatusCode.OK, films) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No film available");
            return response;
        }
        [HttpGet]
        [Route("film/{name}")]
        public HttpResponseMessage GetFilmbyName([FromUri]string name)
        {
            var films = dvdrentalentities.Films.Where(e => e.Title == name).ToList();
            response = films.Count > 0 ? Request.CreateResponse(HttpStatusCode.OK, films) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "No film available for the given title.");
            return response;
        }
        [HttpPost]
        [Route("film")]
        public HttpResponseMessage PostFilm([FromBody]Film film)
        {
            var films = dvdrentalentities.Films.Where(e => e.Title == film.Title);
            if (films.Count() > 0)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict, "film available already");
                return response;
            }
            dvdrentalentities.Films.Add(new DB.Models.Film()
            {
                Title = film.Title,
                Description = film.Description,
                Length = film.Length,
                RentalDuration = film.RentalDuration,
                Rating = film.Rating,
                RentalRate = film.RentalRate,
                ReleaseYear = film.ReleaseYear,
                ReplacementCost = film.ReplacementCost,
                SpecialFeatures = film.SpecialFeatures,
                LanguageId = film.LanguageId
                
            });
            dvdrentalentities.SaveChanges();

            //int filmsId = dvdrentalentities.Films.Where(e => e.Title == film.Title).FirstOrDefault().FilmId;
            //dvdrentalentities.FilmActors.Add(new DB.Models.FilmActor() {FilmId = filmsId,ActorId = 1 });
            //dvdrentalentities.FilmCategories.Add(new DB.Models.FilmCategory() { FilmId = filmsId, CategoryId = 1 });
            //dvdrentalentities.SaveChanges();

            response = Request.CreateResponse(HttpStatusCode.OK, "film added");
            return response;
        }
        [HttpPut]
        [Route("film")]
        public HttpResponseMessage PutFilm([FromBody]Film film, string title)
        {
            var films= dvdrentalentities.Films.Where(e => e.Title == title);
            if (films.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "film not found for update");
                return response;
            }
            int filmid = films.FirstOrDefault().FilmId;
            dvdrentalentities.Films.Where(e => e.Title == title).ToList().ForEach(x => {
                x.Title = film.Title; x.Description = film.Description;
                x.Length = film.Length; x.Rating = film.Rating; x.ReleaseYear = film.ReleaseYear; x.RentalDuration = film.RentalDuration;
                x.ReplacementCost = film.ReplacementCost;x.SpecialFeatures = film.SpecialFeatures; x.RentalRate = film.RentalRate;
            });
            dvdrentalentities.FilmActors.Where(e => e.FilmId == filmid).ToList().ForEach(x => { x.ActorId = film.ActorId; });
            dvdrentalentities.FilmCategories.Where(e => e.FilmId == filmid).ToList().ForEach(x => { x.CategoryId = film.CategoryId; });
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "film updated");
            return response;
        }
        [HttpDelete]
        [Route("film")]
        public HttpResponseMessage DeleteFilm(string name)
        {
            var films = dvdrentalentities.Films.Where(e => e.Title == name).ToList();
            if (films.Count() < 1)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "film not found for delete");
                return response;
            }
            dvdrentalentities.Films.RemoveRange(films);
            dvdrentalentities.SaveChanges();
            response = Request.CreateResponse(HttpStatusCode.OK, "film deleted");
            return response;
        }
        #endregion Films Verbs
    }
}
