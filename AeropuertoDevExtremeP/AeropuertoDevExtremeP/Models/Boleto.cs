using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Boleto
    {
        [Display(Name = "No")]
        public int boletoId { get; set; }

        [Required(ErrorMessage = "El ID del Pasajero es requerido")]
        [Display(Name = "No. Pasajero")]
        public Pasajero Pasajero { get; set; }
        [Display(Name = "No. Pasajero")]
        public int pasajeroId { get; set; }

        [Required(ErrorMessage = "El ID del Vuelo es requerido")]
        [Display(Name = "No. Vuelo")]
        public Vuelo Vuelo { get; set; }
        [Display(Name = "No. Vuelo")]
        public int vueloId { get; set; }

        [Required(ErrorMessage = "El ID del Asiento es requerido")]
        [Display(Name = "No. Asiento")]
        public Asiento Asiento { get; set; }
        [Display(Name = "No. Asiento")]
        public int asientoId { get; set; }

        [Display(Name = "Precio")]
        public double Pago { get; set; }

    
    }
}