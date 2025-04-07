using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Boleto
	{
		public int boletoId { get; set; }
		public Pasajero Pasajero { get; set; }
		public int pasajeroId { get; set; }
		public Vuelo Vuelo { get; set; }
		public  int vueloId { get; set; }
        public Asiento Asiento { get; set; }
		public int asientoId { get; set; }
		public double Pago { get; set; }

		public Boleto()
		{

		}
	}
}