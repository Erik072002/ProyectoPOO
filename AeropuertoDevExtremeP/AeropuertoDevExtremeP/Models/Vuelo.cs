using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Vuelo
    {
        [Display(Name = "No")]
        public int vueloId { get; set; }
        [Display(Name = "Fecha de salida")]
        public DateTime Fecha_salida { get; set; }
        [Display(Name = "Fecha de llegada")]
        public DateTime Fecha_Llegada { get; set; }
        public Avion Avion { get; set; }
        [Display(Name = "No. Avion")]
        public int avionId { get; set; }
        public Puerta_Abordaje Puerta_Abordaje { get; set; }
        [Display(Name = "No. Puerta de abordaje")]
        public int Puerta_AbordajeId { get; set; }

        public double Precio { get; set; }


    }
}