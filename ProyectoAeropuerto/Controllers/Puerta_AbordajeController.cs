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
    public class Puerta_AbordajeController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        // GET: api/Asiento
        public IEnumerable<Puerta_Abordaje> Get()
        {
            return db.Puerta_Abordaje;
        }

        // GET: api/Asiento/5
        public IHttpActionResult Get(int id)
        {
            Puerta_Abordaje puerta_abordaje = db.Puerta_Abordaje.Find(id);
            if (puerta_abordaje == null)
            {
                NotFound();
            }
            return Ok(puerta_abordaje);
        }

        // POST: api/Asiento
        public IHttpActionResult Post(Puerta_Abordaje puerta_Abordaje)
        {

            if (puerta_Abordaje.Terminales != null)
            {
                Terminales TerminalesEncontrado = db.Terminales.Find(puerta_Abordaje.Terminales.Id);
                puerta_Abordaje.Terminales = TerminalesEncontrado;
            }
            db.Puerta_Abordaje.Add(puerta_Abordaje);
            db.SaveChanges();
            return Ok(puerta_Abordaje);
        }

        // PUT: api/Asiento/5
        public IHttpActionResult Put(Puerta_Abordaje Puerta_AbordajeModificado)
        {
            int id = Puerta_AbordajeModificado.Id;
            db.Entry(Puerta_AbordajeModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(Puerta_AbordajeModificado);
        }

        // DELETE: api/Asiento/5
        public IHttpActionResult Delete(int id)
        {
            Puerta_Abordaje puerta_abordaje = db.Puerta_Abordaje.Find(id);
            db.Puerta_Abordaje.Remove(puerta_abordaje);
            db.SaveChanges();

            return Ok(puerta_abordaje);
        }
    }
}
