//----------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo
{
    #region Using

    using System.Web.Http;
    using System.Web.Http.Cors;

    #endregion

    /// <summary>
    /// Representa la información del objeto WebApiController
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registra las rutas del API
        /// </summary>
        /// <param name="config">Un objeto de tipo HttpConfiguration</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
