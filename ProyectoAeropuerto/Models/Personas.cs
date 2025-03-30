using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public abstract class Personas
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public int Edad { get; set; }
		public string Correo { get; set; }
		public string Direcciones { get; set; }
		public string Identidad { get; set; }


		public Personas()
		{

		}
	}
}