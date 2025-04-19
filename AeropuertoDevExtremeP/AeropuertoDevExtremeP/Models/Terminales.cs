using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
	public class Terminales
	{
        [Display(Name = "No")]
        public int terminalesId { get; set; }

        [Required(ErrorMessage = "El nombre del área es requerido")]
        [Display(Name = "Nombre del área")]

        public string Nombre_Area { get; set; }

        
        public Aeropuerto Aeropuerto { get; set; }

        [Required(ErrorMessage = "La ID del aeropuerto es requerido")]
        [Display(Name = "No. Aeropuerto")]

        public int aeropuertoId { get; set; }
    }
}