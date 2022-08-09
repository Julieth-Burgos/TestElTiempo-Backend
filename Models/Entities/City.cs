//----------------------------------------------------------
// <copyright file="City.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo.Models.Entities
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
    [Table("City")]
    public class City
    {
        /// <summary>
        /// Obtiene o establece el identificador unico del registro
        /// </summary>
        [Key]
        public int Code { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ciudad
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Representa una colección de tipo Seller
        /// </summary>
        public ICollection<Seller> Seller { get; set; }
    }
}