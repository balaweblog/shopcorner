using FluentValidation.WebApi;
using ShopCorner.API.App_Start;
using System.Web.Http;

namespace ShopCorner.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new ValidateModelStateFilter());
            config.Filters.Add(new LoggingFilterAttribute());
            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
