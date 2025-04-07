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
    public class BoletoController : ApiController
    {
        private MiDbContext db = new MiDbContext();

        /// <summary>
        ///  Muestra todos los Boleto
        ///  </summary>
        /// <returns>JSON Boleto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Boleto
        public IEnumerable<Boleto> Get()
        {
            return db.Boleto;
        }

        /// <summary>
        ///  Obtener la salida de Boleto por un id
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Boleto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // GET: api/Boleto
        public IHttpActionResult Get(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                NotFound();
            }
            return Ok(boleto);
        }

        /// <summary>
        ///  Crear un Boleto
        ///  </summary>
        ///  <param name="boleto"></param>
        /// <returns>JSON Boleto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // POST: api/Boleto
        public IHttpActionResult Post(Boleto boleto)
        {

            if (boleto.Pasajero != null)
            {
                Pasajero pasajeroEncontrado = db.Pasajero.Find(boleto.Pasajero.pasajeroId);
                boleto.Pasajero = pasajeroEncontrado;
            }
            if (boleto.Vuelo != null)
            {
                Vuelo vueloEncontrado = db.Vuelo.Find(boleto.Vuelo.vueloId);
                boleto.Vuelo = vueloEncontrado;
            }
            if (boleto.Asiento != null)
            {
                Asiento asientoEncontrado = db.Asiento.Find(boleto.Asiento.asientoId);
                boleto.Asiento = asientoEncontrado;
            }
            db.Boleto.Add(boleto);
            db.SaveChanges();

            return Ok(boleto);
        }

        /// <summary>
        ///  Modificar un Boleto
        ///  </summary>
        ///  <param name="BoletoModificado"></param>
        /// <returns>JSON Boleto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // PUT: api/Boleto
        public IHttpActionResult Put(Boleto BoletoModificado)
        {
            int id = BoletoModificado.boletoId;
            db.Entry(BoletoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(BoletoModificado);
        }

        /// <summary>
        ///  Eliminar un Boleto
        ///  </summary>
        ///  <param name="id"></param>
        /// <returns>JSON Boleto</returns>
        /// <response code = "200"> Devuelve el valor encontrado</response>
        /// <response code = "404"> Si  el valor no es encontrado</response>
        // DELETE: api/Boleto
        public IHttpActionResult Delete(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            db.Boleto.Remove(boleto);
            db.SaveChanges();

            return Ok(boleto);
        }
    }
}
