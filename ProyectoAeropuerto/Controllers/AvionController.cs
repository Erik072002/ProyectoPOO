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
    public class AvionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Avion
        ///  </summary>
        /// <returns>JSON Avion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Avion
        public IEnumerable<Avion> Get()
        {
            return db.Avion;
        }

        /// <summary>
        ///  Obtener la salida de Avion por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Avion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Avion
        public IHttpActionResult Get(int id)
        {
            Avion avion = db.Avion.Find(id);
            if (avion == null)
            {
                NotFound(); 
            }
            return Ok(avion);
        }

        /// <summary>
        ///  Crear un Avion
        ///  </summary>
        ///  <param name="avion"></param>
        /// <returns>JSON Avion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Avion
        public IHttpActionResult Post(Avion avion)
        {
            db.Avion.Add(avion);
            db.SaveChanges();
            return Ok(avion);
        }

        /// <summary>
        ///  Modificar un Avion
        ///  </summary>
        ///  <param name="AvionModificado"></param>
        /// <returns>JSON Avion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Avion
        public IHttpActionResult Put(Avion AvionModificado)
        {
            int id = AvionModificado.avionId;
            db.Entry(AvionModificado).State = EntityState.Modified;

            return Ok(AvionModificado);
        }

        /// <summary>
        ///  Eliminar un Avion
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Avion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Avion
        public IHttpActionResult Delete(int id)
        {
            Avion avion = db.Avion.Find(id);
            db.Avion.Remove(avion);
            db.SaveChanges();

            return Ok(avion);
        }
    }
}
