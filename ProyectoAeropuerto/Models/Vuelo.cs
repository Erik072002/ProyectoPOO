using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Vuelo
	{
		public int vueloId { get; set; }
		public DateTime Fecha_salida { get; set; }
		public DateTime Fecha_Llegada { get; set; }
		public Avion Avion { get; set; }	
		public int avionId { get; set; }
        public Puerta_Abordaje Puerta_Abordaje { get; set; }
		public int Puerta_AbordajeId { get; set; }
		
        public double Precio { get; set; }

		public Vuelo()
		{

		}
	}
}