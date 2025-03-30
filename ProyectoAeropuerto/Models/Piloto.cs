using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Piloto : Personas
	{
		public int PilotoId { get; set; }
		public string AerolineaAsignada { get; set; }
		public int AniosdeExperiencia { get; set; }

		public Piloto()
		{

		}
	}
}