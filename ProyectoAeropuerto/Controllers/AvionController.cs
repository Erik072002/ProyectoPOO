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
    public class AvionController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        // GET: api/Avion
        public IEnumerable<Avion> Get()
        {
            return db.Avion;
        }

        // GET: api/Avion/5
        public IHttpActionResult Get(int id)
        {
            Avion avion = db.Avion.Find(id);
            if (avion == null)
            {
                NotFound(); 
            }
            return Ok(avion);
        }

        // POST: api/Avion
        public IHttpActionResult Post(Avion avion)
        {
            db.Avion.Add(avion);
            db.SaveChanges();
            return Ok(avion);
        }

        // PUT: api/Avion/5
        public IHttpActionResult Put(Avion AvionModificado)
        {
            int id = AvionModificado.AvionId;
            db.Entry(AvionModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(AvionModificado);
        }

        // DELETE: api/Avion/5
        public IHttpActionResult Delete(int id)
        {
            Avion avion = db.Avion.Find(id);
            db.Avion.Remove(avion);
            db.SaveChanges();

            return Ok(avion);
        }
    }
}
