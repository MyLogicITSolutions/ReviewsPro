using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace SChatServices.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );

            config.Routes.MapHttpRoute(
             name: "DefaultApi2",
             routeTemplate: "api/{controller}/{action}/{objectId}/user/{userid}",
             defaults: new { objectId = RouteParameter.Optional, custId = RouteParameter.Optional, cardId = RouteParameter.Optional }
         );
            config.Routes.MapHttpRoute(
             name: "DefaultApi3",
             routeTemplate: "api/{controller}/{action}/{objectId}/user/{userid}/message/{message}",
             defaults: new { objectId = RouteParameter.Optional, custId = RouteParameter.Optional, cardId = RouteParameter.Optional }
         );


        }
    }
}
