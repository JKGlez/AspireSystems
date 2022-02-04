using System.Web.Http;
using System.Web.Http.Cors;


namespace MWS_API_EF
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // TODO: Check Origin is allowed 
            // If yes, EnableCors

            // Web API configuration and services
            var cors = new EnableCorsAttribute ("http://localhost:4200", "*", "*");
            //var cors = new EnableCorsAttribute ("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //TO REQUIERE VALITATION OF JWT
            config.MessageHandlers.Add(new Controllers.JWT.TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
