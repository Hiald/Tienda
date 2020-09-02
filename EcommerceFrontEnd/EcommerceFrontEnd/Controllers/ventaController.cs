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
    public class ventaController : Controller
    {

        public async Task<ActionResult> pago()
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
                ViewBag.BValorCuenta = 1;
            }
            else
            {
                ViewBag.BValorCuenta = 0;
            }

            ViewBag.lstCategoria = loenCategoria;

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> RegistrarVenta(int wivendedorId, decimal wdmonto, decimal wdigv, decimal wdtotal, int witipoventa, int witipopago
                                        , string wsdescripcion, decimal wdcomision, string wsobservacion, string wsfecharegistro, string wloenSubventa
                                        , string wdireccion, string wsnumero, int wiestadoprovincia, int wiciudad, string wspiso)
        {
            var objResultado = new object();
            int iResultado = -1;
            int iResultadoEnvio = -1;
            int iUsuarioID = UtlAuditoria.ObtenerIdUsuario();
            try
            {
                edVenta oenRegVenta = new edVenta();
                oenRegVenta.vendedorid = wivendedorId;
                oenRegVenta.usuarioid = iUsuarioID;
                oenRegVenta.dmonto = wdmonto;
                oenRegVenta.digv = wdigv;
                oenRegVenta.dtotal = wdtotal;
                oenRegVenta.itipoventa = witipoventa;
                oenRegVenta.itipopago = witipopago;
                oenRegVenta.spagodescripcion = wsdescripcion;
                oenRegVenta.dcomision = wdcomision;
                oenRegVenta.sobservacion = wsobservacion;
                oenRegVenta.sfecha_registro = wsfecharegistro;
                string scontentVenta = JsonConvert.SerializeObject(oenRegVenta);
                string sfechaentrega = "";
                string shoraentrega = "";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/venta/APIRegistrarVenta?wsoenVenta=" + scontentVenta + "&wsoenSubVenta=" + wloenSubventa);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var lpoVC = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        iResultado = int.Parse(lpoVC);
                    }
                    else
                    {
                        iResultado = -3;
                    }

                    HttpResponseMessage ResRegistroEnvio = await client.GetAsync("api/envio/APIRegistrarEnvio?wsusuarioid=" + iUsuarioID +
                          "&wsventaid=" + iResultado + "&wsvendedorid=" + wivendedorId + "&wsnombre=" + wsdescripcion + "&wsnumero=" + wsnumero
                        + "&wsdireccion=" + wdireccion + "&wspisodescripcion=" + wspiso + "&wsipais=" + 0 + "&wsidistrito=" + wiestadoprovincia
                        + "&wsestadoProvincia=" + wiestadoprovincia + "&wssestadoprovincia=" + "" + "&wsciudad=" + wiciudad + "&wssciudad=" + ""
                        + "&wsscodigopostal=" + "" + "&wsentregadoTipo=" + 0 + "&wsestadoEnvio=" + 1
                        + "&wsfechaEntrega=" + sfechaentrega + "&wshoraEntrega=" + shoraentrega + "&wsfechaRegistro=" + wsfecharegistro);

                    if (ResRegistroEnvio.IsSuccessStatusCode)
                    {
                        var lpoVC = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        iResultadoEnvio = int.Parse(lpoVC);
                    }
                    else
                    {
                        iResultadoEnvio = -3;
                    }
                }
                objResultado = new
                {
                    iResultadoReg = iResultado,
                    sResultado = "Correcto"
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    iResultadoReg = 0,
                    rDato = ex,
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }
        }

        // VENDEDOR

        /// <summary>
        /// retorna json con un listado de ventas del vendedor
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ListarVentaVendedor()
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

                    // venta
                    if (iusuarioID == 0)
                    {
                        loenVenta = null;
                    }
                    else
                    {
                        HttpResponseMessage ReslistarVenta = await client.GetAsync("api/venta/APIListarVentaVendedor?wsvendedorid=" + iusuarioID);
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

        [HttpPost]
        public async Task<JsonResult> NotificarVenta()
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

                    // venta
                    if (iusuarioID == 0)
                    {
                        loenVenta = null;
                    }
                    else
                    {
                        HttpResponseMessage ReslistarVenta = await client.GetAsync("api/venta/APINotificarVenta?wsnotvendedorid=" + iusuarioID);
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