using frontendUtil;
using frontendED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using EcommerceFrontEnd.Filters;

namespace EcommerceFrontEnd.Controllers
{
    public class productoController : Controller
    {

        [SecuritySession]
        public async Task<ActionResult> listado()
        {
            // valida si la sesion esta activa para mostrar el menu
            ViewBag.iValorCuenta = 1;

            var iVendedorID = UtlAuditoria.ObtenerIdUsuario();
            var sNombreSesion = UtlAuditoria.ObtenerNombre();
            ViewBag.sNombre = "Hola " + sNombreSesion;
            ViewBag.sTextoMenu = "Mi cuenta";
            ViewBag.RouteSales = "principal";

            List<edConfiguracion> loenConfiguracion = new List<edConfiguracion>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage ReslistarAdicional = await client.GetAsync("api/configuracion/APIListarConfiguracion?wsvendedorid=" + iVendedorID);
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

            ViewBag.lstConfiguracion = loenConfiguracion;
            return View();
        }

        //CRUD PARA VENDEDOR

        [HttpPost]
        public async Task<ActionResult> RegistrarProducto(IEnumerable<HttpPostedFileBase> FRutaImagenes, string txNombreA, Int16 slcCategoriaA
                                                        , string txDescripcionA, decimal txPrecioA, string wfechareg, string[] svalorchk)
        {
            string fechaActual = DateTime.Now.ToString("yyyyMMddHHmmss");
            var iVendedorID = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            // resultado de registro producto
            int iResultado = -1;
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var releaseUris = new List<string>();
            var lstbase64 = new List<string>();
            var valorchk = svalorchk;
            try
            {
                foreach (var file in FRutaImagenes)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string sTipoImagen = System.IO.Path.GetFileName(file.ContentType);
                        string sRandom = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());
                        string sRutaLocal = System.IO.Path.Combine(Server.MapPath("~/Images/"), sRandom + "." + sTipoImagen);

                        string sRutaServidor = "~/Images/" + sRandom + "." + sTipoImagen;
                        // sRuta es para la bd                        
                        file.SaveAs(sRutaLocal);
                        releaseUris.Add(sRutaServidor);

                    }
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/producto/APIRegistrarProducto?wsvendedorid=" + iVendedorID +
                        "&wscategoria_type=" + slcCategoriaA + "&wsnombre=" + txNombreA + "&wsdescripcion=" + txDescripcionA + "&wsprecio=" + txPrecioA +
                                     "&wsimagen1=" + releaseUris[0] + "&wsimagen2=" + releaseUris[1] + "&wsimagen3=" + releaseUris[2] + "&wsimagen4=" + "vacio" +
                                     "&wsimagen5=" + "vacio" + "&wsfechareg=" + wfechareg);
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

