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
        // GET: api/Pasajero
        public IEnumerable<Pasajero> Get()
        {
            return db.Pasajero;
        }

        // GET: api/Pasajero/5
        public IHttpActionResult Get(int id)
        {
            Pasajero pasajero = db.Pasajero.Find(id);
            if (pasajero == null)
            {
                NotFound();
            }
            return Ok(pasajero);
        }

        // POST: api/Pasajero
        public IHttpActionResult Post(Pasajero pasajero)
        {
            db.Pasajero.Add(pasajero);
            db.SaveChanges();

            return Ok(pasajero);
        }

        // PUT: api/Pasajero/5
        public IHttpActionResult Put(Pasajero PasajeroModificado)
        {
            int id = PasajeroModificado.PasajeroId;
            db.Entry(PasajeroModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(PasajeroModificado);
        }

        // DELETE: api/Pasajero/5
        public IHttpActionResult Delete(int id)
        {
            Pasajero pasajero = db.Pasajero.Find(id);
            db.Pasajero.Remove(pasajero);
            db.SaveChanges();

            return Ok(pasajero);
        }
    }
}
