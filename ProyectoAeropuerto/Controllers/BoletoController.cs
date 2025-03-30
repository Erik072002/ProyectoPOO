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
        // GET: api/Asiento
        public IEnumerable<Boleto> Get()
        {
            return db.Boleto;
        }

        // GET: api/Asiento/5
        public IHttpActionResult Get(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                NotFound();
            }
            return Ok(boleto);
        }

        // POST: api/Asiento
        public IHttpActionResult Post(Boleto asiento)
        {
            db.Boleto.Add(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }

        // PUT: api/Asiento/5
        public IHttpActionResult Put(Boleto BoletoModificado)
        {
            int id = BoletoModificado.Id;
            db.Entry(BoletoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(BoletoModificado);
        }

        // DELETE: api/Asiento/5
        public IHttpActionResult Delete(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            db.Boleto.Remove(boleto);
            db.SaveChanges();

            return Ok(boleto);
        }
    }
}
