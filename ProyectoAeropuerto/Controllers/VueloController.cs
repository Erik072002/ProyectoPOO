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
        // GET: api/Asiento
        public IEnumerable<Vuelo> Get()
        {
            return db.Vuelo;
        }

        // GET: api/Asiento/5
        public IHttpActionResult Get(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            if (vuelo == null)
            {
                NotFound();
            }
            return Ok(vuelo);
        }

        // POST: api/Asiento
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

        // PUT: api/Asiento/5
        public IHttpActionResult Put(Vuelo VueloModificado)
        {
            int id = VueloModificado.VueloId;
            db.Entry(VueloModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(VueloModificado);
        }

        // DELETE: api/Asiento/5
        public IHttpActionResult Delete(int id)
        {
            Vuelo vuelo = db.Vuelo.Find(id);
            db.Vuelo.Remove(vuelo);
            db.SaveChanges();

            return Ok(vuelo);
        }
    }
}
