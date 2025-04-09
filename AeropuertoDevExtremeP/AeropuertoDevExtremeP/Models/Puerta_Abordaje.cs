using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
	public class Puerta_Abordaje
	{
        public int Puerta_AbordajeId { get; set; }

        [Required(ErrorMessage = "La ID del  es requerido")]
        [Display(Name = "Numero de maletas")]

        public Terminales Terminales { get; set; }

        [Required(ErrorMessage = "La aerolinea es requerido")]
        [Display(Name = "Aerolinea")]
        public string Aerolinea { get; set; }
        public int terminalesId { get; set; }
    }
}