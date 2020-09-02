using frontendED;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using frontendUtil;
using EcommerceFrontEnd.Filters;

namespace EcommerceFrontEnd.Controllers
{
    public class vendedorController : Controller
    {

        [Route("vendedor")]
        public ActionResult Index()
        {
            // valida si la sesion esta activa para mostrar el menu
            ViewBag.iValorCuenta = 0;

            ViewBag.sNombre = "";
            ViewBag.sTextoMenu = "";
            ViewBag.RouteSales = "index";
            return View();
        }

        [SecuritySessionSales]
        public ActionResult principal()
        {
            // valida si la sesion esta activa para mostrar el menu
            ViewBag.iValorCuenta = 1;

            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            ViewBag.sNombre = "Hola " + sNombreSesion;
            ViewBag.sTextoMenu = "Mi cuenta";
            ViewBag.RouteSales = "principal";
            return View();
        }

        [SecuritySessionSales]
        public ActionResult lectorpedido(int ppdwvi, int ppdwei)
        {
            // valida si la sesion esta activa para mostrar el menu
            ViewBag.iValorCuenta = 1;

            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            ViewBag.sNombre = "Hola " + sNombreSesion;
            ViewBag.sTextoMenu = "Mi cuenta";
            ViewBag.RouteSales = "principal";
            ViewBag.pidventa = ppdwvi;
            ViewBag.pidenvio = ppdwei;
            return View();
        }

        [SecuritySessionSales]
        public ActionResult reporte()
        {
            // valida si la sesion esta activa para mostrar el menu
            ViewBag.iValorCuenta = 1;

            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            ViewBag.sNombre = "Hola " + sNombreSesion;
            ViewBag.sTextoMenu = "Mi cuenta";
            ViewBag.RouteSales = "principal";
            return View();
        }

        //TIPO CONEXION 1: registro, 2: inicio sesion, 3:cierre sesion

        [HttpPost]
        public async Task<JsonResult> registrarVendedor(string wnombre, string wapellido, string wcelular, string wcorreo, string wclave)
        {
            try
            {
                var objResultado = new object();

                int iresultadoCuenta = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsvc = await client.GetAsync("api/vendedor/APIValidarCorreo?wscorreo=" + wcorreo);

                    if (Reswsvc.IsSuccessStatusCode)
                    {
                        var lpoVC = Reswsvc.Content.ReadAsAsync<string>().Result;
                        iresultadoCuenta = int.Parse(lpoVC);
                        if (iresultadoCuenta == 1)
                        {
                            objResultado = new
                            {
                                iResultado = -2,
                                iResultadoIns = "El correo ya está tomado, intenta con otro"
                            };
                            return Json(objResultado);
                        }

                        if (iresultadoCuenta == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                            return Json(objResultado);
                        }
                    }
                }

                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/vendedor/APIRegistrarVendedor?wsnombre=" + wnombre
                        + "&wsapellido=" + wapellido + "&wscelular=" + wcelular + "&wscorreo=" + wcorreo + "&wsclave=" + wclave);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnUsuarioreg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnUsuarioreg);

