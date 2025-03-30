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
    public class FacturacionController : ApiController
    {
        private MiDbContext db = new MiDbContext();
        // GET: api/Asiento
        public IEnumerable<Facturacion> Get()
        {
            return db.Facturacion;
        }

        // GET: api/Asiento/5
        public IHttpActionResult Get(int id)
        {
            Facturacion facturacion = db.Facturacion.Find(id);
            if (facturacion == null)
            {
                NotFound();
            }
            return Ok(facturacion);
        }

        // POST: api/Asiento
        public IHttpActionResult Post(Facturacion facturacion)
        {
            db.Facturacion.Add(facturacion);
            db.SaveChanges();

            return Ok(facturacion);
        }

        // PUT: api/Asiento/5
        public IHttpActionResult Put(Facturacion FacturacionModificado)
        {
            int id = FacturacionModificado.Id;
            db.Entry(FacturacionModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(FacturacionModificado);
        }

        // DELETE: api/Asiento/5
        public IHttpActionResult Delete(int id)
        {
            Facturacion facturacion = db.Facturacion.Find(id);
            db.Facturacion.Remove(facturacion);
            db.SaveChanges();

            return Ok(facturacion);
        }
    }
}
