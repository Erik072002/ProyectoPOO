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
    public class VueloController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        /// Devulve los valores segun un rango de fechas ingresados
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns>JSON Vuelo</returns>
        /// <response code = "200"> Devuelve si  los valores fueron encontrados</response>
        /// <response code = "404"> Devuelve si  los valores no fueron encontrado</response>
        [HttpGet]
        [SwaggerOperation("Vuelo-por-Fecha")]
        [Route("api/GetVueloFecha")]

        public IHttpActionResult GetVueloFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            var query = from vuelo in db.Vuelo
                        join avion in db.Avion on vuelo.Avion equals avion
                        join aeropuerto in db.Aeropuerto on vuelo.Puerta_Abordaje.Terminales.Aeropuerto equals aeropuerto
                        join terminales in db.Terminales on vuelo.Puerta_Abordaje.Terminales equals terminales

                        where vuelo.Fecha_salida >= FechaDesde && vuelo.Fecha_Llegada <= FechaHasta
                        select new
                        {
                            Avion = vuelo.Avion.avionId,
                            Aeropuerto = vuelo.Puerta_Abordaje.Terminales.Aeropuerto.nombre,
                            Terminales = vuelo.Puerta_Abordaje.Terminales.Nombre_Area
                        };

            return Ok(query);
        }

        /// <summary>
        /// Devuelve la lista de vuelos que a tenido un avion
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Vuelo</returns>
        /// <response code = "200"> Devuelve si  los valores fueron encontrados</response>
        /// <response code = "404"> Devuelve si  los valores no fueron encontrado</response>

        [HttpGet]
        [SwaggerOperation("Vuelo-por-Avion")]
        [Route("api/GetVueloAvion")]

        public IHttpActionResult GetVueloAvion(int id)
        {
            var query = from vuelo in db.Vuelo
                        join avion in db.Avion on vuelo.Avion equals avion
                        join aeropuerto in db.Aeropuerto on vuelo.Puerta_Abordaje.Terminales.Aeropuerto equals aeropuerto
                        join terminales in db.Terminales on vuelo.Puerta_Abordaje.Terminales equals terminales

                        where vuelo.Avion.avionId == id
                        select new
                        {
                            Vuelo = vuelo.vueloId,
                            Aeropuerto = vuelo.Puerta_Abordaje.Terminales.Aeropuerto.nombre,
                            Terminal = vuelo.Puerta_Abordaje.Terminales.Nombre_Area
                        };

            return Ok(query);
        }

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
                Avion AvionEncontrado = db.Avion.Find(Vuelo.Avion.avionId);
                Vuelo.Avion = AvionEncontrado;
            }
            if (Vuelo.Puerta_Abordaje != null)
            {
                Puerta_Abordaje puertadeabordajeEncontrado = db.Puerta_Abordaje.Find(Vuelo.Puerta_Abordaje.Puerta_AbordajeId);
                Vuelo.Puerta_Abordaje = puertadeabordajeEncontrado;
                
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
            int id = VueloModificado.vueloId;
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
