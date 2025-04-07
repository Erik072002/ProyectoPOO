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
    public class AeropuertoController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Aeropuerto
        ///  </summary>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Aeropuerto
        public IEnumerable<Aeropuerto> Get()
        {
            return db.Aeropuerto;
        }

        /// <summary>
        ///  Obtener la salida de Aeropuerto por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Aeropuerto
        public IHttpActionResult Get(int id)
        {
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            if (aeropuerto == null)
            {
                NotFound();
            }
            return Ok(aeropuerto);
        }

        /// <summary>
        ///  Crear un Aeropuerto
        ///  </summary>
        ///  <param name="asiento"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Aeropuerto
        public IHttpActionResult Post(Aeropuerto asiento)
        {
            db.Aeropuerto.Add(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }

        /// <summary>
        ///  Modificar un Aeropuerto
        ///  </summary>
        ///  <param name="AeropuertoModificado"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Aeropuerto
        public IHttpActionResult Put(Aeropuerto AeropuertoModificado)
        {
            int id = AeropuertoModificado.aeropuertoId;
            db.Entry(AeropuertoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(AeropuertoModificado);
        }

        /// <summary>
        ///  Eliminar un Aeropuerto
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Aeropuerto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Aeropuerto
        public IHttpActionResult Delete(int id)
        {
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            db.Aeropuerto.Remove(aeropuerto);
            db.SaveChanges();

            return Ok(aeropuerto);
        }
    }
}
