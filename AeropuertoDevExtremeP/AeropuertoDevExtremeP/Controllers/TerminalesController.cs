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
    public class TerminalesController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(DataSourceLoadOptions loadOptions)
        {
            var apiUrl = "https://localhost:44352/api/Terminales/";

            var respuestaJson = await GetAsync(apiUrl);
            //System.Diagnostics.Debug.WriteLine(respuestaJson); imprimir info
            List<Terminales> listaTerminales = JsonConvert.DeserializeObject<List<Terminales>>(respuestaJson);
            return Request.CreateResponse(DataSourceLoader.Load(listaTerminales, loadOptions));
        }

        public static async Task<string> GetAsync(string uri)
        {
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                using (var Terminales = new HttpClient(handler))
                {
                    var response = await Terminales.GetAsync(uri);
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

            var url = "https://localhost:44352/api/Terminales/";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var Terminales = new HttpClient(handler))
            {
                var response = await Terminales.PostAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }


        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));

            var apiUrlDelTerminales = "https://localhost:44352/api/Terminales/" + key;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var Terminales = new HttpClient(handler))
            {
                var respuestaTerminales = await Terminales.DeleteAsync(apiUrlDelTerminales);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        public async Task<HttpResponseMessage> Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key")); 
            var values = form.Get("values"); 

            var apiUrlGetTerminales = "https://localhost:44352/api/Terminales/" + key;
            var respuestaTerminales = await GetAsync(apiUrlGetTerminales = "https://localhost:44352/api/Terminales/" + key);
            Terminales Terminales = JsonConvert.DeserializeObject<Terminales>(respuestaTerminales);

            JsonConvert.PopulateObject(values, Terminales);

            string jsonString = JsonConvert.SerializeObject(Terminales);
            var httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            using (var client = new HttpClient(handler))
            {
                var url = "https://localhost:44352/api/Terminales/" + key;
                var response = await client.PutAsync(url, httpContent);

                var result = response.Content.ReadAsStringAsync().Result;
            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
