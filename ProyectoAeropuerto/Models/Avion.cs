using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Avion
	{
		public int avionId { get; set; }
		public int Capacidad { get; set; }
		
		public string Nombre { get; set; }
		public Avion()
		{

		}
	}
}