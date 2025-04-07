using AeropuertoDevExtremeP.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace AeropuertoDevExtremeP.Controllers
{
    public class Puerta_AbordajeController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44352/api/Puerta_Abordaje/";

            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson); imprimir info
            List<Puerto_Abordaje> listaPuerta_Abordaje = JsonConvert.DeserializeObject<List<Puerto_Abordaje>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaPuerta_Abordaje, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var Puerta_Abordaje = new HttpClient(handler))
                {
                    var response = await Puerta_Abordaje.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }

            }
            catch (Exception e)
            {
                var m = e.Message;
                return null;
            }

        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(FormDataCollection form)
        {

            var values = form.Get("values");

            var httpContent = new StringContent(values, System.Text.Encoding.UTF8, "application/json");

            var url = "https://localhost:44352/api/Puerta_Abordaje/";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var Puerta_Abordaje = new HttpClient(handler))
            {
                var response = await Puerta_Abordaje.PostAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }


        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelPuerta_Abordaje = "https://localhost:44352/api/Puerta_Abordaje/" + key;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var Puerta_Abordaje = new HttpClient(handler))
            {
                var respuestaPuerta_Abordaje = await Puerta_Abordaje.DeleteAsync(apiUrlDelPuerta_Abordaje);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            //Parámetros del form
            var key = Convert.ToInt32(form.Get("key")); //llave que estoy modificando
            var values = form.Get("values"); //Los valores que yo modifiqué en formato JSON

            var apiUrlGetPuerta_Abordaje = "https://localhost:44352/api/Puerta_Abordaje/" + key;
            var respuestaPuerta_Abordaje = await GetAsync(apiUrlGetPuerta_Abordaje = "https://localhost:44352/api/Puerta_Abordaje/" + key);
            Puerto_Abordaje Puerta_Abordaje = JsonConvert.DeserializeObject<Puerto_Abordaje>(respuestaPuerta_Abordaje);

            JsonConvert.PopulateObject(values, Puerta_Abordaje);

            string jsonString = JsonConvert.SerializeObject(Puerta_Abordaje);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var url = "https://localhost:44352/api/Puerta_Abordaje/" + key;
                var response = await client.PutAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
