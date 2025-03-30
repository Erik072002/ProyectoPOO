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
    public class MetodoDePagoController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        // GET: api/Metodo_Pago
        public IEnumerable<MetodoDePago> Get()
        {
            return db.MetodoDePago;
        }

        // GET: api/Metodo_Pago/5
        public IHttpActionResult Get(int id)
        {
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            if (metodoDePago == null)
            {
                NotFound();
            }
            return Ok(metodoDePago);
        }

        // POST: api/Metodo_Pago
        public IHttpActionResult Post(MetodoDePago metodoDePago)
        {
            db.MetodoDePago.Add(metodoDePago);
            db.SaveChanges();

            return Ok(metodoDePago);
        }

        // PUT: api/Metodo_Pago/5
        public IHttpActionResult Put(MetodoDePago ModificarMetodo)
        {
            int id = ModificarMetodo.Id;

            db.Entry(ModificarMetodo).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(ModificarMetodo);
        }

        // DELETE: api/Metodo_Pago/5
        public IHttpActionResult Delete(int id)
        {
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            db.MetodoDePago.Remove(metodoDePago);
            db.SaveChanges();

            return Ok(metodoDePago);
        }
    }
}
