using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Tripulacion : Personas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El cargo  es requerido")]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }
    }
}