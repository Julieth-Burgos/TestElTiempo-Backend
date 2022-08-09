//----------------------------------------------------------
// <copyright file="CityRepository.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo.Models.Repositories
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web;
    using TestElTiempo.Models.Entities;
    using TestElTiempo.Models.Interfaces;

    #endregion

    /// <summary>
    /// Representa la información del objeto CityRepository
    /// </summary>
    public class CityRepository : ICityRepository
    {
        #region Properties

        /// <summary>
        /// Representa la información del contexto de la base de datos
        /// </summary>
        private readonly ModelContext modelContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref = "CityRepository" />.
        /// </summary>
        public CityRepository()
        {
            this.modelContext = new ModelContext();
        }

        #endregion

        #region GetCityList

        /// <summary>
        /// Retorna la información de todas las ciudades
        /// </summary>
        /// <returns>Una lista de objetos de tipo City</returns>
        public List<City> GetCityList()
        {
            return this.modelContext.City.ToList();
        }

        #endregion

        #region GetCityById

        /// <summary>
        /// Obtiene la información de una ciudad específica por su ID
        /// </summary>
        /// <param name="cityId">El identificador del registro</param>
        /// <returns>Un objeto de tipo City</returns>
        public City GetCityById(int cityId)
        {
            return this.modelContext.City.ToList().Where(x => x.Code == cityId).FirstOrDefault();
        }

        #endregion

        #region GetCityByName

        /// <summary>
        /// Obtiene la información de una ciudad específica por su nombre
        /// </summary>
        /// <param name="name">El nombre de la ciudad</param>
        /// <returns>Un objeto de tipo City</returns>
        public City GetCityByName(string name)
        {
            return this.modelContext.City.ToList().Where(x => x.Description.Contains(name)).FirstOrDefault();
        }

        #endregion

        #region AddCity

        /// <summary>
        /// Agrega la información de una nueva ciudad
        /// </summary>
        /// <param name="data">Un objeto con la información de la ciudad</param>
        /// <returns><c>True</c> si realiza la inserción del registro de forma exitosa</returns>
        public bool AddCity(City data)
        {
            this.modelContext.City.Add(data);

            try
            {
                this.modelContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return false;
            }

            return true;
        }

        #endregion

        #region UpdateCity

        /// <summary>
        /// Actualiza la información de una ciudad específica
        /// </summary>
        /// <param name="data">Un objeto con la información de la ciudad</param>
        /// <returns><c>True</c> si realiza la actualización del registro de forma exitosa</returns>
        public bool UpdateCity(City data)
        {
            City city = this.modelContext.City.ToList().Where(x => x.Code == data.Code).FirstOrDefault();

            try
            {
                this.modelContext.Entry(city).CurrentValues.SetValues(data);
                this.modelContext.Entry(city).State = EntityState.Modified;
                this.modelContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return false;
            }

            return true;
        }

        #endregion

        #region DeleteCity

        /// <summary>
        /// Elimina la información de una ciudad especifica
        /// </summary>
        /// <param name="data">Un objeto con la información de la ciudad</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        public bool DeleteCity(City data)
        {
            if (data != null)
            {
                if (this.modelContext.Entry(data).State == EntityState.Detached)
                {
                    this.modelContext.City.Attach(data);
                }

                this.modelContext.City.Remove(data);
                this.modelContext.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion
    }
}