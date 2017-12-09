using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopCorner.API.Controllers;
using ShopCorner.API.Models;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace ShopCorner.Testing
{
    [TestClass]
    public class TestStoreController
    {
        private static StoreController storecontroller;
        private  static Dictionary<string, Actor> actorvariable = new Dictionary<string, Actor>();
        private static Dictionary<string, Category> categoryvariable = new Dictionary<string, Category>();
        private static Dictionary<string, Country> countryvariable = new Dictionary<string, Country>();
        private static Dictionary<string, City> cityvariable = new Dictionary<string, City>();
        private static Dictionary<string, Customer> customervariable = new Dictionary<string, Customer>();
        private static Dictionary<string, Film> filmvariable = new Dictionary<string, Film>();
         
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            storecontroller = new StoreController();
            storecontroller.Request = new HttpRequestMessage();
            storecontroller.Configuration = new HttpConfiguration();
            actorvariable.Add("valid", new Actor() { FirstName = "sammy", LastName = "ss" });
            categoryvariable.Add("valid", new Category() { Name = "sam" });
            countryvariable.Add("valid", new Country() { CountryName = "seddd" });
            cityvariable.Add("valid", new City() { CityName = "test",CountryId=1 });
            customervariable.Add("valid", new Customer() { FirstName = "test", LastName = "test", Active = 1, AddressId = 1, Email = "teswt1@test.com", StoreId = 1 });
            filmvariable.Add("valid", new Film()
            {
                ActorId = 1,
                CategoryId = 1,
                LanguageId = 1,
                Description = "test",
                RentalDuration = 1,
                SpecialFeatures = "{test,test1}",
                Length = 1,
                Rating = "G",
                ReleaseYear = 2000,
                RentalRate = 1,
                ReplacementCost = 1,
                Title = "tddesdtddd"
            });
        }
        #region Actor Test Controller
        [TestMethod]
        public void Test_GetActorsbyFirstName_ReturnNoActor()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "No actors available for the requested first name" });
            HttpResponseMessage result = storecontroller.GetActorsbyFirstName(actorvariable["valid"].FirstName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PutActor_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "Actor not found for update" });
            HttpResponseMessage result = storecontroller.PutActors(actorvariable["valid"], actorvariable["valid"].FirstName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteActor_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "Actor not found for delete" });
            HttpResponseMessage result = storecontroller.DeleteActor(actorvariable["valid"].FirstName, actorvariable["valid"].LastName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostActor_NewActor()
        {
            string actual = new JavaScriptSerializer().Serialize("Actor added");
            HttpResponseMessage result = storecontroller.PostActor(actorvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostActor_ExistingActor()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "Actor available already" });
            HttpResponseMessage result = storecontroller.PostActor(actorvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_GetActors_ShouldReturnAllActors()
        {
            HttpResponseMessage result = storecontroller.GetActors();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Actor>>().Result.Count>0);
        }
        [TestMethod]
        public void Test_GetActorsbyFirstName_ReturnOneActor()
        {
            HttpResponseMessage result = storecontroller.GetActorsbyFirstName(actorvariable["valid"].FirstName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Actor>>().Result.Count >=1);
        }
        [TestMethod]
        public void Test_PutActor_OldActor()
        {
            string actual = new JavaScriptSerializer().Serialize("Actor updated");
            HttpResponseMessage result = storecontroller.PutActors(actorvariable["valid"], actorvariable["valid"].FirstName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteActor_OldActor()
        {
            string actual = new JavaScriptSerializer().Serialize("Actor deleted");
            HttpResponseMessage result = storecontroller.DeleteActor(actorvariable["valid"].FirstName, actorvariable["valid"].LastName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        #endregion Actor Test Controller

        #region Category Test Controller
        [TestMethod]
        public void Test_GetCategorybyFirstName_ReturnNoCountry()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "No categories available for the given category name" });
            HttpResponseMessage result = storecontroller.GetCategorybyName(categoryvariable["valid"].Name);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PutCategory_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "Category not found for update" });
            HttpResponseMessage result = storecontroller.PutCategory(categoryvariable["valid"], categoryvariable["valid"].Name);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCategory_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "category not found for delete" });
            HttpResponseMessage result = storecontroller.DeleteCategory(categoryvariable["valid"].Name);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCategory_NewCategory()
        {
            string actual = new JavaScriptSerializer().Serialize("category added");
            HttpResponseMessage result = storecontroller.PostCategory(categoryvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCategory_ExistingCategory()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "category available already" });
            HttpResponseMessage result = storecontroller.PostCategory(categoryvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_GetCategory_ShouldReturnAllCategories()
        {
            HttpResponseMessage result = storecontroller.GetCategories();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Category>>().Result.Count > 0);
        }
        [TestMethod]
        public void Test_GetCategorybyName_ReturnOneCategory()
        {
            HttpResponseMessage result = storecontroller.GetCategorybyName(categoryvariable["valid"].Name);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Category>>().Result.Count >= 1);
        }
        [TestMethod]
        public void Test_PutCategory_OldCategory()
        {
            string actual = new JavaScriptSerializer().Serialize("category updated");
            HttpResponseMessage result = storecontroller.PutCategory(categoryvariable["valid"], categoryvariable["valid"].Name);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCategory_OldCategory()
        {
            string actual = new JavaScriptSerializer().Serialize("categories deleted");
            HttpResponseMessage result = storecontroller.DeleteCategory(categoryvariable["valid"].Name);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        #endregion Category Test Controller

        #region Country Test Controller
        [TestMethod]
        public void Test_GetCountrybyFirstName_ReturnNoCountry()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "No country available for the given country name" });
            HttpResponseMessage result = storecontroller.GetCountrybyName(countryvariable["valid"].CountryName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PutCountry_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "country not found for update" });
            HttpResponseMessage result = storecontroller.PutCountry(countryvariable["valid"], countryvariable["valid"].CountryName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCountry_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "country not found for delete" });
            HttpResponseMessage result = storecontroller.DeleteCountry(countryvariable["valid"].CountryName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCountry_NewCountry()
        {
            string actual = new JavaScriptSerializer().Serialize("country added");
            HttpResponseMessage result = storecontroller.PostCountry(countryvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCountry_ExistingCountry()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "country available already" });
            HttpResponseMessage result = storecontroller.PostCountry(countryvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_GetCountry_ShouldReturnAllCountry()
        {
            HttpResponseMessage result = storecontroller.Getcountries();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Country>>().Result.Count > 0);
        }
        [TestMethod]
        public void Test_GetCountrybyName_ReturnOneCountry()
        {
            HttpResponseMessage result = storecontroller.GetCountrybyName(countryvariable["valid"].CountryName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Country>>().Result.Count >= 1);
        }
        [TestMethod]
        public void Test_PutCountry_OldCountry()
        {
            string actual = new JavaScriptSerializer().Serialize("country updated");
            HttpResponseMessage result = storecontroller.PutCountry(countryvariable["valid"], countryvariable["valid"].CountryName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCountry_OldCountry()
        {
            string actual = new JavaScriptSerializer().Serialize("country deleted");
            HttpResponseMessage result = storecontroller.DeleteCountry(countryvariable["valid"].CountryName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        #endregion Country Test Controller

        #region City Test Controller
        [TestMethod]
        public void Test_GetCitybyFirstName_ReturnNoCity()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "No city available for the given city name" });
            HttpResponseMessage result = storecontroller.GetCitybyName(cityvariable["valid"].CityName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PutCity_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "city not found for update" });
            HttpResponseMessage result = storecontroller.PutCity(cityvariable["valid"], cityvariable["valid"].CityName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCity_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "city not found for delete" });
            HttpResponseMessage result = storecontroller.DeleteCity(cityvariable["valid"].CityName);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCity_NewCity()
        {
            string actual = new JavaScriptSerializer().Serialize("city added");
            HttpResponseMessage result = storecontroller.PostCity(cityvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCity_ExistingCity()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "city available already" });
            HttpResponseMessage result = storecontroller.PostCity(cityvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_GetCity_ShouldReturnAllCity()
        {
            HttpResponseMessage result = storecontroller.GetCities();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<City>>().Result.Count > 0);
        }
        [TestMethod]
        public void Test_GetCitybyName_ReturnOneCity()
        {
            HttpResponseMessage result = storecontroller.GetCitybyName(cityvariable["valid"].CityName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<City>>().Result.Count >= 1);
        }
        [TestMethod]
        public void Test_PutCity_OldCity()
        {
            string actual = new JavaScriptSerializer().Serialize("city updated");
            HttpResponseMessage result = storecontroller.PutCity(cityvariable["valid"], cityvariable["valid"].CityName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCity_OldCity()
        {
            string actual = new JavaScriptSerializer().Serialize("city deleted");
            HttpResponseMessage result = storecontroller.DeleteCity(cityvariable["valid"].CityName);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        #endregion City Test Controller

        #region Customer Test Controller
        [TestMethod]
        public void Test_GetCustomerbyEmail_ReturnNoCustomer()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "No customer available for the given email address." });
            HttpResponseMessage result = storecontroller.GetCustomerbyEmail(customervariable["valid"].Email);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PutCustomer_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "customer not found for update" });
            HttpResponseMessage result = storecontroller.PutCustomer(customervariable["valid"], customervariable["valid"].Email);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCustomer_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "customer not found for delete" });
            HttpResponseMessage result = storecontroller.DeleteCustomer(customervariable["valid"].Email);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCustomer_NewCustomer()
        {
            string actual = new JavaScriptSerializer().Serialize("customer added");
            HttpResponseMessage result = storecontroller.PostCustomer(customervariable["valid"]);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostCustomer_ExistingCustomer()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "customer available already" });
            HttpResponseMessage result = storecontroller.PostCustomer(customervariable["valid"]);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_GetCustomer_ShouldReturnAllCustomer()
        {
            HttpResponseMessage result = storecontroller.GetCustomer();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Customer>>().Result.Count > 0);
        }
        [TestMethod]
        public void Test_GetCustomerybyEmail_ReturnOneCustomer()
        {
            HttpResponseMessage result = storecontroller.GetCustomerbyEmail(customervariable["valid"].Email);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Customer>>().Result.Count >= 1);
        }
        [TestMethod]
        public void Test_PutCustomer_OldCustomer()
        {
            string actual = new JavaScriptSerializer().Serialize("customer updated");
            HttpResponseMessage result = storecontroller.PutCustomer(customervariable["valid"], customervariable["valid"].Email);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteCustomer_OldCustomer()
        {
            string actual = new JavaScriptSerializer().Serialize("customer deleted");
            HttpResponseMessage result = storecontroller.DeleteCustomer(customervariable["valid"].Email);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        #endregion Customer Test Controller

        #region Film Test Controller
        [TestMethod]
        public void Test_GetFilmbyName_ReturnNoFilm()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "No film available for the given title." });
            HttpResponseMessage result = storecontroller.GetFilmbyName(filmvariable["valid"].Title);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PutFilm_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "film not found for update" });
            HttpResponseMessage result = storecontroller.PutFilm(filmvariable["valid"], filmvariable["valid"].Title);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteFilm_NotFound()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "film not found for delete" });
            HttpResponseMessage result = storecontroller.DeleteFilm(filmvariable["valid"].Title);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostFilm_NewFilm()
        {
            string actual = new JavaScriptSerializer().Serialize("film added");
            HttpResponseMessage result = storecontroller.PostFilm(filmvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_PostFilm_ExistingFilm()
        {
            string actual = new JavaScriptSerializer().Serialize(new Response() { Message = "film available already" });
            HttpResponseMessage result = storecontroller.PostFilm(filmvariable["valid"]);
            Assert.AreEqual(HttpStatusCode.Conflict, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_GetFilm_ShouldReturnAllFilm()
        {
            HttpResponseMessage result = storecontroller.GetFilms();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Film>>().Result.Count > 0);
        }
        [TestMethod]
        public void Test_GetFilmbyName_ReturnOneFilm()
        {
            HttpResponseMessage result = storecontroller.GetFilmbyName(filmvariable["valid"].Title);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Content.ReadAsAsync<List<Customer>>().Result.Count >= 1);
        }
        [TestMethod]
        public void Test_PutFilm_OldFilm()
        {
            string actual = new JavaScriptSerializer().Serialize("film updated");
            HttpResponseMessage result = storecontroller.PutFilm(filmvariable["valid"], filmvariable["valid"].Title);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        [TestMethod]
        public void Test_DeleteFilm_OldFilm()
        {
            string actual = new JavaScriptSerializer().Serialize("film deleted");
            HttpResponseMessage result = storecontroller.DeleteFilm(filmvariable["valid"].Title);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(actual, result.Content.ReadAsStringAsync().Result);
        }
        #endregion Film Test Controller

    }
}
