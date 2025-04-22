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
    public class TripulacionController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Devuelve los tripulantes filtrados por la ID del vuelo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Tripulacion</returns>
        /// <response code = "200"> Devuelve si el valor es encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>

        [HttpGet]
        [SwaggerOperation("Tripulacion-por-Vuelo")]
        [Route("api/GetTripulacionVuelo")]
        public IHttpActionResult GetTripulacionVuelo(int id)
        {
            var query = from tripulacion in db.Tripulacion
                        join aeropuerto in db.Aeropuerto on tripulacion.VueloAsignado.Puerta_Abordaje.Terminales.Aeropuerto equals aeropuerto
                        join vuelo in db.Vuelo on tripulacion.VueloAsignado equals vuelo
                        join avion in db.Avion on tripulacion.VueloAsignado.Avion equals avion

                        where tripulacion.vueloId == id

                        select new
                        {
                            Aeropuerto = tripulacion.VueloAsignado.Puerta_Abordaje.Terminales.Aeropuerto.nombre,
                            Vuelo = tripulacion.vueloId,
                            Avion = tripulacion.VueloAsignado.Avion.Nombre
                        };
            return Ok(query);
        }

        [HttpGet]
        [SwaggerOperation("Tripulacion-por-Aeropuerto")]
        [Route("api/GetTripulacionAeropuerto")]
        public IHttpActionResult GetTripulacionAeropuerto(int id)
        {
            var query = from tripulacion in db.Tripulacion
                        join aeropuerto in db.Aeropuerto on tripulacion.VueloAsignado.Puerta_Abordaje.Terminales.Aeropuerto equals aeropuerto
                        join vuelo in db.Vuelo on tripulacion.VueloAsignado equals vuelo
                        join avion in db.Avion on tripulacion.VueloAsignado.Avion equals avion

                        where aeropuerto.aeropuertoId == id

                        select new
                        {
                            Aeropuerto = tripulacion.VueloAsignado.Puerta_Abordaje.Terminales.Aeropuerto.nombre,
                            Vuelo = tripulacion.vueloId,
                            Avion = tripulacion.VueloAsignado.Avion.Nombre
                        };
            return Ok(query);
        }

        /// <summary>
        ///  Muestra todos los Tripulacion
        ///  </summary>
        /// <returns>JSON Tripulacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Tripulacion
        public IEnumerable<Tripulacion> Get()
        {
            return db.Tripulacion;
        }

        /// <summary>
        ///  Obtener la salida de Tripulacion por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Tripulacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Tripulacion
        public IHttpActionResult Get(int id)
        {
            Tripulacion tripulacion = db.Tripulacion.Find(id);
            if (tripulacion == null)
            {
                NotFound();
            }
            return Ok(tripulacion);
        }

        /// <summary>
        ///  Crear un Tripulacion
        ///  </summary>
        ///  <param name="tripulacion"></param>
        /// <returns>JSON Tripulacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Tripulacion
        public IHttpActionResult Post(Tripulacion tripulacion)
        {
            if (tripulacion.VueloAsignado != null)
            {
                Vuelo VueloEncontrado = db.Vuelo.Find(tripulacion.VueloAsignado.vueloId);
                tripulacion.VueloAsignado = VueloEncontrado;
            }
            db.Tripulacion.Add(tripulacion);
            db.SaveChanges();

            return Ok(tripulacion);
        }

        /// <summary>
        ///  Modificar un Tripulacion
        ///  </summary>
        ///  <param name="tripulacionModificado"></param>
        /// <returns>JSON Tripulacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Tripulacion
        public IHttpActionResult Put(Tripulacion tripulacionModificado)
        {
            int id = tripulacionModificado.Id;
            db.Entry(tripulacionModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(tripulacionModificado);

        }

        /// <summary>
        ///  Eliminar un Tripulacion
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Tripulacion</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Tripulacion
        public IHttpActionResult Delete(int id)
        {
            Tripulacion tripulacion = db.Tripulacion.Find(id);
            db.Tripulacion.Remove(tripulacion);
            db.SaveChanges();

            return Ok(tripulacion);
        }
    }
}
