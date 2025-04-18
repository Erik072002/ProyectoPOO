﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
	public class Pasajero : Personas
	{
        [Display(Name = "No")]
        public int pasajeroId { get; set; }

        [Required(ErrorMessage = "El numero de pasajero es requerido")]
        [Display(Name = "No. Pasaporte")]
        public string NumeroPasajeros { get; set; }

        [Required(ErrorMessage = "El numero de maletas es requerido")]
        [Display(Name = "No. Maletas")]
        public int NumeroMaletas { get; set; }
    }
}