                foreach (string itemchk in svalorchk)
                {
                    int svalorConfiguracion = int.Parse(itemchk);

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        HttpResponseMessage ResregEspecificacion = await client.GetAsync("api/configuracion/APIRegistrarEspecificacion?wsconfiguracionid=" + svalorConfiguracion
                           + "&wsproductoid=" + iResultado + "&wsfecharegistro=" + wfechareg);
                        if (ResregEspecificacion.IsSuccessStatusCode)
                        {
                            var lpoRE = ResregEspecificacion.Content.ReadAsAsync<string>().Result;
                        }
                    }

                }

                //base64
                /*using (Image image = Image.FromFile(Path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }*/


                objResultado = new
                {
                    iResultado = iResultado,
                    sResultado = "Correcto"
                };
                return RedirectToAction("listado", "producto");
            }
            catch (Exception ex)
            {
                objResultado = new
                {
                    rDato = ex,
                };
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return RedirectToAction("listado", "producto");
            }
        }

        [HttpPost]
        public async Task<JsonResult> ActualizarProducto(int wproducto_id, string wmarca, Int16 wcategoria, string wnombre, string wdescripcion
                                                        , string wmaterial, decimal wprecio, string wmodelo, string wmedida, string wimagen1
                                                        , string wimagen2, string wimagen3, string wimagen4, string wimagen5, decimal wpeso
                                                        , string wfechamod, Int16 wmodificado)
        {
            var objResultado = new object();
            int iResultado = -1;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/producto/APIActualizarProducto?wsproducto_id=" + wproducto_id
                                     + "&wscategoria=" + wcategoria + "&wsnombre=" + wnombre + "&wsdescripcion=" + wdescripcion
                                     + "&wsmaterial=" + wmaterial + "&wsmarca=" + wmarca + "&wspeso=" + wpeso + "&wsmodelo=" + wmodelo
                                     + "&wsmedida=" + wmedida + "&wsprecio=" + wprecio + "&wsimagen1=" + wimagen1
                                     + "&wsimagen2=" + wimagen2 + "&wsimagen3=" + wimagen3 + "&wsimagen4=" + wimagen4 + "&wsimagen5=" + wimagen5
                                     + "&wsfechamod=" + wfechamod + "&wsmodificado=" + wmodificado);
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
        public async Task<JsonResult> EliminarProducto(int wproductoid)
        {
            var objResultado = new object();
            int iResultado = -1;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/producto/APIEliminarProducto?wsproductoid=" + wproductoid);
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
        public async Task<JsonResult> ListarProductoVendedor(string wnombre, int iNumeroPagina, int iTotalPagina)
        {
            var objResultado = new object();
            List<edProducto> loenProducto = new List<edProducto>();
            int iVendedorId = UtlAuditoria.ObtenerIdUsuario();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/producto/APIListarProductoVendedor?wsnombre=" + wnombre +
                        "&wsNumeroPagina=" + iNumeroPagina + "&wsCantidadMostrar=" + iTotalPagina + "&wsidvendedor=" + iVendedorId);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        loenProducto = JsonConvert.DeserializeObject<List<edProducto>>(rwsapilu);
                    }
                    else
                    {
                        loenProducto = null;
                    }
                }
                int iTotalRegistros = 0;
                if (loenProducto.Count != 0)
                {
                    iTotalRegistros = loenProducto.Count;
                }
                objResultado = new
                {
                    PageStart = iNumeroPagina,
                    pageSize = iNumeroPagina,
                    SearchText = string.Empty,
                    ShowChildren = UtlConstante.bValorTrue,
                    iTotalRecords = loenProducto.Count,
                    iTotalDisplayRecords = iTotalRegistros,
                    aaData = loenProducto
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
        public async Task<JsonResult> EditarProductoVendedor(int wcategoriaid)
        {
            var objResultado = new object();
            edProducto oenProducto = new edProducto();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/producto/APIEditarProductoVendedor?wsproductoidEditar=" + wcategoriaid);
                    if (Reslistarusu.IsSuccessStatusCode)
                    {
                        var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                        oenProducto = JsonConvert.DeserializeObject<edProducto>(rwsapilu);
                    }
                    else
                    {
                        oenProducto = null;
                    }
                }
                objResultado = new
                {
                    raData = oenProducto
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
        public async Task<JsonResult> EditarEspecificacion(int wproductoid)
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

        [HttpPost]
        public async Task<JsonResult> EliminarEspecificacion(int wespecificacionid, int wconfiguracionid,
                                                            int wproductoid, string wfechareg, int wtipofiltro)
        {
            var objResultado = new object();
            int iResultado = -1;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/configuracion/APIEliminarEspecificacion?wseespecificacionid=" + wespecificacionid
                                     + "&wseconfiguracionid=" + wconfiguracionid + "&wseproductoid=" + wproductoid + "&wsefechareg=" + wfechareg
                                     + "&wsetipofiltro=" + wtipofiltro);
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
        public async Task<JsonResult> ActivarPromocionProducto(int wproductoid, decimal wprecio, Int16 wtipopromocion
                                                            , decimal wpreciopromocion, string wfechainipromocion, string wfechafinpromocion)
        {
            var objResultado = new object();
            int iResultado = -1;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reslistarusu = await client.GetAsync("api/producto/APIActivarPromocionProducto?wsproductoid=" + wproductoid
                                                                    + "&wsprecio=" + wprecio + "&wstipopromocion=" + wtipopromocion
                                                                    + "&wspreciopromocion=" + wpreciopromocion + "&wsfechainipromocion=" + wfechainipromocion
                                                                    + "&wsfechafinpromocion=" + wfechafinpromocion);
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


    }
}