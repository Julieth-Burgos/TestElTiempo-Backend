//----------------------------------------------------------
// <copyright file="CityModel.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo.Controllers.Models
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    #endregion

    /// <summary>
    /// Representa la información del objeto City (Ciudades)
    /// </summary>
    public class CityModel
    {
        /// <summary>
        /// Obtiene o establece el identificador unico del registro
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ciudad
        /// </summary>
        public string Description { get; set; }
    }
}