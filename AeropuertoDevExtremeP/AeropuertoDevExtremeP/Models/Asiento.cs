using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Asiento
    {
        [Required(ErrorMessage = "El ID del Asiento es requerido")]
        [Display(Name = "No")]
        public int asientoId { get; set; }
        public string Clase { get; set; }

        [Required(ErrorMessage = "El numero del asiento es requerido")]
        [Display(Name = "No. Asiento")]
        public string NumeroAsiento { get; set; }

        [Required(ErrorMessage = "El nombre del avión es requerido")]
        [Display(Name = "No. Avion")]
        public Avion Avion { get; set; }
        [Display(Name = "No. Avion")]
        public int avionId { get; set; }


     
    }
}