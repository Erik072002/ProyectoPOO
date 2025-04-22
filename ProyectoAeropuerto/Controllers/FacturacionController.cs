using ProyectoAeropuerto.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAeropuerto.Controllers
{
    public class FacturacionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Devuelve las facturas por un filtro de fechas
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns>JSON Facturacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>

        [HttpGet]
        [SwaggerOperation("Facturacion-por-Fecha")]
        [Route("api/GetFacturacionFechas")]

        public IHttpActionResult GetFacturacionFechas(DateTime FechaDesde, DateTime FechaHasta)
        {
            var query = from facturacion in db.Facturacion
                        join metododepago in db.MetodoDePago on facturacion.MetodoDePago equals metododepago
                        join pasajero in db.Pasajero on facturacion.Boleto.Pasajero equals pasajero
                        join boleto in db.Boleto on facturacion.Boleto equals boleto

                        where facturacion.Fecha_de_Factura >= FechaDesde && facturacion.Fecha_de_Factura <= FechaHasta

                        select new
                        {
                            Facturacion = facturacion.Id,
                            MetododePago = facturacion.MetodoDePago.Metodo_Pago,
                            Pasajero = facturacion.Boleto.Pasajero.Nombre,
                            Boleto = facturacion.Boleto.boletoId
                        };
            return Ok(query);
        }

        /// <summary>
        /// Devuelve la facturacion filtrando por la ID del pago
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Facturacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        [HttpGet]
        [SwaggerOperation("Facturacion-por-MetododePago")]
        [Route("api/GetFacturacionMetodoPago")]

        public IHttpActionResult GetFacturacionMetodoPago(int id)
        {
            var query = from facturacion in db.Facturacion
                        join metododepago in db.MetodoDePago on facturacion.MetodoDePago equals metododepago
                        join pasajero in db.Pasajero on facturacion.Boleto.Pasajero equals pasajero
                        join boleto in db.Boleto on facturacion.Boleto equals boleto

                        where facturacion.MetodoDePago.metododepagoId == id

                        select new
                        {
                            Facturacion = facturacion.Id,
                            MetododePago = facturacion.MetodoDePago.Metodo_Pago,
                            Pasajero = facturacion.Boleto.Pasajero.Nombre,
                            Boleto = facturacion.Boleto.boletoId
                        };
            return Ok(query);
        }

        /// <summary>
        ///  Muestra todos los Facturacion
        ///  </summary>
        /// <returns>JSON Facturacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Facturacion
        public IEnumerable<Facturacion> Get()
        {
            return db.Facturacion;
        }

        /// <summary>
        ///  Obtener la salida de Facturacion por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Facturacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Facturacion
        public IHttpActionResult Get(int id)
        {
            Facturacion facturacion = db.Facturacion.Find(id);
            if (facturacion == null)
            {
                NotFound();
            }
            return Ok(facturacion);
        }

        /// <summary>
        ///  Crear un Facturacion
        ///  </summary>
        ///  <param name="facturacion"></param>
        /// <returns>JSON Facturacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Facturacion
        public IHttpActionResult Post(Facturacion facturacion)
        {

            if (facturacion.Boleto != null)
            {
                Boleto BoletoEncontrado = db.Boleto.Find(facturacion.Boleto.boletoId);
                facturacion.Boleto = BoletoEncontrado;
            }
            if (facturacion.MetodoDePago != null)
            {
                MetodoDePago metododepagoEncontrado = db.MetodoDePago.Find(facturacion.MetodoDePago.metododepagoId);
                facturacion.MetodoDePago = metododepagoEncontrado;
            }
            db.Facturacion.Add(facturacion);
            db.SaveChanges();

            return Ok(facturacion);
        }

        /// <summary>
        ///  Modificar un Facturacion
        ///  </summary>
        ///  <param name="FactuacionModificado"></param>
        /// <returns>JSON Facturacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Facturacion
        public IHttpActionResult Put(Facturacion FactuacionModificado)
        {
            int id = FactuacionModificado.Id;
            db.Entry(FactuacionModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(FactuacionModificado);
        }

        /// <summary>
        ///  Eliminar un Facturacion
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Facturacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Facturacion
        public IHttpActionResult Delete(int id)
        {
            Facturacion facturacion = db.Facturacion.Find(id);
            db.Facturacion.Remove(facturacion);
            db.SaveChanges();

            return Ok(facturacion);
        }
    }
}
