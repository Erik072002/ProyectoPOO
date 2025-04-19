using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
	public class Aeropuerto
	{
        public int aeropuertoId { get; set; }

        [Required(ErrorMessage = "El nombre del aeropuerto es requerido")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}