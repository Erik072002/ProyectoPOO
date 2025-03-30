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
        public IHttpActionResult Post(Vuelo vuelo)
        {
            db.Vuelo.Add(vuelo);
            db.SaveChanges();

            return Ok(vuelo);
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
