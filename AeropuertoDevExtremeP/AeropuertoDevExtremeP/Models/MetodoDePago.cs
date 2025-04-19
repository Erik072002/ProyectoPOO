using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
	public class MetodoDePago
	{
        [Display(Name = "No")]
        public int metododepagoId { get; set; }

        [Required(ErrorMessage = "El tipo de metodo es requerido")]
        [Display(Name = "Metodo de Pago")]
        public string Metodo_Pago { get; set; }
    }
}