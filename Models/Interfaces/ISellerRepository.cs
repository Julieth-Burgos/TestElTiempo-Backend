//----------------------------------------------------------
// <copyright file="ISellerRepository.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo.Models.Interfaces
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TestElTiempo.Models.Entities;

    #endregion

    /// <summary>
    /// Representa la información del objeto ISellerRepository
    /// </summary>
    public interface ISellerRepository
    {
        /// <summary>
        /// Retorna la información de todos los vendedores
        /// </summary>
        /// <returns>Una lista de objetos de tipo Seller</returns>
        List<Seller> GetSellerList();

        /// <summary>
        /// Obtiene la información de un vendedor específico por su ID
        /// </summary>
        /// <param name="sellerId">El identificador del registro o vendedor</param>
        /// <returns>Un objeto de tipo Seller</returns>
        Seller GetSellerById(int sellerId);

        /// <summary>
        /// Obtiene la información de un vendedor específica por su nombre
        /// </summary>
        /// <param name="name">El nombre del vendedor</param>
        /// <param name="lastname">El apellido del vendedor</param>
        /// <returns>Un objeto de tipo Seller</returns>
        Seller GetSellerByFullname(string name, string lastname);

        /// <summary>
        /// Agrega la información de un nuevo vendedor
        /// </summary>
        /// <param name="data">Un objeto con la información del vendedor</param>
        /// <returns><c>True</c> si realiza la inserción del registro de forma exitosa</returns>
        bool AddSeller(Seller data);

        /// <summary>
        /// Actualiza la información de un vendedor específico
        /// </summary>
        /// <param name="data">Un objeto con la información del vendedor</param>
        /// <returns><c>True</c> si realiza la actualización del registro de forma exitosa</returns>
        bool UpdateSeller(Seller data);

        /// <summary>
        /// Elimina la información de un vendedor especifico
        /// </summary>
        /// <param name="data">Un objeto con la información del vendedor</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        bool DeleteSeller(Seller data);
    }
}
