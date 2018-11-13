//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------
using System.Web.Http;

namespace api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //Enable cors 
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
