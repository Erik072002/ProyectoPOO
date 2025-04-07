using ProyectoAeropuerto.Models;
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
