using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Proyecto_1._0.Models
{
    public class ConexionDb : DbContext
    {
        public ConexionDb() : base("MyDbContextConnectionString")
        {
            Database.SetInitializer<ConexionDb>(new MyDbInitializer());
        }

        //public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<Instituciones> instituciones { get; set; }
        public DbSet<TipoServicio> tipoServicio { get; set; }
        public DbSet<TipoTramite> tipoTramite { get; set; }
        public DbSet<TipoDato> tipoDato { get; set; }
        public DbSet<RequisitoDato> requisitoDato { get; set; }
        public DbSet<RequisitoServicioTramite> requisitoServicio { get; set; }
        public DbSet<RequisitoTramiteDato> requisitoTramite { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class MyDbInitializer : CreateDatabaseIfNotExists<ConexionDb>
    {
        protected override void Seed(ConexionDb context)
        {
            // create 3 students to seed the database
            //context.userAccount.Add(new UserAccount{ id_usuario = 1, nombre_usuario = "Mark", password = "1234"});


        }
    }
}