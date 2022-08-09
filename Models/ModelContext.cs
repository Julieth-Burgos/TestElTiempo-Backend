//----------------------------------------------------------
// <copyright file="ModelContext.cs" company="Autoria propia"> 
// Copyright (c) 2022 Todos los derechos reservados.
// </copyright>
// <author>Julieth Burgos</author>
// <date>26/06/2022 4:30:56 PM</date>
//----------------------------------------------------------

namespace TestElTiempo.Models
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using TestElTiempo.Models.Entities;

    #endregion

    /// <summary>
    /// Obtiene la información del objeto ModelContext
    /// </summary>
    public class ModelContext : DbContext
    {
        /// <summary>
        /// Inicializa una nueva instancia a la clase <see cref="ModelContext"/>
        /// </summary>
        public ModelContext() : base("SqlConnection")
        {
            Database.SetInitializer<ModelContext>(null);
        }

        #region Inicializadores de acceso

        /// <summary>
        /// Obtiene o establece el indicador de acceso a la entidad City
        /// </summary>
        public DbSet<City> City { get; set; }

        /// <summary>
        /// Obtiene o establece el indicador de acceso a la entidad Seller
        /// </summary>
        public DbSet<Seller> Seller { get; set; }

        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DbModelBuilder"/>
        /// </summary>
        /// <param name="modelBuilder">Un objeto de tipo DbModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder); 
        }
    }
}