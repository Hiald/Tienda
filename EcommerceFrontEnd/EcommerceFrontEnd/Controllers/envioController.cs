using frontendUtil;
using frontendED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EcommerceFrontEnd.Filters;
using System.IO;

namespace EcommerceFrontEnd.Controllers
{
    public class envioController : Controller
    {

        [HttpPost]
        public async Task<JsonResult> RegistrarEnvio(int wventaid, int wvendedorid, Int16 wentregadoTipo, Int16 westadoEnvio,
                                                   string wdireccion, string wnumero, int westadoProvincia, int wciudad, string wfechaEntrega
                                                   , string whoraEntrega)
        {
            var objResultado = new object();
            int iResultado = -1;
            int iUsuarioID = UtlAuditoria.ObtenerIdUsuario();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/envio/APIRegistrarEnvio?wsusuarioid=" + iUsuarioID +
                                    "&wsventaid=" + wventaid + "&wsvendedorid=" + wvendedorid + "&wsnombre=" + "" + "&wsnumero=" + wnumero
                                    + "&wsdireccion=" + wdireccion + "&wspisodescripcion=" + "" + "&wsipais=" + 0 + "&wsidistrito=" + 0
                                    + "&wsestadoProvincia=" + westadoProvincia + "&wssestadoprovincia=" + "" + "&wsciudad=" + wciudad + "&wssciudad=" + ""
                                    + "&wsscodigopostal=" + "" + "&wsentregadoTipo=" + wentregadoTipo + "&wsestadoEnvio=" + westadoEnvio
                                    + "&wsfechaEntrega=" + wfechaEntrega + "&wshoraEntrega=" + whoraEntrega + "&wsfechaRegistro=" + "");

                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var lpoVC = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        iResultado = int.Parse(lpoVC);
                    }
                    else
                    {
                        iResultado = -3;
                    }
                }
                objResultado = new
                {
                    iResultado = 1,
                    sResultado = "Correcto"
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

        // --------------------- VENDEDOR ----------------------------------

        /// <summary>
        /// retorna json con el listado de envios del vendedor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ListarEnvioVendedor()
        {
            var objResultado = new object();
            List<edEnvio> loenEnvio = new List<edEnvio>();
            var ivendedorID = UtlAuditoria.ObtenerIdUsuario();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/envio/APIListarEnvio?wsvendedorid=" + ivendedorID);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        loenEnvio = JsonConvert.DeserializeObject<List<edEnvio>>(rwsapilu);
                    }
                    else
                    {
                        loenEnvio = null;
                    }
                }
                objResultado = new
                {
                    rDato = loenEnvio,
                    iDatoCount = loenEnvio.Count
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                    iDatoCount = 0
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

        /// <summary>
        /// retorna correcto o error despues de actualizar el envio
        /// </summary>
        /// <param name="wenvioid"></param>
        /// <param name="wentregadoTipo"></param>
        /// <param name="westadoEnvio"></param>
        /// <param name="wfechaEntrega"></param>
        /// <param name="whoraEntrega"></param>
        /// <param name="wfechaModificacion"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ActualizarEnvio(int wenvioid, Int16 wentregadoTipo, Int16 westadoEnvio, string wfechaEntrega
                                                    , string whoraEntrega, string wfechaModificacion)
        {
            var objResultado = new object();
            int iResultado = -1;
            int iUsuarioID = UtlAuditoria.ObtenerIdUsuario();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/envio/APIActualizarEnvio?wsenvioid=" + wenvioid +
                                    "&wsentregadoTipo=" + wentregadoTipo + "&wsestadoEnvio=" + westadoEnvio + "&wsfechaEntrega=" + wfechaEntrega
                                   + "&wshoraEntrega=" + whoraEntrega + "&wsfechaModificacion=" + wfechaModificacion);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var lpoVC = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        iResultado = int.Parse(lpoVC);
                    }
                    else
                    {
                        iResultado = -3;
                    }
                }
                objResultado = new
                {
                    iResultado = 1,
                    sResultado = "Correcto"
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

        [HttpPost]
        public async Task<JsonResult> ListarEnvioUsuario(int idenvio)
        {
            var objResultado = new object();
            List<edEnvio> loenEnvio = new List<edEnvio>();
            var iusuarioID = UtlAuditoria.ObtenerIdUsuario();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage ReslistarEnvio = await client.GetAsync("api/envio/APIistarEnvioUsuario?wsusuarioid=" + iusuarioID + "&wsienvioid=" + idenvio);

                    if (ReslistarEnvio.IsSuccessStatusCode)
                    {
                        var rwsapienvio = ReslistarEnvio.Content.ReadAsAsync<string>().Result;
                        loenEnvio = JsonConvert.DeserializeObject<List<edEnvio>>(rwsapienvio);
                    }
                    else
                    {
                        loenEnvio = null;
                    }
                }

                objResultado = new
                {
                    rDatoE = loenEnvio,
                    iDatoCount = loenEnvio.Count,
                    ivalorUsuario = iusuarioID
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                    iDatoCount = 0
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

        [HttpPost]
        public async Task<JsonResult> ListarVentaUsuario(int widventaid)
        {
            var objResultado = new object();
            List<edVenta> loenVenta = new List<edVenta>();
            var iusuarioID = UtlAuditoria.ObtenerIdUsuario();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // envio
                    if (iusuarioID == 0)
                    {
                        loenVenta = null;
                    }
                    else
                    {
                        HttpResponseMessage ReslistarVenta = await client.GetAsync("api/envio/APIListarVentaUsuario?wsusuarioid=" + iusuarioID + "&wsventaid=" + widventaid);
                        if (ReslistarVenta.IsSuccessStatusCode)
                        {
                            var rwsapiventa = ReslistarVenta.Content.ReadAsAsync<string>().Result;
                            loenVenta = JsonConvert.DeserializeObject<List<edVenta>>(rwsapiventa);
                        }
                        else
                        {
                            loenVenta = null;
                        }
                    }

                }

                objResultado = new
                {
                    rDatoV = loenVenta,
                    iDatoCount = loenVenta.Count,
                    ivalorUsuario = iusuarioID
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                    iDatoCount = 0
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

        // no usado aun, ya se unio con la vista detalle
        [HttpPost]
        public async Task<JsonResult> ListarSubVentaUsuario(int wiventaid)
        {
            var objResultado = new object();
            List<edVenta> loenVenta = new List<edVenta>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/envio/APIListarSubVentaUsuario?wsventaid=" + wiventaid);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        loenVenta = JsonConvert.DeserializeObject<List<edVenta>>(rwsapilu);
                    }
                    else
                    {
                        loenVenta = null;
                    }
                }
                objResultado = new
                {
                    rDato = loenVenta,
                    iDatoCount = loenVenta.Count,

                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                    iDatoCount = 0
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

        public async Task<ActionResult> detalle(int wventaid = 0, int wenvioid = 0, string westado = "", string wfecha = "", string whora = "")
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

            if (sNombreSesion == "")
            {
                return RedirectToAction("pedido", "index");
            }

            if (wventaid == 0)
            {
                return RedirectToAction("pedido", "index");
            }

            var objResultado = new object();
            List<edVenta> loenVenta = new List<edVenta>();
            List<edVenta> loenSubVenta = new List<edVenta>();
            var iusuarioID = UtlAuditoria.ObtenerIdUsuario();
            var sVendedorNombre = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // envio

                if (iusuarioID == 0)
                {
                    loenSubVenta = null;
                    loenVenta = null;
                    sVendedorNombre = "-";
                }
                else
                {
                    HttpResponseMessage ReslistarVenta = await client.GetAsync("api/envio/APIListarVentaUsuario?wsusuarioid=" + iusuarioID + "&wsventaid=" + wventaid);
                    if (ReslistarVenta.IsSuccessStatusCode)
                    {
                        var rwsapiventa = ReslistarVenta.Content.ReadAsAsync<string>().Result;
                        loenVenta = JsonConvert.DeserializeObject<List<edVenta>>(rwsapiventa);
                        sVendedorNombre = loenVenta[0].svendedornombre;
                    }
                    else
                    {
                        loenVenta = null;
                    }

                    HttpResponseMessage ReslistarSubVenta = await client.GetAsync("api/envio/APIListarSubVentaUsuario?wsventaid=" + wventaid);
                    if (ReslistarSubVenta.IsSuccessStatusCode)
                    {
                        var rwsapisubventa = ReslistarSubVenta.Content.ReadAsAsync<string>().Result;
                        loenSubVenta = JsonConvert.DeserializeObject<List<edVenta>>(rwsapisubventa);
                    }
                    else
                    {
                        loenSubVenta = null;
                    }

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

            ViewBag.rDatoV = loenVenta;
            ViewBag.rDatoSV = loenSubVenta;
            ViewBag.ivalorUsuario = iusuarioID;

            ViewBag.GEnvioId = wenvioid;
            ViewBag.GVentaid = wventaid;
            ViewBag.GNombreVendedor = sVendedorNombre;
            ViewBag.GEstado = westado;
            ViewBag.GFecha = wfecha + whora;


            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ListarVentaVendedor(int widventaid)
        {
            var objResultado = new object();
            List<edVenta> loenVenta = new List<edVenta>();
            var iusuarioID = UtlAuditoria.ObtenerIdUsuario();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // envio
                    if (iusuarioID == 0)
                    {
                        loenVenta = null;
                    }
                    else
                    {
                        HttpResponseMessage ReslistarVenta = await client.GetAsync("api/envio/APIListarVentaVendedor?wsvendedorid=" + iusuarioID + "&wsventaid=" + widventaid);
                        if (ReslistarVenta.IsSuccessStatusCode)
                        {
                            var rwsapiventa = ReslistarVenta.Content.ReadAsAsync<string>().Result;
                            loenVenta = JsonConvert.DeserializeObject<List<edVenta>>(rwsapiventa);
                        }
                        else
                        {
                            loenVenta = null;
                        }
                    }

                }

                objResultado = new
                {
                    rDatoV = loenVenta,
                    iDatoCount = loenVenta.Count,
                    ivalorUsuario = iusuarioID
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                    iDatoCount = 0
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

    }
}