//----------------------------------------------------------
// <copyright file="Seller.cs" company="Autoria propia"> 
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
    /// Representa la información del objeto Seller (Vendedores)
    /// </summary>
    [Table("Seller")]
    public class Seller
    {
        /// <summary>
        /// Obtiene o establece el identificador unico del registro
        /// </summary>
        [Key]
        public int Code { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del vendedor
        /// </summary>
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del vendedor
        /// </summary>
        [Display(Name = "Lastname")]
        public string Lastname { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento del vendedor
        /// </summary>
        [Display(Name = "DocNumber")]
        public string DocNumber { get; set; }

        /// <summary>
        /// Obtiene o establece el codigo de la ciudad de ubicación del vendedor
        /// </summary>
        [Display(Name = "CityCode")]
        public int CityCode { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la ciudad de ubicación del vendedor
        /// </summary>
        [NotMapped]
        public string CityName { get; set; }

        /// <summary>
        /// Obtiene un objeto con las propiedades de la tabla relacionada City
        /// </summary>
        public virtual City City { get; set; }
    }
}