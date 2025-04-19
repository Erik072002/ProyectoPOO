using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
	public class Puerta_Abordaje
	{
        [Display(Name = "No")]
        public int Puerta_AbordajeId { get; set; }

        [Display(Name = "No. Terminales")]

        public Terminales Terminales { get; set; }

        [Required(ErrorMessage = "La aerolinea es requerido")]
        [Display(Name = "Aerolinea")]
        public string Aerolinea { get; set; }
        [Display(Name = "No. Terminales")]
        public int terminalesId { get; set; }
    }
}