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
    public class PasajeroController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44352/api/Pasajero/";

            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson); imprimir info
            List<Pasajero> listaPasajero = JsonConvert.DeserializeObject<List<Pasajero>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaPasajero, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var Pasajero = new HttpClient(handler))
                {
                    var response = await Pasajero.GetAsync(uri);
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

            var url = "https://localhost:44352/api/Pasajero/";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var Pasajero = new HttpClient(handler))
            {
                var response = await Pasajero.PostAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }


        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelPasajero = "https://localhost:44352/api/Pasajero/" + key;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var Pasajero = new HttpClient(handler))
            {
                var respuestaPasajero = await Pasajero.DeleteAsync(apiUrlDelPasajero);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key")); 
            var values = form.Get("values"); 

            var apiUrlGetPasajero = "https://localhost:44352/api/Pasajero/" + key;
            var respuestaPasajero = await GetAsync(apiUrlGetPasajero = "https://localhost:44352/api/Pasajero/" + key);
            Pasajero Pasajero = JsonConvert.DeserializeObject<Pasajero>(respuestaPasajero);

            JsonConvert.PopulateObject(values, Pasajero);

            string jsonString = JsonConvert.SerializeObject(Pasajero);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var url = "https://localhost:44352/api/Pasajero/" + key;
                var response = await client.PutAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
