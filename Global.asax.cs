//----------------------------------------------------------
// <copyright file="Global.asax.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo
{
    #region Using

    using System.Web;
    using System.Web.Http;

    #endregion

    /// <summary>
    /// Inicializa la aplicación
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Establece los parametros previos a iniciar la aplicación
        /// </summary>
        protected void Application_BeginRequest()
        {
            // HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            // HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }

        /// <summary>
        /// Inicio de la aplicación
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
