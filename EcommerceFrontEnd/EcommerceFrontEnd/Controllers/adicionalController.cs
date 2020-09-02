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
    public class adicionalController : Controller
    {
        [SecuritySessionSales]
        public ActionResult adicional()
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
        public async Task<JsonResult> ListarAdicional(int iNumeroPagina, int iTotalPagina)
        {
            try
            {
                var objResultado = new object();
                int IVendedorID = UtlAuditoria.ObtenerIdUsuario();
                List<edAdicional> loenAdicional = new List<edAdicional>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage ReslistarAdicional = await client.GetAsync("api/adicional/APIListarAdicional?wsvendedorid=" + IVendedorID);
                    if (ReslistarAdicional.IsSuccessStatusCode)
                    {
                        var rwsapilu = ReslistarAdicional.Content.ReadAsAsync<string>().Result;
                        loenAdicional = JsonConvert.DeserializeObject<List<edAdicional>>(rwsapilu);
                    }
                    else
                    {
                        loenAdicional[0].adicionalid = -1;
                    }
                }

                objResultado = new
                {
                    PageStart = 1,
                    pageSize = 100,
                    SearchText = string.Empty,
                    ShowChildren = UtlConstante.bValorTrue,
                    iTotalRecords = loenAdicional.Count,
                    iTotalDisplayRecords = 1,
                    aaData = loenAdicional
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
        public async Task<JsonResult> RegistrarAdicional(string wnombre, string wdescripcion, decimal wprecio, int itipoadicional
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
                    HttpResponseMessage Reswsru = await client.GetAsync("api/adicional/APIRegistrarAdicional?wsvendedorid=" + IVendedorID
                                                        + "&wsnombre=" + wnombre + "&wsdescripcion=" + wdescripcion + "&wsprecio=" + wprecio
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
        public async Task<JsonResult> ActualizarAdicional(int wadicionalid, string wnombre, string wdescripcion, decimal wprecio
                                                        , int itipoadicional, string wfechamodificacion)
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
                    HttpResponseMessage Reswsru = await client.GetAsync("api/adicional/APIActualizarAdicional?wsiadicionalid=" + wadicionalid
                                                        + "&wsinombre=" + wnombre + "&wsidescripcion=" + wdescripcion + "&wsiprecio=" + wprecio
                                                        + "&wsiadicionaltipo=" + itipoadicional + "&wsifechamodificacion=" + wfechamodificacion);
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
        public async Task<JsonResult> EliminarAdicional(int wadicionalid)
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
                    HttpResponseMessage Reswsru = await client.GetAsync("api/adicional/APIEliminarAdicional?wseadicionalid=" + wadicionalid);
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