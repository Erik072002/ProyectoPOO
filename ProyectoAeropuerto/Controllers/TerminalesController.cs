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
    public class TerminalesController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        // GET: api/Asiento
        public IEnumerable<Terminales> Get()
        {
            return db.Terminales;
        }

        // GET: api/Asiento/5
        public IHttpActionResult Get(int id)
        {
            Terminales terminales = db.Terminales.Find(id);
            if (terminales == null)
            {
                NotFound();
            }
            return Ok(terminales);
        }

        // POST: api/Asiento
        public IHttpActionResult Post(Terminales Terminales)
        {

            if (Terminales.Aeropuerto != null)
            {
                Aeropuerto AeropuertoEncontrado = db.Aeropuerto.Find(Terminales.Aeropuerto.Id);
                Terminales.Aeropuerto = AeropuertoEncontrado;
            }
            db.Terminales.Add(Terminales);
            db.SaveChanges();

            return Ok(Terminales);
        }

        // DELETE: api/Asiento/5
        public IHttpActionResult Delete(int id)
        {
            Terminales terminales = db.Terminales.Find(id);
            db.Terminales.Remove(terminales);
            db.SaveChanges();

            return Ok(terminales);
        }
    }
}
