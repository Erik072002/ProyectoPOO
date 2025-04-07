using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Piloto : Personas
    {
        public int pilotoId { get; set; }

        [Required(ErrorMessage = "La aerolinea asiganada es requerida")]
        [Display(Name = "Aerolinea asignada")]
        public string AerolineaAsignada { get; set; }

        [Required(ErrorMessage = "Los años de experiencia son requeridos")]
        [Display(Name = "Años de experiencia")]
        public int AniosdeExperiencia { get; set; }
    }
}