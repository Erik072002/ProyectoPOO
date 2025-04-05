using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Vuelo
	{
		public int VueloId { get; set; }
		public DateTime Fecha_salida { get; set; }
		public DateTime Fecha_Llegada { get; set; }
		public Avion Avion { get; set; }
		public Puerta_Abordaje Puerta_Abordaje { get; set; }
		public Piloto Piloto { get; set; }
        public double Precio { get; set; }

		public Vuelo()
		{

		}
	}
}