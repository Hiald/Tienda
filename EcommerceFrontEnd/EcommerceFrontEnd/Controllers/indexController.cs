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
    public class indexController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            var valorCuenta = UtlAuditoria.ValidarSession();
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

            // LISTAR PRODUCTOS EN PROMOCION
            List<edProducto> loenProductoPromocion = new List<edProducto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ReslistarProducto = await client.GetAsync("api/producto/APIBuscarProducto?wstipofiltro=1&wsnombre=" + "" + "&wscategoria=0");
                if (ReslistarProducto.IsSuccessStatusCode)
                {
                    var rwsapilu = ReslistarProducto.Content.ReadAsAsync<string>().Result;
                    loenProductoPromocion = JsonConvert.DeserializeObject<List<edProducto>>(rwsapilu);
                }
                else
                {
                    loenProductoPromocion = null;
                }
            }

            // LISTAR PRODUCTOS SIN PROMOCION
            List<edProducto> loenProducto = new List<edProducto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ReslistarProducto = await client.GetAsync("api/producto/APIBuscarProducto?wstipofiltro=0&wsnombre=" + "" + "&wscategoria=0");
                if (ReslistarProducto.IsSuccessStatusCode)
                {
                    var rwsapilu = ReslistarProducto.Content.ReadAsAsync<string>().Result;
                    loenProducto = JsonConvert.DeserializeObject<List<edProducto>>(rwsapilu);
                }
                else
                {
                    loenProducto = null;
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

            ViewBag.loenProducto = loenProducto;
            ViewBag.loenProductoPromocion = loenProductoPromocion;
            ViewBag.lstCategoria = loenCategoria;

            return View();
        }

        public async Task<ActionResult> producto(int categoriaid)
        {
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

            var objResultado = new object();
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

            // LISTAR PRODUCTOS SIN PROMOCION
            List<edProducto> loenProducto = new List<edProducto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ReslistarProducto = await client.GetAsync("api/producto/APIBuscarProducto?wstipofiltro=0&wsnombre=" + "" + "&wscategoria=" + categoriaid);
                if (ReslistarProducto.IsSuccessStatusCode)
                {
                    var rwsapilu = ReslistarProducto.Content.ReadAsAsync<string>().Result;
                    loenProducto = JsonConvert.DeserializeObject<List<edProducto>>(rwsapilu);
                }
                else
                {
                    loenProducto = null;
                }
            }

            ViewBag.lstCategoria = loenCategoria;
            ViewBag.lstProducto = loenProducto;

            return View();
        }

        //producto detalle
        public async Task<ActionResult> detalle(int wtipoPromocion, int wproductoid)
        {
            ViewBag.icantidad = 0;
            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            ViewBag.sNombre = "Hola, Inicia sesión";
            ViewBag.sTextoMenu = "Registrarme";
            ViewBag.iValorCuenta = "#signin-modal";
            ViewBag.GproductoID = wproductoid;
            if (sNombreSesion != "")
            {
                ViewBag.iValorCuenta = "#account-modal";
                ViewBag.sNombre = "Hola, " + sNombreSesion;
                ViewBag.sTextoMenu = "Mi cuenta";
            }

            // LISTAR PRODUCTOS DETALLE
            edProducto oenProducto = new edProducto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ReslistarProducto = await client.GetAsync("api/producto/APIListarProductoDetalle?wstipromocion=" + wtipoPromocion
                                                                        + "&wsproductoid=" + wproductoid);
                if (ReslistarProducto.IsSuccessStatusCode)
                {
                    var rwsapilu = ReslistarProducto.Content.ReadAsAsync<string>().Result;
                    oenProducto = JsonConvert.DeserializeObject<edProducto>(rwsapilu);
                }
                else
                {
                    oenProducto = null;
                }
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

            // LISTAR PRODUCTOS SIN PROMOCION
            List<edProducto> loenProducto = new List<edProducto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ReslistarProducto = await client.GetAsync("api/producto/APIBuscarProducto?wstipofiltro=0&wsnombre=" + "" + "&wscategoria=0");
                if (ReslistarProducto.IsSuccessStatusCode)
                {
                    var rwsapilu = ReslistarProducto.Content.ReadAsAsync<string>().Result;
                    loenProducto = JsonConvert.DeserializeObject<List<edProducto>>(rwsapilu);
                }
                else
                {
                    loenProducto = null;
                }
            }

            ViewBag.lstProductoGeneral = loenProducto;
            ViewBag.lstProducto = oenProducto;
            ViewBag.lstCategoria = loenCategoria;

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ListarEspecificacion(int wproductoid)
        {
            try
            {
                var objResultado = new object();
                List<edConfiguracion> loenConfiguracion = new List<edConfiguracion>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage ReslistarAdicional = await client.GetAsync("api/configuracion/APIListarEspecificacion?wsleproductoid=" + wproductoid);
                    if (ReslistarAdicional.IsSuccessStatusCode)
                    {
                        var rwsapilu = ReslistarAdicional.Content.ReadAsAsync<string>().Result;
                        loenConfiguracion = JsonConvert.DeserializeObject<List<edConfiguracion>>(rwsapilu);
                    }
                    else
                    {
                        loenConfiguracion[0].configuracionid = -1;
                    }
                }

                objResultado = new
                {
                    iTotalRecords = loenConfiguracion.Count,
                    objData = loenConfiguracion
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [Route("mipedido")]
        public ActionResult pedido()
        {
            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            var valorCuenta = UtlAuditoria.ValidarSession();
            ViewBag.sNombre = "Hola, Inicia sesión";
            ViewBag.sTextoMenu = "Registrarme";
            ViewBag.iValorCuenta = "#signin-modal";
            if (sNombreSesion != "")
            {
                ViewBag.iValorCuenta = "#account-modal";
                ViewBag.sNombre = "Hola, " + sNombreSesion;
                ViewBag.sTextoMenu = "Mi cuenta";
            }

            return View();
        }

        public ActionResult error()
        {
            return View();
        }

    }
}