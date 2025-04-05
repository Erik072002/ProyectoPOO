using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Boleto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del Pasajero es requerido")]
        [Display(Name = "ID")]
        public Pasajero Pasajero { get; set; }

        [Required(ErrorMessage = "El ID del Vuelo es requerido")]
        [Display(Name = "ID")]
        public Vuelo Vuelo { get; set; }

        [Required(ErrorMessage = "El ID del Asiento es requerido")]
        [Display(Name = "ID")]
        public Asiento Asiento { get; set; }
        public double Pago { get; set; }

    
    }
}