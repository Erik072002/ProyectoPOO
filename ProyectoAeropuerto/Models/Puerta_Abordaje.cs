using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Puerta_Abordaje
	{
		public int Id { get; set; }
		public Terminales Terminales { get; set; }
        public string Aerolinea { get; set; }

		public Puerta_Abordaje() { }
	}
}