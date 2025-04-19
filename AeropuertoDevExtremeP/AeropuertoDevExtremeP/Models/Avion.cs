using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
	public class Avion
	{
        [Display(Name = "No")]
        public int avionId { get; set; }
        [Display(Name = "Capacidad")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]

        public string Nombre { get; set; }
    }
}