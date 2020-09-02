using frontendUtil;
using frontendED;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace EcommerceFrontEnd.Controllers
{
    public class landingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult nosotros()
        {
            return View();
        }

        //tipo de conexion 3 es parte de lead (personas que envian más información) NO SE UTILIZA
        [HttpPost]
        public async Task<JsonResult> contactarEmail(string wemail, string wnombre, string wcelular, string wmensaje)
        {
            var objResultado = new object();
            try
            {
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/usuario/APIRegistrarSesiones?wsidalumno=" + 1 + "&wsdireccionip=" + pdip + "&wsdireccionmac=" + pdmac + "&wstipoconexion=" + 3);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                    else
                    {
                        objResultado = new
                        {
                            iresultado = -5,
                            iresultadoins = "Error, por favor inténtelo en unos momentos."
                        };

                    }
                }

                //AQUI DEBE ENVIAR CORREO
                var fromAddress = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddress = new MailAddress(wemail, "Pizarra 21");
                var toAddress2 = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddressFranco = new MailAddress("franco.paolomp@gmail.com", "Franco");
                const string fromPassword = "@contacto";
                const string subject = "Bienvenido a Pizarra21 - Tu camino empieza ahora";
                string body = "<br /> ¡Hola! " + wnombre
                            + "<br /><br /> Somos Pizarra21, ¡Muchas gracias por registrarte con nosotros!"
                            + "<br /><br /> Para acceder a nuestros cursos, nosotros nos comunicaremos contigo, te enviaremos el método de pago y seguidamente una vez creada la cuenta, te daremos acceso a los cursos que has solicitado, así de facil. "
                            + "<br /> Siga nuestra página de Facebook y nuestra página de Instagram (compartimos un montón de consejos y trucos y lanzamos nuevos productos allí) encuéntranos como pizarra21 en Instagram y Pizarra21 en Facebook."
                            + "<br /><br /> Estamos en constante mejora de la plataforma es por ello que trabajamos arduamente para poder brindarte la mejor experiencia."
                            + "<br /><br /><br /> ¡Esperamos que sea de tu agrado!"
                            + "<br /><br /> Gracias"
                            + "<br /><br /> Pizarra 21";
                //ini datos listerup
                string subjectpizarra = "Nuevo registro de " + wnombre + " en pizarra21";
                string bodypizarra = "Nuevo registro de: " +
                            "<br /> (nombre: " + wnombre + " )." +
                            "<br /> (celular: " + wcelular + " )." +
                            "<br /> (correo: " + wemail + " )." +
                            "<br /> (mensaje: " + wmensaje + " ).";

                //fin datos listerup
                var smtp = new SmtpClient
                {
                    Host = "mail.pizarra21.com",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                //para el cliente
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                //pedido para el equipo pizarra21
                using (var message = new MailMessage(fromAddress, toAddress2)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                //pedido para el equipo franco
                using (var message = new MailMessage(fromAddress, toAddressFranco)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                objResultado = new
                {
                    iresultado = 1,
                    iresultadoins = "Correcto."
                };

            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstante.PizarraWEB, UtlConstante.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstante.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
            return Json(objResultado);
        }

        //tipo de conexion 4 es enviar nombre y celular NO SE UTILIZA
        [HttpPost]
        public async Task<JsonResult> ContactarNumero(string wnombre, string wcelular)
        {
            var objResultado = new object();
            try
            {
                string pdmac = UtlAuditoria.ObtenerDireccionMAC();
                string pdip = UtlAuditoria.ObtenerDireccionIP();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Resregsesion = await client.GetAsync("api/usuario/APIRegistrarSesiones?wsidalumno=" + 1 + "&wsdireccionip=" + pdip + "&wsdireccionmac=" + pdmac + "&wstipoconexion=" + 4);
                    if (Resregsesion.IsSuccessStatusCode)
                    {
                        var rwsrs = Resregsesion.Content.ReadAsAsync<string>().Result;
                    }
                    else
                    {
                        objResultado = new
                        {
                            iresultado = -5,
                            iresultadoins = "Error, por favor inténtelo en unos momentos."
                        };

                    }
                }

                //AQUI DEBE ENVIAR CORREO
                var fromAddress = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddress2 = new MailAddress("contacto@pizarra21.com", "Pizarra21");
                var toAddressFranco = new MailAddress("franco.paolomp@gmail.com", "Franco");
                const string fromPassword = "@contacto";
                //ini datos listerup
                string subjectpizarra = "Información de " + wnombre + " en pizarra21";
                string bodypizarra = wnombre + " ha solicitado más información con los siguientes datos: " +
                            "<br /> (nombre: " + wnombre + " )." +
                            "<br /> (celular: " + wcelular + " ).";

                //fin datos listerup
                var smtp = new SmtpClient
                {
                    Host = "mail.pizarra21.com",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };
                //pedido para el equipo pizarra21
                using (var message = new MailMessage(fromAddress, toAddress2)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                //pedido para el equipo franco
                using (var message = new MailMessage(fromAddress, toAddressFranco)
                {
                    Subject = subjectpizarra,
                    Body = bodypizarra,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                objResultado = new
                {
                    iresultado = 1,
                    iresultadoins = "Correcto."
                };

            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstante.PizarraWEB, UtlConstante.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstante.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<JsonResult> enviarCompra(string wchk, string wotro, string wnombre, int widepartamento, string wcorreo)
        {
            try
            {
                var objResultado = new object();

                int iresultadoCorreo = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsvc = await client.GetAsync("api/envio/APIEnviarCompra?wchk=" + wchk + "&wotro=" + wotro
                        + "&wnombre=" + wnombre + "&widepartamento=" + widepartamento + "&wcorreo=" + wcorreo);

                    if (Reswsvc.IsSuccessStatusCode)
                    {
                        var lpoVC = Reswsvc.Content.ReadAsAsync<string>().Result;
                        iresultadoCorreo = int.Parse(lpoVC);
                        if (iresultadoCorreo == 1)
                        {
                            objResultado = new
                            {
                                iResultado = 1,
                                iResultadoIns = "correcto"
                            };
                            return Json(objResultado);
                        }

                        if (iresultadoCorreo == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "error"
                            };
                            return Json(objResultado);
                        }
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "correcto"
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
        public async Task<JsonResult> enviarVenta(string wtienda, string wcontacto, string wcelular, int witiponegocio, string wruc,
                                                string wdireccion, int widepartamento, string wcorreoventa)
        {
            try
            {
                var objResultado = new object();

                int iresultadoCorreo = -1;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Reswsvc = await client.GetAsync("api/envio/APIRegistrarVenta?wtienda=" + wtienda + "&wcontacto=" + wcontacto
                                                   + "&wcelular=" + wcelular + "&witiponegocio=" + witiponegocio + "&wruc=" + wruc
                                                   + "&wdireccion=" + wdireccion + "&widepartamento=" + widepartamento + "&wcorreoventa="
                                                   + wcorreoventa);

                    if (Reswsvc.IsSuccessStatusCode)
                    {
                        var lpoVC = Reswsvc.Content.ReadAsAsync<string>().Result;
                        iresultadoCorreo = int.Parse(lpoVC);
                        if (iresultadoCorreo == 1)
                        {
                            objResultado = new
                            {
                                iResultado = 1,
                                iResultadoIns = "correcto"
                            };
                            return Json(objResultado);
                        }

                        if (iresultadoCorreo == -1)
                        {
                            objResultado = new
                            {
                                iResultado = -5,
                                iResultadoIns = "error"
                            };
                            return Json(objResultado);
                        }
                    }
                }

                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "correcto"
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
        public async Task<ActionResult> ListarCompra(int iNumeroPagina, int iTotalPagina)
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            List<edLanding> loenCompra = new List<edLanding>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/envio/APIListarCompra?valor=0");
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenCompra = JsonConvert.DeserializeObject<List<edLanding>>(rwsapilu);
                }
                else
                {
                    loenCompra = null;
                }
            }
            objResultado = new
            {
                PageStart = 1,
                pageSize = 100,
                SearchText = string.Empty,
                ShowChildren = true,
                iTotalRecords = loenCompra.Count,
                iTotalDisplayRecords = 1,
                aaData = loenCompra
            };
            return Json(objResultado);
        }

        [HttpPost]
        public async Task<ActionResult> ListarVenta(int iNumeroPagina, int iTotalPagina)
        {
            int GIdusuario = UtlAuditoria.ObtenerIdUsuario();
            var objResultado = new object();
            List<edLanding> loenVenta = new List<edLanding>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(MvcApplication.wsRoutepizarra);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reslistarusu = await client.GetAsync("api/envio/APIListarVenta?valor=0");
                if (Reslistarusu.IsSuccessStatusCode)
                {
                    var rwsapilu = Reslistarusu.Content.ReadAsAsync<string>().Result;
                    loenVenta = JsonConvert.DeserializeObject<List<edLanding>>(rwsapilu);
                }
                else
                {
                    loenVenta = null;
                }
            }
            objResultado = new
            {
                PageStart = 1,
                pageSize = 100,
                SearchText = string.Empty,
                ShowChildren = true,
                iTotalRecords = loenVenta.Count,
                iTotalDisplayRecords = 1,
                aaData = loenVenta
            };
            return Json(objResultado);
        }

        public ActionResult resmuo()
        {
            return View();
        }

        public ActionResult error()
        {
            return View();
        }

    }
}