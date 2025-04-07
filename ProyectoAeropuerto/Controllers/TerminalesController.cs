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
    public class TerminalesController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Terminales
        ///  </summary>
        /// <returns>JSON Terminales</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Terminales
        public IEnumerable<Terminales> Get()
        {
            return db.Terminales;
        }

        /// <summary>
        ///  Obtener la salida de Terminales por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Terminales</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Terminales
        public IHttpActionResult Get(int id)
        {
            Terminales terminales = db.Terminales.Find(id);
            if (terminales == null)
            {
                NotFound();
            }
            return Ok(terminales);
        }

        /// <summary>
        ///  Crear un Terminales
        ///  </summary>
        ///  <param name="Terminales"></param>
        /// <returns>JSON Terminales</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Terminales
        public IHttpActionResult Post(Terminales Terminales)
        {

            if (Terminales.Aeropuerto != null)
            {
                var AeropuertoEncontrado = db.Aeropuerto.Find(Terminales.Aeropuerto.aeropuertoId);
                Terminales.Aeropuerto = AeropuertoEncontrado;
                
            }
            db.Terminales.Add(Terminales);
            db.SaveChanges();

            return Ok(Terminales);
        }

        /// <summary>
        ///  Modificar un Terminales
        ///  </summary>
        ///  <param name="TerminalesModificado"></param>
        /// <returns>JSON Terminales</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Terminales
        public IHttpActionResult Put(Terminales TerminalesModificado)
        {
            int id = TerminalesModificado.Id;
            db.Entry(TerminalesModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(TerminalesModificado);
        }

        /// <summary>
        ///  Eliminar un Terminales
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Terminales</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Terminales
        public IHttpActionResult Delete(int id)
        {
            Terminales terminales = db.Terminales.Find(id);
            db.Terminales.Remove(terminales);
            db.SaveChanges();

            return Ok(terminales);
        }
    }
}
