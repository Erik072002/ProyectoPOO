using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Facturacion
	{
		public int Id { get; set; }
		public Boleto Boleto { get; set; }
		public DateTime Fecha_de_Factura { get; set; }
		public MetodoDePago MetodoDePago { get; set; }


        public Facturacion() { }
	}
}