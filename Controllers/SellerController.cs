//----------------------------------------------------------
// <copyright file="SellerController.cs" company="Autoria propia"> 
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
    /// Representa el controlador de acciones para gestionar los vendedores
    /// </summary>
    public class SellerController : ApiController
    {
        #region Properties

        /// <summary>
        /// Instancia de acceso al repositorio de datos de la entidad Seller
        /// </summary>
        private ISellerRepository sellerRepository;

        #endregion

        #region Constructor

        /*/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SellerController"/>
        /// </summary>
        /// <param name="sellerRepository">Instancia de acceso al repositorio de datos de la entidad Seller</param>
        public SellerController(IsellerRepository sellerRepository)
        {
            this.sellerRepository = sellerRepository;
        }*/

        #endregion

        #region AddSeller

        /// <summary>
        /// Servicio que agrega un nuevo vendedor
        /// </summary>
        /// <param name="sellerModel">Un objeto con la información del nuevo vendedor</param>
        /// <returns>Mensaje de respuesta de la creación del vendedor</returns>
        [HttpPost]
        public HttpResponseMessage AddSeller([FromBody] SellerModel sellerModel)
        {
            try
            {
                this.sellerRepository = new SellerRepository();

                Mapper mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<SellerModel, Seller>()));
                Seller seller = mapper.DefaultContext.Mapper.Map<SellerModel, Seller>(sellerModel);

                Seller sellerInfo = this.sellerRepository.GetSellerByFullname(seller.Name, seller.Lastname);

                if (sellerInfo != null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Ya existe un vendedor con el nombre de vendedor indicado");
                }

                if (!this.sellerRepository.AddSeller(seller))
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "¡No se pudo agregar la información del vendedor!");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, "¡La información del vendedor se ha registrado exitosamente!");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region DeleteSeller

        /// <summary>
        /// Servicio que elimina la información de un vendedor específico
        /// </summary>
        /// <param name="sellerId">El identificador del vendedor</param>
        /// <returns>Mensaje de respuesta de la eliminación del vendedor</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteSeller(int sellerId)
        {
            try
            {
                this.sellerRepository = new SellerRepository();

                Seller sellerInfo = this.sellerRepository.GetSellerById(sellerId);

                if (sellerInfo == null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "No se encontró información del vendedor");
                }

                if (!this.sellerRepository.DeleteSeller(sellerInfo))
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "¡No se pudo eliminar la información del vendedor!");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, "¡El vendedor se ha eliminado exitosamente!");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region GetAllSeller

        /// <summary>
        /// Servicio que obtiene el listado de todos los vendedores existentes
        /// </summary>
        /// <returns>Un objeto de tipo lista con la información de todos los vendedores</returns>
        [HttpGet]
        public HttpResponseMessage GetAllSeller()
        {
            try
            {
                this.sellerRepository = new SellerRepository();
                List<Seller> sellerList = this.sellerRepository.GetSellerList();
                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, sellerList);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region GetSellerById

        /// <summary>
        /// Servicio que obtiene la información de un vendedor específico
        /// </summary>
        /// <param name="sellerId">El identificador del vendedor</param>
        /// <returns>Un objeto de tipo Seller con la información del vendedor</returns>
        [HttpGet]
        public HttpResponseMessage GetSellerById(int sellerId)
        {
            try
            {
                this.sellerRepository = new SellerRepository();
                Seller sellerInfo = this.sellerRepository.GetSellerById(sellerId);

                if (sellerInfo == null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "No se encontró información del vendedor");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, sellerInfo);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion

        #region UpdateSeller

        /// <summary>
        /// Servicio que actualiza la información de un vendedor específico
        /// </summary>
        /// <param name="sellerModel">Un objeto con la información del vendedor</param>
        /// <returns>Mensaje de respuesta de la actualización del vendedor</returns>
        [HttpPut]
        public HttpResponseMessage UpdateSeller([FromBody] SellerModel sellerModel)
        {
            try
            {
                this.sellerRepository = new SellerRepository();

                Mapper mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<SellerModel, Seller>()));
                Seller seller = mapper.DefaultContext.Mapper.Map<SellerModel, Seller>(sellerModel);

                Seller sellerInfo = this.sellerRepository.GetSellerById(seller.Code);

                if (sellerInfo == null)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "No se encontró información del vendedor");
                }

                Seller sellerByFullname = this.sellerRepository.GetSellerByFullname(seller.Name, seller.Lastname);

                if (sellerByFullname != null && sellerByFullname.Code != seller.Code)
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Ya existe un vendedor con el nombre de vendedor indicado");
                }

                if (!this.sellerRepository.UpdateSeller(seller))
                {
                    return this.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "¡No se pudo actualizar la información del vendedor!");
                }

                return this.Request.CreateResponse(System.Net.HttpStatusCode.OK, "¡La información del vendedor se ha actualizado exitosamente!");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }

        #endregion
    }
}