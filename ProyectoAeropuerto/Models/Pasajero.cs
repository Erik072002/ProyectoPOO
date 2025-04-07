using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Pasajero : Personas
	{
		public int pasajeroId { get; set; }
		public string NumeroPasajeros { get; set; }
		public int NumeroMaletas { get; set; }

		public Pasajero()
		{

		}
	}
}