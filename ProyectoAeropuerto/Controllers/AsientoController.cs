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
    public class AsientoController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Asiento
        ///  </summary>
        /// <returns>JSON Asiento</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Asiento
        public IEnumerable<Asiento> Get()
        {
            return db.Asiento;
        }

        /// <summary>
        ///  Obtener la salida de Asiento por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Asiento</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Asiento
        public IHttpActionResult Get(int id)
        {
            Asiento asiento = db.Asiento.Find(id);
            if (asiento == null)
            {
                NotFound();
            }
            return Ok(asiento);
        }

        /// <summary>
        ///  Crear un Asiento
        ///  </summary>
        ///  <param name="asiento"></param>
        /// <returns>JSON Asiento</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Asiento
        public IHttpActionResult Post(Asiento asiento)
        {
            
            if (asiento.Avion != null)
            {
                Avion AvionEncontrado = db.Avion.Find(asiento.Avion.AvionId);
                asiento.Avion = AvionEncontrado;
            }
            db.Asiento.Add(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }

        /// <summary>
        ///  Modificar un Asiento
        ///  </summary>
        ///  <param name="AsientoModificado"></param>
        /// <returns>JSON Asiento</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Asiento
        public IHttpActionResult Put(Asiento AsientoModificado)
        {
            int id = AsientoModificado.AsientoId;
            db.Entry(AsientoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(AsientoModificado);
        }

        /// <summary>
        ///  Eliminar un Asiento
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Asiento</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Asiento
        public IHttpActionResult Delete(int id)
        {
            Asiento asiento = db.Asiento.Find(id);
            db.Asiento.Remove(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }
    }
}
