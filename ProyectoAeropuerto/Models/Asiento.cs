﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
	public class Asiento
	{
		public int asientoId { get; set; }
		public string Clase { get; set; }
		public string NumeroAsiento { get; set; }
		public Avion Avion { get; set; } 
		public int avionId { get; set; }


		public Asiento() { }
	}
}