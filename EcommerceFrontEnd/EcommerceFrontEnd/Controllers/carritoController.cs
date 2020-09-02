using frontendUtil;
using frontendED;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EcommerceFrontEnd.Controllers
{
    public class carritoController : Controller
    {

        public async Task<ActionResult> listado()
        {
            var valorCuenta = UtlAuditoria.ValidarSession();
            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            ViewBag.sNombre = "Hola, Inicia sesión";
            ViewBag.sTextoMenu = "Registrarme";
            ViewBag.iValorCuenta = "#signin-modal";
            if (sNombreSesion != "")
            {
                ViewBag.iValorCuenta = "#account-modal";
                ViewBag.sNombre = "Hola, " + sNombreSesion;
                ViewBag.sTextoMenu = "Mi cuenta";
            }

            // LISTAR LA CATEGORIAS
            List<edCategoria> loenCategoria = new List<edCategoria>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/categoria/APIListarCategoria?wsvalor=0");
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenCategoria = JsonConvert.DeserializeObject<List<edCategoria>>(rwsapilu);
                }
                else
                {
                    loenCategoria = null;
                }
            }

            if (valorCuenta)
            {
                //significa que no se ha creado cuenta o no se ha logeado
                ViewBag.BValorCuenta = 1;
            }
            else
            {
                //significa que si esta logeado
                ViewBag.BValorCuenta = 0;
            }
            ViewBag.lstCategoria = loenCategoria;

            return View();
        }


    }
}