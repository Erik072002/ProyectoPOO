using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Terminales
	{
		public int Id { get; set; }
		public string Nombre_Area { get; set; }
		public Aeropuerto Aeropuerto { get; set; }



		public Terminales()
		{

		}
	}
}