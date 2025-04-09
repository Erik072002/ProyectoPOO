using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class MiDbContext : DbContext
	{
        public MiDbContext() : base("MyDbConnectionString")
        {

        }

        public DbSet<Aeropuerto> Aeropuerto { get; set; }
        public DbSet<Asiento> Asiento { get; set; }
        public DbSet<Avion> Avion { get; set; }
        public DbSet<Boleto> Boleto { get; set; }
        public DbSet<Facturacion> Facturacion { get; set; }
        public DbSet<MetodoDePago> MetodoDePago { get; set; }
        public DbSet<Pasajero> Pasajero { get; set; }
        public DbSet<Piloto> Piloto { get; set; }
        public DbSet<Puerta_Abordaje> Puerta_Abordaje { get; set; }
        public DbSet<Terminales> Terminales { get; set; }
        public DbSet<Tripulacion> Tripulacion { get; set; }
        public DbSet<Vuelo> Vuelo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vuelo>()
                .HasRequired(v => v.Avion)
                .WithMany()
                .HasForeignKey(v => v.avionId)
                .WillCascadeOnDelete(false); // 👈 Aquí se desactiva el cascade

            modelBuilder.Entity<Vuelo>()
                .HasRequired(v => v.Puerta_Abordaje)
                .WithMany()
                .HasForeignKey(v => v.Puerta_AbordajeId)
                .WillCascadeOnDelete(false);
        }
    }
}