                        if (iresultadoreg == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "Ha ocurrido un error, inténtelo nuevamente"
                            };
                        }
                    }
                }

                edUsuario oEnUsuario = new edUsuario();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/vendedor/APIListarVendedor?wsvendedorid=" + iresultadoreg);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        oEnUsuario = JsonConvert.DeserializeObject<edUsuario>(rwsapilu);
                    }
                    else
                    {
                        oEnUsuario.iRespuesta = -1;
                    }
                }

                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["USUARIOID"] = oEnUsuario.vendedorid.ToString();
                DVariables["NOMBRE"] = oEnUsuario.snombre;
                DVariables["APELLIDO"] = oEnUsuario.sapellido;
                DVariables["SESSION_SFECHAREGISTRO"] = oEnUsuario.sfecha_registro;
                DVariables["ACTIVO"] = oEnUsuario.iactivo.ToString();
                DVariables["NOMBRECOMPLETO"] = oEnUsuario.snombrelargo.ToString();
                DVariables["CORREO"] = oEnUsuario.scorreo.ToString();
                UtlAuditoria.SetSessionValues(DVariables);

                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/vendedor/APIRegistrarSesionVendedor?wsvendedorid="
                        + oEnUsuario.vendedorid + "&wsdireccionip=" + pdip + "&wsdireccionmac=" + pdmac + "&wstipoconexion=" + 1);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }

                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "vendedor/main"
                };

                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        [HttpPost]
        public async Task<JsonResult> loginVendedor(string wcorreo, string wclave)
        {
            try
            {
                var objResultado = new object();

                int irespuesta = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslogueo = await client.GetAsync("api/vendedor/APIAccesoVendedor?wscorreo=" + wcorreo + "&wsclave=" + wclave);

                    if (Reslogueo.IsSuccessStatusCode)
                    {
                        var rwsapi = Reslogueo.Content.ReadAsAsync<string>().Result;
                        irespuesta = int.Parse(rwsapi);

                        if (irespuesta == -1 || irespuesta == 0)
                        {
                            //si la clave no es igual al correo
                            objResultado = new
                            {
                                iResultado = -3,
                                iResultadoIns = "El usuario o clave son incorrectos"
                            };
                            return Json(objResultado);
                        }

                    }
                }

                edUsuario oEnUsuario = new edUsuario();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/vendedor/APIListarVendedor?wsvendedorid=" + irespuesta);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        oEnUsuario = JsonConvert.DeserializeObject<edUsuario>(rwsapilu);
                    }
                    else
                    {
                        oEnUsuario.iRespuesta = -1;
                    }
                }

                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["USUARIOID"] = oEnUsuario.vendedorid.ToString();
                DVariables["NOMBRE"] = oEnUsuario.snombre;
                DVariables["APELLIDO"] = oEnUsuario.sapellido;
                DVariables["SESSION_SFECHAREGISTRO"] = oEnUsuario.sfecha_registro;
                DVariables["ACTIVO"] = oEnUsuario.iactivo.ToString();
                DVariables["NOMBRECOMPLETO"] = oEnUsuario.snombrelargo.ToString();
                DVariables["CORREO"] = oEnUsuario.scorreo.ToString();
                UtlAuditoria.SetSessionValues(DVariables);

                string pdip = UtlAuditoria.ObtenerDireccionIP();
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Resregsesion = await client.GetAsync("api/vendedor/APIRegistrarSesionVendedor?wsvendedorid="
                        + oEnUsuario.vendedorid + "&wsdireccionip=" + pdip + "&wsdireccionmac=" + pdmac + "&wstipoconexion=" + 2);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "vendedor/main"
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [HttpPost]
        public async Task<JsonResult> cerrarSesion()
        {
            var objResultado = new object();
            try
            {
                int idVendedor = UtlAuditoria.ObtenerIdUsuario();
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/vendedor/APIRegistrarSesionVendedor?wsvendedorid=" + idVendedor
                        + "&wsdireccionip=" + pdip + "&wsdireccionmac=" + pdmac + "&wstipoconexion=" + 3);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                }

                bool bResultado = UtlAuditoria.CerrarSession();
                if (bResultado)
                {
                    objResultado = new
                    {
                        iResultado = 1
                    };
                }
                else
                {
                    objResultado = new
                    {
                        iResultado = 2
                    };
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<JsonResult> ListarReporteVenta(int wventatipo)
        {
            try
            {
                var objResultado = new object();
                int iUsuario = UtlAuditoria.ObtenerIdUsuario();
                List<edReporte> loenReporte = new List<edReporte>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/reporte/APIReporteListarVenta?wsvendedorid=" + iUsuario
                                                                            + "&wsventatipo=" + wventatipo);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        loenReporte = JsonConvert.DeserializeObject<List<edReporte>>(rwsapilu);
                    }
                }

                objResultado = new
                {
                    rDato = loenReporte
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [HttpPost]
        public async Task<JsonResult> ListarReporteEnvio(int westadoenvio)
        {
            try
            {
                var objResultado = new object();
                int iUsuario = UtlAuditoria.ObtenerIdUsuario();
                List<edReporte> loenReporte = new List<edReporte>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/reporte/APIReporteListarEnvio?wsvendedorid=" + iUsuario
                                                                            + "&wsiestadoenviotipo=" + westadoenvio);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        loenReporte = JsonConvert.DeserializeObject<List<edReporte>>(rwsapilu);
                    }
                }

                objResultado = new
                {
                    rDato = loenReporte.Count
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

    }
}