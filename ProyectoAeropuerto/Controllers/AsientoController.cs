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
        // GET: api/Asiento
        public IEnumerable<Asiento> Get()
        {
            return db.Asiento;
        }

        // GET: api/Asiento/5
        public IHttpActionResult Get(int id)
        {
            Asiento asiento = db.Asiento.Find(id);
            if (asiento == null)
            {
                NotFound();
            }
            return Ok(asiento);
        }

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

        // PUT: api/Asiento/5
        public IHttpActionResult Put(Asiento AsientoModificado)
        {
            int id = AsientoModificado.AsientoId;
            db.Entry(AsientoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(AsientoModificado);
        }

        // DELETE: api/Asiento/5
        public IHttpActionResult Delete(int id)
        {
            Asiento asiento = db.Asiento.Find(id);
            db.Asiento.Remove(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }
    }
}
