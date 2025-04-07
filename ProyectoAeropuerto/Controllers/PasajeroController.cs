using ProyectoAeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace ProyectoAeropuerto.Controllers
{
    public class PasajeroController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Pasajero
        ///  </summary>
        /// <returns>JSON Pasajero</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Pasajero
        public IEnumerable<Pasajero> Get()
        {
            return db.Pasajero;
        }

        /// <summary>
        ///  Obtener la salida de Pasajero por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Pasajero</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Pasajero
        public IHttpActionResult Get(int id)
        {
            Pasajero pasajero = db.Pasajero.Find(id);
            if (pasajero == null)
            {
                NotFound();
            }
            return Ok(pasajero);
        }

        /// <summary>
        ///  Crear un Pasajero
        ///  </summary>
        ///  <param name="pasajero"></param>
        /// <returns>JSON Pasajero</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Pasajero
        public IHttpActionResult Post(Pasajero pasajero)
        {
            db.Pasajero.Add(pasajero);
            db.SaveChanges();

            return Ok(pasajero);
        }

        /// <summary>
        ///  Modificar Pasajero
        ///  </summary>
        ///  <param name="PasajeroModificado"></param>
        /// <returns>JSON Pasajero</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Pasajero
        public IHttpActionResult Put(Pasajero PasajeroModificado)
        {
            int id = PasajeroModificado.pasajeroId;
            db.Entry(PasajeroModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(PasajeroModificado);
        }

        /// <summary>
        ///  Eliminar un Pasajero
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Pasajero</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Pasajero
        public IHttpActionResult Delete(int id)
        {
            Pasajero pasajero = db.Pasajero.Find(id);
            db.Pasajero.Remove(pasajero);
            db.SaveChanges();

            return Ok(pasajero);
        }
    }
}
