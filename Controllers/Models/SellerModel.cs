//----------------------------------------------------------
// <copyright file="SellerModel.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo.Controllers.Models
{
    /// <summary>
    /// Representa la información del objeto Seller (Vendedores)
    /// </summary>
    public class SellerModel
    {
        /// <summary>
        /// Obtiene o establece el identificador unico del registro
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del vendedor
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del vendedor
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Obtiene o establece el número de documento del vendedor
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Obtiene o establece el codigo de la ciudad de ubicación del vendedor
        /// </summary>
        public int CityCode { get; set; }
    }
}