using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Tripulacion : Personas
	{
		public int Id { get; set; }
		public string Cargo { get; set; }
		public Vuelo VueloAsignado { get; set; }

		public Tripulacion()
		{

		}
	}
}