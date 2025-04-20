using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Facturacion
    {
        [Display(Name = "No")]
        public int Id { get; set; }
        public Boleto Boleto { get; set; }
        [Display(Name = "No. Boleto")]
        public int boletoId { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha_de_Factura { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        [Display(Name = "No. Metodo de pago")]
        public int metododepagoId { get; set; }

  
    }
}