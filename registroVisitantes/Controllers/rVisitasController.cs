using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using registroVisitantes.Modelos;
using registroVisitantes.Clases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace registroVisitantes.Controllers
{
    [Route("api/rVisitas")]
    [ApiController]
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

        // GET: api/rVisitas/areas/a1/a2
        [HttpGet("areas/{a1}/{a2}")]
        public JsonResult GetVisitaAreas(string a1, string a2)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaVistasAreas(a1, a2);
            return new JsonResult(rVP.ListaVisitas);
        }

        // GET: api/rVisitas/direcciones/d1/d2
        [HttpGet("direcciones/{d1}/{d2}")]
        public JsonResult GetVisitaDirecciones(string d1, string d2)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaVistasDirecciones(d1, d2);
            return new JsonResult(rVP.ListaVisitas);
        }

        // GET: api/rVisitas/empleados/eNombre/eNumero
        [HttpGet("empleados/{eNombre}/{eNumero}")]
        public JsonResult GetVisitaEmpleados(string eNombre, int eNumero)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaVistasEmpleados(eNombre, eNumero);
            return new JsonResult(rVP.ListaVisitas);
        }

        // GET: api/rVisitas/fechas/FechaIni/FechaEnd
        [HttpGet("fechas/{FechaIni}/{FechaEnd}")]
        public JsonResult GetVisitaFecha(DateTime FechaIni, DateTime FechaEnd)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaVistasFechas(FechaIni, FechaEnd);
            return new JsonResult(rVP.ListaVisitas);
        }

        // GET: api/rVisitas/NoVisitantes/FechaIni/FechaEnd
        [HttpGet("NoVisitantes/{FechaIni}/{FechaEnd}")]
        public JsonResult GetNoVisitantes(DateTime FechaIni, DateTime FechaEnd)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaNoVisitantes(FechaIni, FechaEnd);
            return new JsonResult(rVP.NoVisitantes);
        }

        // GET: api/rVisitas/NoVisitantesActivos/Fecha
        [HttpGet("NoVisitantesActivos/{Fecha}")]
        public JsonResult GetNoVisitantesActivos(DateTime Fecha)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaNoVisitantesActivos(Fecha);
            return new JsonResult(rVP.NoVisitantes);
        }

        // GET: api/rVisitas/NoVisitantesD/d1/d2
        [HttpGet("NoVisitantesD/{d1}/{d2}")]
        public JsonResult GetNoVisitantesDireccion(string d1, string d2)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaNoVisitantesDireccion(d1 , d2);
            return new JsonResult(rVP.NoVisitantes);
        }

        // GET: api/rVisitas/NoVisitantesA/d1/d2
        [HttpGet("NoVisitantesA/{a1}/{a2}")]
        public JsonResult GetNoVisitantesArea(string a1, string a2)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaNoVisitantesArea(a1, a2);
            return new JsonResult(rVP.NoVisitantes);
        }

        // GET: api/rVisitas/pGeneral
        [HttpGet("pGeneral")]
        public JsonResult GetPromedioGeneral()
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaPromedioG();
            return new JsonResult(rVP.pGeneral);
        }

        // GET: api/rVisitas/vCalificacion/calif
        [HttpGet("vCalificacion/{calif}")]
        public JsonResult GetVisitantesCalif(int calif)
        {
            rVP = new rVisitasPricipal();
            rVP.ConsultaNoVisitantesCalif(calif);
            return new JsonResult(rVP.NoVisitantes);
        }

        // GET: api/rVisitas/bVisita/id
        [HttpGet("bVisita/{id}")]
        public JsonResult GetBorrarVisita(int id)
        {
            rVP = new rVisitasPricipal();
            rVP.EliminarVisita(id);
            return new JsonResult("Visita eliminada");
        }

        // GET: api/rVisitas/bVisitante/id
        [HttpGet("bVisitante/{id}")]
        public JsonResult GetBorrarVisitante(int id)
        {
            rVP = new rVisitasPricipal();
            rVP.EliminarVisitante(id);
            return new JsonResult("Visitante eliminado");
        }

        // GET: api/rVisitas/bTipoVistante/id
        [HttpGet("bTipoVistante/{id}")]
        public JsonResult GetBorrarTipoVisitante(int id)
        {
            rVP = new rVisitasPricipal();
            rVP.EliminarTipoVisitante(id);
            return new JsonResult("Tipo Visitante eliminado");
        }

        // GET: api/rVisitas/rVisitaRecepcion/id/fecha
        [HttpGet("rVisitaRecepcion/{id}/{fecha}")]
        public JsonResult GetrVisitaRecepcion(int id, DateTime fecha)
        {
            rVP = new rVisitasPricipal();
            rVP.RegistroVisitaRecepcion(id, fecha);
            return new JsonResult("Vista atendida");
        }
        //TODO: Quedan pendientes los servicios de insert, debido al tema del fomateo de datos por parte de la aplicacion
    }

    
}
