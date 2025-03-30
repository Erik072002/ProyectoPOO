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
    public class AeropuertoController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        // GET: api/Asiento
        public IEnumerable<Aeropuerto> Get()
        {
            return db.Aeropuerto;
        }

        // GET: api/Asiento/5
        public IHttpActionResult Get(int id)
        {
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            if (aeropuerto == null)
            {
                NotFound();
            }
            return Ok(aeropuerto);
        }

        // POST: api/Asiento
        public IHttpActionResult Post(Aeropuerto asiento)
        {
            db.Aeropuerto.Add(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }

        // PUT: api/Asiento/5
        public IHttpActionResult Put(Aeropuerto AeropuertoModificado)
        {
            int id = AeropuertoModificado.Id;
            db.Entry(AeropuertoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(AeropuertoModificado);
        }

        // DELETE: api/Asiento/5
        public IHttpActionResult Delete(int id)
        {
            Aeropuerto aeropuerto = db.Aeropuerto.Find(id);
            db.Aeropuerto.Remove(aeropuerto);
            db.SaveChanges();

            return Ok(aeropuerto);
        }
    }
}
