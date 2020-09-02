using frontendED;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using frontendUtil;
using System.Web;
using EcommerceFrontEnd.Filters;

namespace EcommerceFrontEnd.Controllers
{
    public class configuracionController : Controller
    {
        [SecuritySessionSales]
        public ActionResult configuracion()
        {
            // valida si la sesion esta activa para mostrar el menu
            ViewBag.iValorCuenta = 1;

            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            ViewBag.sNombre = "Hola " + sNombreSesion;
            ViewBag.sTextoMenu = "Mi cuenta";
            ViewBag.RouteSales = "principal";

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ListarConfiguracion(int iNumeroPagina, int iTotalPagina)
        {
            try
            {
                var objResultado = new object();
                int IVendedorID = UtlAuditoria.ObtenerIdUsuario();
                List<edConfiguracion> loenConfiguracion = new List<edConfiguracion>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage ReslistarAdicional = await client.GetAsync("api/configuracion/APIListarConfiguracion?wsvendedorid=" + IVendedorID);
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
                    PageStart = 1,
                    pageSize = 100,
                    SearchText = string.Empty,
                    ShowChildren = UtlConstante.bValorTrue,
                    iTotalRecords = loenConfiguracion.Count,
                    iTotalDisplayRecords = 1,
                    aaData = loenConfiguracion
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
        public async Task<JsonResult> RegistrarConfiguracion(string wnombre, string wdescripcion, string wvalor, int itipoadicional
                                                        , string wfecharegistro)
        {
            try
            {
                var objResultado = new object();
                int IVendedorID = UtlAuditoria.ObtenerIdUsuario();

                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/configuracion/APIRegistrarConfiguracion?wsvendedorid=" + IVendedorID
                                                        + "&wsnombre=" + wnombre + "&wsdescripcion=" + wdescripcion + "&wsvalor=" + wvalor
                                                        + "&wsadicionaltipo=" + itipoadicional + "&wsfecharegistro=" + wfecharegistro);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnCategoriaReg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnCategoriaReg);

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

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "registrado"
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
        public async Task<JsonResult> ActualizarConfiguracion(int wconfiguracionid, string wnombre, string wdescripcion, string wvalor
                                                        , int itipoconfiguracion, string wfechamodificacion)
        {
            try
            {
                var objResultado = new object();

                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/configuracion/APIActualizarConfiguracion?wsaconfiguracionid=" + wconfiguracionid
                                                        + "&wsanombre=" + wnombre + "&wsadescripcion=" + wdescripcion + "&wsavalor=" + wvalor
                                                        + "&wsaadicionaltipo=" + itipoconfiguracion + "&wsafechamodificacion=" + wfechamodificacion);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnCategoriaReg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnCategoriaReg);

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

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "registrado"
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
        public async Task<JsonResult> EliminarConfiguracion(int wconfiguracionid)
        {
            try
            {
                var objResultado = new object();

                int iresultadoreg = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsru = await client.GetAsync("api/configuracion/APIEliminarConfiguracion?wseconfiguracionid=" + wconfiguracionid);
                    if (Reswsru.IsSuccessStatusCode)
                    {
                        var lpoEnCategoriaReg = Reswsru.Content.ReadAsAsync<string>().Result;
                        iresultadoreg = int.Parse(lpoEnCategoriaReg);

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

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "registrado"
                };

                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}