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
    public class Puerta_AbordajeController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Puerta de abordaje
        ///  </summary>
        /// <returns>JSON Puerta de abordaje</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Puerta de abordaje
        public IEnumerable<Puerta_Abordaje> Get()
        {
            return db.Puerta_Abordaje;
        }

        /// <summary>
        ///  Obtener la salida de Puerta de abordaje por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Puerta de abordaje</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Puerta de abordaje
        public IHttpActionResult Get(int id)
        {
            Puerta_Abordaje puerta_abordaje = db.Puerta_Abordaje.Find(id);
            if (puerta_abordaje == null)
            {
                NotFound();
            }
            return Ok(puerta_abordaje);
        }

        /// <summary>
        ///  Crear un Puerta de abordaje
        ///  </summary>
        ///  <param name="puerta_Abordaje"></param>
        /// <returns>JSON Puerta de abordaje</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Puerta de abordaje
        public IHttpActionResult Post(Puerta_Abordaje puerta_Abordaje)
        {

            if (puerta_Abordaje.Terminales != null)
            {
                Terminales TerminalesEncontrado = db.Terminales.Find(puerta_Abordaje.Terminales.terminalesId);
                puerta_Abordaje.Terminales = TerminalesEncontrado;
            }
            db.Puerta_Abordaje.Add(puerta_Abordaje);
            db.SaveChanges();
            return Ok(puerta_Abordaje);
        }

        /// <summary>
        ///  Modificar un Puerta de abordaje
        ///  </summary>
        ///  <param name="Puerta_AbordajeModificado"></param>
        /// <returns>JSON Puerta de abordaje</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Puerta de abordaje
        public IHttpActionResult Put(Puerta_Abordaje Puerta_AbordajeModificado)
        {
            int id = Puerta_AbordajeModificado.Puerta_AbordajeId;
            db.Entry(Puerta_AbordajeModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(Puerta_AbordajeModificado);
        }

        /// <summary>
        /// Eliminar un Puerta de abordaje
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Puerta de abordaje</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Puerta de abordaje
        public IHttpActionResult Delete(int id)
        {
            Puerta_Abordaje puerta_abordaje = db.Puerta_Abordaje.Find(id);
            db.Puerta_Abordaje.Remove(puerta_abordaje);
            db.SaveChanges();

            return Ok(puerta_abordaje);
        }
    }
}
