//----------------------------------------------------------
// <copyright file="ICityRepository.cs" company="Autoria propia"> 
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
    /// Representa la información del objeto ICityRepository
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Retorna la información de todos las ciudades
        /// </summary>
        /// <returns>Una lista de objetos de tipo City</returns>
        List<City> GetCityList();

        /// <summary>
        /// Obtiene la información de una ciudad específica por su ID
        /// </summary>
        /// <param name="cityId">El identificador del registro o ciudad</param>
        /// <returns>Un objeto de tipo City</returns>
        City GetCityById(int cityId);

        /// <summary>
        /// Obtiene la información de un ciudad específica por su nombre
        /// </summary>
        /// <param name="name">El nombre del ciudad</param>
        /// <returns>Un objeto de tipo City</returns>
        City GetCityByName(string name);

        /// <summary>
        /// Agrega la información de una nueva ciudad
        /// </summary>
        /// <param name="data">Un objeto con la información de la ciudad</param>
        /// <returns><c>True</c> si realiza la inserción del registro de forma exitosa</returns>
        bool AddCity(City data);

        /// <summary>
        /// Actualiza la información de una ciudad específica
        /// </summary>
        /// <param name="data">Un objeto con la información de la ciudad</param>
        /// <returns><c>True</c> si realiza la actualización del registro de forma exitosa</returns>
        bool UpdateCity(City data);

        /// <summary>
        /// Elimina la información de una ciudad especifica
        /// </summary>
        /// <param name="data">Un objeto con la información de la ciudad</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        bool DeleteCity(City data);
    }
}
