using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registroVisitantes.Modelos;
using registroVisitantes.Clases;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registroVisitantes.Controllers
{
    [Route("api/rVisitas")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class rVisitasController : ControllerBase
    {
        public rVisitasPricipal rVP;


        public rVisitasController(rVisitasContext context)
        {

        }

        // GET: api/rVisitas
        [HttpGet]
        public JsonResult GetUrls()
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaVistas();
            return new JsonResult(rVP.ListaVisitas);
        }

        // GET: api/rVisitas/visitas
        [HttpGet("visitas")]
        public JsonResult GetVisitas()
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaVistas();
            return new JsonResult(rVP.ListaVisitas);
        }

        // POST: api/rVisitas/areas
        [HttpPost("areas")]
        public JsonResult GetVisitaAreas([FromBody] JObject areas)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string area1 = areas.GetValue("area1").ToString();
                string area2 = areas.GetValue("area2").ToString();
                rVP.ConsultaVistasAreas(area1, area2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaVisitas);

        }

        // POST: api/rVisitas/direcciones
        [HttpPost("direcciones")]
        public JsonResult GetVisitaDirecciones([FromBody] JObject direcciones)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string dir1 = direcciones.GetValue("direccion1").ToString();
                string dir2 = direcciones.GetValue("direccion2").ToString();
                rVP.ConsultaVistasDirecciones(dir1, dir2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaVisitas);
        }

        // POST: api/rVisitas/empleados
        [HttpPost("empleados")]
        public JsonResult GetVisitaEmpleados([FromBody] JObject empleado)
        {
            try
            {
                int EmpNumero = 0;
                rVP = new rVisitasPricipal();
                string EmpNombre = empleado.GetValue("nombre").ToString();
                if (!string.IsNullOrEmpty(empleado.GetValue("numero").ToString()))
                {
                    EmpNumero = int.Parse(empleado.GetValue("numero").ToString());
                }
                rVP.ConsultaVistasEmpleados(EmpNombre, EmpNumero);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaVisitas);
        }

        // POST: api/rVisitas/fechas
        [HttpPost("fechas")]
        public JsonResult GetVisitaFecha([FromBody] JObject fechas)
        {
            try
            {
                DateTime FechaIni = DateTime.Parse("2008-11-11");
                DateTime FechaEnd = DateTime.Parse("2008-11-11");
                rVP = new rVisitasPricipal();
                if (!string.IsNullOrEmpty(fechas.GetValue("fechaIni").ToString()))
                {
                    FechaIni = DateTime.Parse(fechas.GetValue("fechaIni").ToString());
                }
                if (!string.IsNullOrEmpty(fechas.GetValue("fechaEnd").ToString()))
                {
                    FechaEnd = DateTime.Parse(fechas.GetValue("fechaEnd").ToString());
                }
                rVP.ConsultaVistasFechas(FechaIni, FechaEnd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaVisitas);
        }

        // POST: api/rVisitas/NoVisitantes
        [HttpPost("NoVisitantes")]
        public JsonResult GetNoVisitantes([FromBody] JObject fechas)
        {
            try
            {
                DateTime FechaIni = DateTime.Parse("2008-11-11");
                DateTime FechaEnd = DateTime.Parse("2008-11-11");
                rVP = new rVisitasPricipal();
                if (!string.IsNullOrEmpty(fechas.GetValue("fechaIni").ToString()))
                {
                    FechaIni = DateTime.Parse(fechas.GetValue("fechaIni").ToString());
                }
                if (!string.IsNullOrEmpty(fechas.GetValue("fechaEnd").ToString()))
                {
                    FechaEnd = DateTime.Parse(fechas.GetValue("fechaEnd").ToString());
                }
                rVP.ConsultaNoVisitantes(FechaIni, FechaEnd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // GET: api/rVisitas/NoVisitantesActivos
        [HttpGet("NoVisitantesActivos")]
        public JsonResult GetNoVisitantesActivos()
        {
            try
            {
                rVP = new rVisitasPricipal();
                rVP.ConsultaNoVisitantesActivos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesD
        [HttpPost("NoVisitantesD")]
        public JsonResult GetNoVisitantesDireccion([FromBody] JObject direcciones)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string d1 = direcciones.GetValue("direccion1").ToString();
                string d2 = direcciones.GetValue("direccion2").ToString();
                rVP.ConsultaNoVisitantesDireccion(d1, d2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesDMes
        [HttpPost("NoVisitantesDMes")]
        public JsonResult GetNoVisitantesDireccionMes([FromBody] JObject direcciones)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string d1 = direcciones.GetValue("direccion1").ToString();
                string d2 = direcciones.GetValue("direccion2").ToString();
                int mes = int.Parse(direcciones.GetValue("mes").ToString());
                rVP.ConsultaNoVisitantesDireccionMes(d1, d2, mes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesDMesAnio
        [HttpPost("NoVisitantesDMesAnio")]
        public JsonResult PostNoVisitantesDireccionMesAnio([FromBody] JObject direcciones)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string d1 = direcciones.GetValue("direccion1").ToString();
                string d2 = direcciones.GetValue("direccion2").ToString();
                int mes = int.Parse(direcciones.GetValue("mes").ToString());
                int anio = int.Parse(direcciones.GetValue("anio").ToString());
                rVP.ConsultaNoVisitantesDireccionMesAnio(d1, d2, mes, anio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesDFechas
        [HttpPost("NoVisitantesDFechas")]
        public JsonResult GetNoVisitantesDireccionFechas([FromBody] JObject direcciones)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string d1 = direcciones.GetValue("direccion1").ToString();
                string d2 = direcciones.GetValue("direccion2").ToString();
                DateTime fechaInt = DateTime.Parse(direcciones.GetValue("fechaInt").ToString());
                DateTime fechaEnd = DateTime.Parse(direcciones.GetValue("fechaEnd").ToString());
                rVP.ConsultaNoVisitantesDireccionFechas(d1, d2, fechaInt, fechaEnd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesA
        [HttpPost("NoVisitantesA")]
        public JsonResult GetNoVisitantesArea([FromBody] JObject areas)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string area1 = areas.GetValue("area1").ToString();
                string area2 = areas.GetValue("area2").ToString();
                rVP.ConsultaNoVisitantesArea(area1, area2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesAMes
        [HttpPost("NoVisitantesAMes")]
        public JsonResult GetNoVisitantesAreaMes([FromBody] JObject areas)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string area1 = areas.GetValue("area1").ToString();
                string area2 = areas.GetValue("area2").ToString();
                int mes = int.Parse(areas.GetValue("mes").ToString());
                rVP.ConsultaNoVisitantesAreaMes(area1, area2, mes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesAMesAnio
        [HttpPost("NoVisitantesAMesAnio")]
        public JsonResult GetNoVisitantesAreaMesAnio([FromBody] JObject areas)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string area1 = areas.GetValue("area1").ToString();
                string area2 = areas.GetValue("area2").ToString();
                int mes = int.Parse(areas.GetValue("mes").ToString());
                int anio = int.Parse(areas.GetValue("anio").ToString());
                rVP.ConsultaNoVisitantesAreaMesAnio(area1, area2, mes, anio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/NoVisitantesAFechas
        [HttpPost("NoVisitantesAFechas")]
        public JsonResult GetNoVisitantesAreaFecha([FromBody] JObject areas)
        {
            try
            {
                rVP = new rVisitasPricipal();
                string area1 = areas.GetValue("area1").ToString();
                string area2 = areas.GetValue("area2").ToString();
                DateTime fechaInt = DateTime.Parse(areas.GetValue("fechaInt").ToString());
                DateTime fechaEnd = DateTime.Parse(areas.GetValue("fechaEnd").ToString());
                rVP.ConsultaNoVisitantesAreaFechas(area1, area2, fechaInt, fechaEnd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // GET: api/rVisitas/pGeneral
        [HttpGet("pGeneral")]
        public JsonResult GetPromedioGeneral()
        {
            try
            {
                rVP = new rVisitasPricipal();
                rVP.ConsultaPromedioG();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.pGeneral);
        }

        // POST: api/rVisitas/pGeneralMes
        [HttpPost("pGeneralMes")]
        public JsonResult GetPromedioGeneralMes([FromBody] JObject mes)
        {
            try
            {
                int mesProm = int.Parse(mes.GetValue("mes").ToString());
                rVP = new rVisitasPricipal();
                rVP.ConsultaPromedioGMes(mesProm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.pGeneral);
        }

        // POST: api/rVisitas/pGeneralMesAnio
        [HttpPost("pGeneralMesAnio")]
        public JsonResult GetPromedioGeneralMesAnio([FromBody] JObject mes)
        {
            try
            {
                int mesProm = int.Parse(mes.GetValue("mes").ToString());
                int anio = int.Parse(mes.GetValue("anio").ToString());
                rVP = new rVisitasPricipal();
                rVP.ConsultaPromedioGMesAnio(mesProm, anio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.pGeneral);
        }

        // POST: api/rVisitas/pGeneralFechas
        [HttpPost("pGeneralFechas")]
        public JsonResult GetPromedioGeneralFechas([FromBody] JObject data)
        {
            try
            {
                DateTime fechaInt = DateTime.Parse(data.GetValue("fechaIni").ToString());
                DateTime fechaEnd = DateTime.Parse(data.GetValue("fechaEnd").ToString());
                rVP = new rVisitasPricipal();
                rVP.ConsultaPromedioGFechas(fechaInt, fechaEnd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.pGeneral);
        }

        // POST: api/rVisitas/vCalificacion
        [HttpPost("vCalificacion")]
        public JsonResult GetVisitantesCalif([FromBody] JObject calificacion)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int calif = int.Parse(calificacion.GetValue("calificacion").ToString());
                rVP.ConsultaNoVisitantesCalif(calif);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/vCalificacionMes
        [HttpPost("vCalificacionMes")]
        public JsonResult GetVisitantesCalifMes([FromBody] JObject calificacion)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int calif = int.Parse(calificacion.GetValue("calificacion").ToString());
                int mes = int.Parse(calificacion.GetValue("mes").ToString());
                rVP.ConsultaNoVisitantesCalifMes(calif, mes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/vCalificacionMesAnio
        [HttpPost("vCalificacionMesAnio")]
        public JsonResult GetVisitantesCalifMesAnio([FromBody] JObject calificacion)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int calif = int.Parse(calificacion.GetValue("calificacion").ToString());
                int mes = int.Parse(calificacion.GetValue("mes").ToString());
                int anio = int.Parse(calificacion.GetValue("anio").ToString());
                rVP.ConsultaNoVisitantesCalifMesAnio(calif, mes, anio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/vCalificacionFechas
        [HttpPost("vCalificacionFechas")]
        public JsonResult GetVisitantesCalifFechas([FromBody] JObject calificacion)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int calif = int.Parse(calificacion.GetValue("calificacion").ToString());
                DateTime fechaInt = DateTime.Parse(calificacion.GetValue("fechaInt").ToString());
                DateTime fechaEnd = DateTime.Parse(calificacion.GetValue("fechaEnd").ToString());
                rVP.ConsultaNoVisitantesCalifFechas(calif, fechaInt, fechaEnd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        // POST: api/rVisitas/bVisita
        [HttpPost("bVisita")]
        public JsonResult GetBorrarVisita([FromBody] JObject idVisita)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int id = int.Parse(idVisita.GetValue("id").ToString());
                rVP.EliminarVisita(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult("Visita eliminada");
        }

        // POST: api/rVisitas/bVisitante
        [HttpPost("bVisitante")]
        public JsonResult GetBorrarVisitante([FromBody] JObject idVisitante)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int id = int.Parse(idVisitante.GetValue("id").ToString());
                rVP.EliminarVisitante(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult("Visitante eliminado");
        }

        // POST: api/rVisitas/bTipoVistante
        [HttpPost("bTipoVistante")]
        public JsonResult GetBorrarTipoVisitante([FromBody] JObject idTipoVisitante)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int id = int.Parse(idTipoVisitante.GetValue("id").ToString());
                rVP.EliminarTipoVisitante(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult("Tipo Visitante eliminado");
        }

        // POST: api/rVisitas/rVisitaRecepcion
        [HttpPost("rVisitaRecepcion")]
        public JsonResult GetrVisitaRecepcion([FromBody] JObject data)
        {
            try
            {
                rVP = new rVisitasPricipal();
                int id = int.Parse(data.GetValue("id").ToString());
                DateTime fecha = DateTime.Parse(data.GetValue("fecha").ToString());
                rVP.RegistroVisitaRecepcion(id, fecha);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult("Vista atendida");
        }

        // GET: api/rVisitas/calificacionesVisitas
        [HttpGet("calificacionesVisitas")]
        public JsonResult GetCalificacionesVisitas()
        {
            try
            {
                rVP = new rVisitasPricipal();
                rVP.ConsultaCalificacionesVisitas();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.Calificaciones);
        }

        // GET: api/rVisitas/TipoVisitantes
        [HttpGet("TipoVisitantes")]
        public JsonResult GetTipoVisitantes()
        {
            try
            {
                rVP = new rVisitasPricipal();
                rVP.GetTipoVisitante();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaTipoVistantes);
        }

        // POST: api/rVisitas/insertVisita
        [HttpPost("insertVisita")]
        public JsonResult PostInsertVisita([FromBody] JObject visita)
        {
            try
            {
                string outMess = null;
                VisitaInsert visitaIns = new VisitaInsert();
                string nombreEmpleado = visita.GetValue("NombreEmp").ToString();
                string ApellidoEmpleado = visita.GetValue("ApellidoEmp").ToString();
                rVP = new rVisitasPricipal();
                rVP.GetIdEmpleado(nombreEmpleado, ApellidoEmpleado);
                visitaIns.Nombre = visita.GetValue("nombre").ToString();
                visitaIns.Empresa = visita.GetValue("empresa").ToString();
                visitaIns.Asunto = visita.GetValue("asunto").ToString();
                visitaIns.Tipo = visita.GetValue("tipo").ToString();
                visitaIns.FechaEntrada = DateTime.Parse(visita.GetValue("fechaEnt").ToString());
                visitaIns.Empleado = rVP.IdEmpleado;

                string email = rVP.CorreoEmpleado;

                //-------------------- Envio del correo ---------------------------------------

                MailMessage emailM = new MailMessage();
                emailM.To.Add(new MailAddress(email));
                emailM.From = new MailAddress("visitas@ciatec.mx");
                string asunto = "Visita " + visita.GetValue("nombre").ToString().ToUpper() + " " + visita.GetValue("empresa").ToString().ToUpper();
                emailM.Subject = asunto;
                string correoBody = "Buen día<br><br> Te informamos que el visitante <b>" + visita.GetValue("nombre").ToString().ToUpper() + "</b> de la empresa <b>" + visita.GetValue("empresa").ToString().ToUpper()
                    + "</b> para <b>" + visita.GetValue("asunto").ToString().ToUpper() + "</b> ha llegado.<br><br> Favor de pasar a recepción a atenderlo.";
                emailM.Body = correoBody;
                emailM.IsBodyHtml = true;
                emailM.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.ciatec.int";
                smtp.Port = 25;

                try
                {
                    smtp.Send(emailM);
                    emailM.Dispose();
                    outMess = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    outMess = "Error enviando correo electrónico: " + ex.Message;
                }

                Console.WriteLine(outMess);

                //-----------------------------------------------------------


                rVP.insertarVisita(visitaIns);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new JsonResult(rVP.Calificaciones);
        }

        //POST: api/rVisitas/insertSalidaVisita
        [HttpPost("insertSalidaVisita")]
        public JsonResult PostInsertSalidaVisita([FromBody] JObject salidaVisita)
        {
            try
            {
                VisitaSalidaInsert salidaVisitaObj = new VisitaSalidaInsert();
                salidaVisitaObj.IdVisita = int.Parse(salidaVisita.GetValue("idVisita").ToString());
                salidaVisitaObj.FechaSalida = DateTime.Parse(salidaVisita.GetValue("fechaSalida").ToString());
                salidaVisitaObj.Calificacion = int.Parse(salidaVisita.GetValue("calificacion").ToString());
                salidaVisitaObj.Observaciones = salidaVisita.GetValue("observaciones").ToString();
                rVP = new rVisitasPricipal();
                rVP.insertarSalidaVisita(salidaVisitaObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.Calificaciones);
        }

        // GET: api/rVisitas/consultaVisitasActivas
        [HttpGet("consultaVisitasActivas")]
        public JsonResult GetVistasActivas()
        {
            try
            {
                rVP = new rVisitasPricipal();
                rVP.GetVisitasActivas();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaVisitasActivas);
        }

        // GET: api/rVisitas/consultaVisitasActivas
        [HttpGet("consultaVisitasEspera")]
        public JsonResult GetVistasEspera()
        {
            try
            {
                rVP = new rVisitasPricipal();
                rVP.GetVistasEspera();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaVisitasEspera);
        }

        // POST: api/rVisitas/AreasxDireccion
        [HttpPost("AreasxDireccion")]
        public JsonResult GetAreasxDireccion([FromBody] JObject direccion)
        {
            try
            {
                rVP = new rVisitasPricipal();
                rVP.GetAreasxDireccion(direccion.GetValue("direccion").ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.Areas);
        }

        //POST: api/rVisitas/insertSalidaVisita
        [HttpPost("consultaVisitasActNombre")]
        public JsonResult PostVisitasActNombre([FromBody] JObject salidaVisita)
        {
            try
            {
                string nombre = salidaVisita.GetValue("nombreVisitante").ToString();
                rVP = new rVisitasPricipal();
                rVP.PostVisitasActivasNombre(nombre);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.ListaVisitasActivas);
        }

        //POST: api/rVisitas/noVisitasxMes
        [HttpPost("noVisitasxMes")]
        public JsonResult PostVisitasxMes([FromBody] JObject mes)
        {
            try
            {
                int numMes = int.Parse(mes.GetValue("mes").ToString());
                rVP = new rVisitasPricipal();
                rVP.ConsultaNoVisitantesMes(numMes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }

        //POST: api/rVisitas/noVisitasxMesAnio
        [HttpPost("noVisitasxMesAnio")]
        public JsonResult PostVisitasxMesAnio([FromBody] JObject mes)
        {
            try
            {
                int numMes = int.Parse(mes.GetValue("mes").ToString());
                int anio = int.Parse(mes.GetValue("anio").ToString());
                rVP = new rVisitasPricipal();
                rVP.ConsultaNoVisitantesMesAnio(numMes, anio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new JsonResult(rVP.NoVisitantes);
        }
        //TODO: Quedan pendientes los servicios de insert, debido al tema del fomateo de datos por parte de la aplicacion
    }


}
