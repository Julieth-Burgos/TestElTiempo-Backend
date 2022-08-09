//----------------------------------------------------------
// <copyright file="CityController.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo.Controllers
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http;
    using AutoMapper;
    using TestElTiempo.Controllers.Models;
    using TestElTiempo.Models.Entities;
    using TestElTiempo.Models.Interfaces;
    using TestElTiempo.Models.Repositories;

    #endregion

    /// <summary>
    /// Representa el controlador de acciones para gestionar las ciudades
    /// </summary>
    public class CityController : ApiController
    {
        #region Properties

        /// <summary>
        /// Instancia de acceso al repositorio de datos de la entidad City
        /// </summary>
        private ICityRepository cityRepository;

        #endregion

        #region Constructor

        /*/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CityController"/>
        /// </summary>
        /// <param name="cityRepository">Instancia de acceso al repositorio de datos de la entidad City</param>
        public CityController(IcityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }*/

        #endregion

        #region AddCity

        /// <summary>
        /// Servicio que agrega una nueva ciudad
        /// </summary>
        /// <param name="cityModel">Un objeto con la información de la nueva ciudad</param>
        /// <returns>Mensaje de respuesta de la creación de la ciudad</returns>
        [HttpPost]
        public HttpResponseMessage AddCity([FromBody] CityModel cityModel)
        {
            try
            {
                this.cityRepository = new CityRepository();

                Mapper mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CityModel, City>()));
                City city = mapper.DefaultContext.Mapper.Map<CityModel, City>(cityModel);

                City cityInfo = this.cityRepository.GetCityByName(city.Description);

                if (cityInfo != null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Ya existe una ciudad con el nombre de ciudad indicado");
                }

                if (!this.cityRepository.AddCity(city))
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "¡No se pudo agregar la información de la ciudad!");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, "¡La información de la ciudad se ha registrado exitosamente!");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region DeleteCity

        /// <summary>
        /// Servicio que elimina la información de una ciudad específica
        /// </summary>
        /// <param name="cityId">El identificador de la ciudad</param>
        /// <returns>Mensaje de respuesta de la eliminación de la ciudad</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteCity(int cityId)
        {
            try
            {
                this.cityRepository = new CityRepository();

                City cityInfo = this.cityRepository.GetCityById(cityId);

                if (cityInfo == null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "No se encontró información de la ciudad");
                }

                if (!this.cityRepository.DeleteCity(cityInfo))
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "¡No se pudo eliminar la información de la ciudad!");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, "¡La ciudad se ha eliminado exitosamente!");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region GetAllCities

        /// <summary>
        /// Servicio que obtiene el listado de todas las ciudades existentes
        /// </summary>
        /// <returns>Un objeto de tipo lista con la información de todas las ciudades</returns>
        [HttpGet]
        public HttpResponseMessage GetAllCities()
        {
            try
            {
                this.cityRepository = new CityRepository();
                List<City> cityList = this.cityRepository.GetCityList();
                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, cityList);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region GetCityById

        /// <summary>
        /// Servicio que obtiene la información de una ciudad específica
        /// </summary>
        /// <param name="cityId">El identificador de la ciudad</param>
        /// <returns>Un objeto de tipo City con la información de la ciudad</returns>
        [HttpGet]
        public HttpResponseMessage GetCityById(int cityId)
        {
            try
            {
                this.cityRepository = new CityRepository();
                City cityInfo = this.cityRepository.GetCityById(cityId);

                if (cityInfo == null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "No se encontró información de la ciudad");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, cityInfo);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region UpdateCity

        /// <summary>
        /// Servicio que actualia la información de una ciudad específica
        /// </summary>
        /// <param name="cityModel">Un objeto con la información de la ciudad</param>
        /// <returns>Mensaje de respuesta de la actualización de la ciudad</returns>
        [HttpPut]
        public HttpResponseMessage UpdateCity([FromBody] CityModel cityModel)
        {
            try
            {
                this.cityRepository = new CityRepository();

                Mapper mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CityModel, City>()));
                City city = mapper.DefaultContext.Mapper.Map<CityModel, City>(cityModel);

                City cityInfo = this.cityRepository.GetCityById(city.Code);

                if (cityInfo == null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "No se encontró información de la ciudad");
                }

                City cityByFullname = this.cityRepository.GetCityByName(city.Description);

                if (cityByFullname != null && cityByFullname.Code != city.Code)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Ya existe una ciudad con el nombre de ciudad indicado");
                }

                if (!this.cityRepository.UpdateCity(city))
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "¡No se pudo actualizar la información de la ciudad!");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, "¡La información de la ciudad se ha actualizado exitosamente!");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion
    }
}