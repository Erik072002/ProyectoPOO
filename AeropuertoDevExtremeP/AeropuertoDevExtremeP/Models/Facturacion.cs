using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AeropuertoDevExtremeP.Models
{
    public class Facturacion
    {
        public int facturacionId { get; set; }
        public Boleto Boleto { get; set; }
        public int boletoId { get; set; }
        public DateTime Fecha_de_Factura { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public int metododepagoId { get; set; }

  
    }
}