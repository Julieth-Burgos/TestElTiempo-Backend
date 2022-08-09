//----------------------------------------------------------
// <copyright file="SellerRepository.cs" company="Autoria propia"> 
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
    /// Representa la información del objeto SellerRepository
    /// </summary>
    public class SellerRepository : ISellerRepository
    {
        #region Properties

        /// <summary>
        /// Representa la información del contexto de la base de datos
        /// </summary>
        private readonly ModelContext modelContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref = "SellerRepository" />.
        /// </summary>
        public SellerRepository()
        {
            this.modelContext = new ModelContext();
        }

        #endregion

        #region GetSellerList

        /// <summary>
        /// Retorna la información de todos los vendedores
        /// </summary>
        /// <returns>Una lista de objetos de tipo Seller</returns>
        public List<Seller> GetSellerList()
        {
            // return modelContext.Seller.ToList();
            return this.modelContext.Seller.ToList().Select(item => new Seller() 
            { 
                Code = item.Code,
                Name = item.Name,
                Lastname = item.Lastname,
                DocNumber = item.DocNumber,
                CityCode = item.City.Code,
                CityName = item.City.Description
            }).ToList();
        }

        #endregion

        #region GetSellerById

        /// <summary>
        /// Obtiene la información de un vendedor específico por su ID
        /// </summary>
        /// <param name="sellerId">El identificador del registro</param>
        /// <returns>Un objeto de tipo Seller</returns>
        public Seller GetSellerById(int sellerId)
        {
            return this.modelContext.Seller.ToList().Where(x => x.Code == sellerId).Select(item => new Seller()
            {
                Code = item.Code,
                Name = item.Name,
                Lastname = item.Lastname,
                DocNumber = item.DocNumber,
                CityCode = item.City.Code,
                CityName = item.City.Description
            }).FirstOrDefault();
        }

        #endregion

        #region GetSellerByFullname

        /// <summary>
        /// Obtiene la información de un vendedor específico por su nombre completo
        /// </summary>
        /// <param name="name">El nombre de la vendedor</param>
        /// <param name="lastname">El apellido de la vendedor</param>
        /// <returns>Un objeto de tipo Seller</returns>
        public Seller GetSellerByFullname(string name, string lastname)
        {
            return this.modelContext.Seller.ToList()
                .Where(x => x.Name.Contains(name) && x.Lastname.Contains(lastname)).FirstOrDefault();
        }

        #endregion

        #region AddSeller

        /// <summary>
        /// Agrega la información de un nuevo vendedor
        /// </summary>
        /// <param name="data">Un objeto con la información del vendedor</param>
        /// <returns><c>True</c> si realiza la inserción del registro de forma exitosa</returns>
        public bool AddSeller(Seller data)
        {
            this.modelContext.Seller.Add(data);

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

        #region UpdateSeller

        /// <summary>
        /// Actualiza la información de un vendedor específico
        /// </summary>
        /// <param name="data">Un objeto con la información del vendedor</param>
        /// <returns><c>True</c> si realiza la actualización del registro de forma exitosa</returns>
        public bool UpdateSeller(Seller data)
        {
            Seller seller = this.modelContext.Seller.ToList().Where(x => x.Code == data.Code).FirstOrDefault();

            try
            {
                this.modelContext.Entry(seller).CurrentValues.SetValues(data);
                this.modelContext.Entry(seller).State = EntityState.Modified;
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

        #region DeleteSeller

        /// <summary>
        /// Elimina la información de un vendedor especifico
        /// </summary>
        /// <param name="data">Un objeto con la información del vendedor</param>
        /// <returns><c>True</c> si realiza la eliminación del registro de forma exitosa</returns>
        public bool DeleteSeller(Seller data)
        {
            Seller seller = this.modelContext.Seller.ToList().Where(x => x.Code == data.Code).FirstOrDefault();

            try
            {
                this.modelContext.Entry(seller).CurrentValues.SetValues(data);
                this.modelContext.Entry(seller).State = EntityState.Detached;

                if (this.modelContext.Entry(seller).State == EntityState.Detached)
                {
                    this.modelContext.Seller.Attach(seller);
                }

                this.modelContext.Seller.Remove(seller);
                this.modelContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
                return false;
            }

            return true;

            /*if (data != null)
            {
                if (this.modelContext.Entry(data).State == EntityState.Detached)
                {
                    this.modelContext.Seller.Attach(data);
                }

                this.modelContext.Seller.Remove(data);
                this.modelContext.SaveChanges();
                return true;
            }

            return false;*/
        }

        #endregion
    }
}