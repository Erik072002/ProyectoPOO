﻿using ProyectoAeropuerto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAeropuerto.Controllers
{
    public class PilotoController : ApiController
    {
        private MiDbContext db = new MiDbContext();


        /// <summary>
        /// Obtener la lista de Pilotos existentes
        /// </summary>
        /// <returns>JSON Piloto</returns>
        /// <response code="200">Devuelve los valores encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        /// 
        public IEnumerable<Piloto> Get()
        {
            return db.Piloto;
        }

        /// <summary>
        /// Obtener un Piloto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Piloto</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        /// 
        public IHttpActionResult Get(int id)
        {
            Piloto piloto = db.Piloto.Find(id);
            if (piloto == null)
            {
                NotFound();
            }
            return Ok(piloto);
        }

        /// <summary>
        /// Obtener la lista de Pilotos ingresados
        /// </summary>
        /// <param name="piloto"></param>
        /// <returns>JSON Piloto</returns>
        /// <response code="200">Devuelve los valores encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        /// 
        public IHttpActionResult Post(Piloto piloto)
        {
            if (piloto.VueloAsignado != null)
            {
                Vuelo VueloEncontrado = db.Vuelo.Find(piloto.VueloAsignado.vueloId);
                piloto.VueloAsignado = VueloEncontrado;
            }
            db.Piloto.Add(piloto);
            db.SaveChanges();
            return Ok(piloto);
        }

        /// <summary>
        /// Obtener el Piloto modificado
        /// </summary>
        /// <param name="PilotoModificado"></param>
        /// <returns>JSON Piloto</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        /// 
        public IHttpActionResult Put(Piloto PilotoModificado)
        {
            int id = PilotoModificado.pilotoId;


            db.Entry(PilotoModificado).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(PilotoModificado);

        }

        /// <summary>
        /// Obtener el Piloto eliminado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>JSON Piloto</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        /// 
        public IHttpActionResult Delete(int id)
        {
            Piloto piloto = db.Piloto.Find(id);
            db.Piloto.Remove(piloto);
            db.SaveChanges();

            return Ok(piloto);
        }
    }
}
