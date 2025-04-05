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
    public class VueloController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Vuelo
        ///  </summary>
        /// <returns>JSON Vuelo</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Vuelo
        public IEnumerable<Vuelo> Get()
        {
            return db.Vuelo;
        }

        /// <summary>
        ///  Obtener la salida de Vuelo por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Vuelo</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Vuelo
        public IHttpActionResult Get(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            if (vuelo == null)
            {
                NotFound();
            }
            return Ok(vuelo);
        }

        /// <summary>
        ///  Crear un Vuelo
        ///  </summary>
        ///  <param name="Vuelo"></param>
        /// <returns>JSON Vuelo</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Vuelo
        public IHttpActionResult Post(Vuelo Vuelo)
        {

            if (Vuelo.Avion != null)
            {
                Avion AvionEncontrado = db.Avion.Find(Vuelo.Avion.AvionId);
                Vuelo.Avion = AvionEncontrado;
            }
            if (Vuelo.Puerta_Abordaje != null)
            {
                Puerta_Abordaje puertadeabordajeEncontrado = db.Puerta_Abordaje.Find(Vuelo.Puerta_Abordaje.Id);
                Vuelo.Puerta_Abordaje = puertadeabordajeEncontrado;
            }
            if (Vuelo.Tripulacion != null)
            {
                Tripulacion TripulacionEncontrado = db.Tripulacion.Find(Vuelo.Tripulacion.Id);
                Vuelo.Tripulacion = TripulacionEncontrado;
            }
            if (Vuelo.Piloto != null)
            {
                Piloto PilotoEncontrado = db.Piloto.Find(Vuelo.Piloto.PilotoId);
                Vuelo.Piloto = PilotoEncontrado;
            }
            db.Vuelo.Add(Vuelo);
            db.SaveChanges();

            return Ok(Vuelo);
        }

        /// <summary>
        ///  Modificar un Vuelo
        ///  </summary>
        ///  <param name="VueloModificado"></param>
        /// <returns>JSON Vuelo</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Vuelo
        public IHttpActionResult Put(Vuelo VueloModificado)
        {
            int id = VueloModificado.VueloId;
            db.Entry(VueloModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(VueloModificado);
        }

        /// <summary>
        ///  Eliminar un Vuelo
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Vuelo</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Vuelo
        public IHttpActionResult Delete(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            db.Vuelo.Remove(vuelo);
            db.SaveChanges();

            return Ok(vuelo);
        }
    }
}
