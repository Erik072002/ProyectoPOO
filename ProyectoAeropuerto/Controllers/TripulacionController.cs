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
    public class TripulacionController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        // GET: api/Tripulacion
        public IEnumerable<Tripulacion> Get()
        {
            return db.Tripulacion;
        }

        // GET: api/Tripulacion/5
        public IHttpActionResult Get(int id)
        {
            Tripulacion tripulacion = db.Tripulacion.Find(id);
            if (tripulacion == null)
            {
                NotFound();
            }
            return Ok(tripulacion);
        }

        // POST: api/Tripulacion
        public IHttpActionResult Post(Tripulacion tripulacion)
        {
            db.Tripulacion.Add(tripulacion);
            db.SaveChanges();

            return Ok(tripulacion);
        }

        // PUT: api/Tripulacion/5
        public IHttpActionResult Put(Tripulacion tripulacionModificado)
        {
            int id = tripulacionModificado.Id;
            db.Entry(tripulacionModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(tripulacionModificado);

        }

        // DELETE: api/Tripulacion/5
        public IHttpActionResult Delete(int id)
        {
            Tripulacion tripulacion = db.Tripulacion.Find(id);
            db.Tripulacion.Remove(tripulacion);
            db.SaveChanges();

            return Ok(tripulacion);
        }
    }
}
