using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Tripulacion : Personas
    {
        [Display(Name = "No")]
        [Key]
        public int tripulacionId { get; set; }

        [Required(ErrorMessage = "El cargo  es requerido")]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "El vuelo asignado es requerido")]
        [Display(Name = "Vuelo Asignado")]

        public Vuelo VueloAsigando { get; set; }

        [Display(Name = "No. Vuelo")]
        public int vueloId { get; set; }
    }
}