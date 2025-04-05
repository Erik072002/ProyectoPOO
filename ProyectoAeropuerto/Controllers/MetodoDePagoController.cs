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
    public class MetodoDePagoController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        
        /// <summary>
        ///  Muestra todos los Metodo de pago
        ///  </summary>
        /// <returns>JSON Metodo de pago</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Metodo de pago
        public IEnumerable<MetodoDePago> Get()
        {
            return db.MetodoDePago;
        }

        /// <summary>
        ///  Obtener la salida de Metodo de pago por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Metodo de pago</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Metodo de pago
        public IHttpActionResult Get(int id)
        {
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            if (metodoDePago == null)
            {
                NotFound();
            }
            return Ok(metodoDePago);
        }

        /// <summary>
        ///  Crear un Metodo de pago
        ///  </summary>
        ///  <param name="metodoDePago"></param>
        /// <returns>JSON Metodo de pago</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Metodo de pago
        public IHttpActionResult Post(MetodoDePago metodoDePago)
        {
            db.MetodoDePago.Add(metodoDePago);
            db.SaveChanges();

            return Ok(metodoDePago);
        }

        /// <summary>
        ///  Modificar un Metodo de pago
        ///  </summary>
        ///  <param name="ModificarMetodo"></param>
        /// <returns>JSON Metodo de pago</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Metodo de pago
        public IHttpActionResult Put(MetodoDePago ModificarMetodo)
        {
            int id = ModificarMetodo.Id;

            db.Entry(ModificarMetodo).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(ModificarMetodo);
        }

        /// <summary>
        ///  Eliminar un Metodo de pago
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Metodo de pago</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Metodo de pago
        public IHttpActionResult Delete(int id)
        {
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            db.MetodoDePago.Remove(metodoDePago);
            db.SaveChanges();

            return Ok(metodoDePago);
        }
    }
}
