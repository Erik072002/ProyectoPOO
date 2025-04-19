using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Aeropuerto
	{
		public int aeropuertoId { get; set; }
		public string nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }


        public Aeropuerto()
		{

		}
	}
}