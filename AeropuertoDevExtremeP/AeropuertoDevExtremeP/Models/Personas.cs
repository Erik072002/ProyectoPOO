using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public abstract class Personas
    {

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El apellido es requerido")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }


        public int Edad { get; set; }


        [Required(ErrorMessage = "El correo es requerido")]
        [Display(Name = "Nombre")]
        public string Correo { get; set; }


        [Required(ErrorMessage = "La dirección es requerida")]
        [Display(Name = "Dirección")]
        public string Direcciones { get; set; }


        [Required(ErrorMessage = "La identidad es requerida")]
        [Display(Name = "Identidad")]
        public string Identidad { get; set; }


    }
}