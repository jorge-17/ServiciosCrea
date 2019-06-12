using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registroVisitantes.Modelos
{
    public class Models
    {
    }

    public class Visita
    {
        public int vis_ID { get; set; }
        public int emp_ID { get; set; }
        public int visi_ID { get; set; }
        public DateTime vis_FechaEntrada { get; set; }
        public DateTime vis_FechaSalida { get; set; }
        public int vis_Calificacion { get; set; }
        public string vis_Observacion { get; set; }
        public bool vis_Estatus { get; set; }
        public bool vis_EstadoVisita { get; set; }
        public string vis_Asunto { get; set; }

    }

    public class VisitaInsert
    {
        public string Nombre { get; set; }
        public string Empresa { get; set; }
        public string Asunto { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaEntrada { get; set; }
        public string Empleado { get; set; }
    }

    public class VisitaSalidaInsert
    {
        public int IdVisita { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Calificacion { get; set; }
        public string Observaciones { get; set; }
    }

    public class Visitante
    {
        public int visi_ID { get; set; }
        public string visi_Nombre { get; set; }
        public string visi_Empresa { get; set; }        
        public bool visi_Estatus { get; set; }
        public int tip_ID { get; set; }

    }

    public class TipoVisitante
    {
        public int tip_ID { get; set; }
        public string tip_Descripcion { get; set; }
        public bool tip_Estatus { get; set; }
    }

    public class Empleado
    {
        public int emp_ID { get; set; }
        public string emp_Nombre { get; set; }
        public string emp_Correo { get; set; }
        public string emp_Direccion { get; set; }
        public string emp_Area { get; set; }
        public int emp_Numero { get; set; }
    }

    public class consultaArea
    {
        public string visi_Nombre { get; set; }
        public string visi_Empresa { get; set; }
        public string vis_Asunto { get; set; }
        public string emp_Nombre { get; set; }
        public int emp_Numero { get; set; }
        public string emp_Direccion { get; set; }
        public string emp_Area { get; set; }
        public DateTime vis_FechaEntrada { get; set; }
        public DateTime vis_FechaSalida { get; set; }
        public int vis_Calificacion { get; set; }
        public string vis_Observacion { get; set; }
        public string tip_Descripcion { get; set; }
    }

    public class consultaDireccion
    {
        public string visi_Nombre { get; set; }
        public string visi_Empresa { get; set; }
        public string vis_Asunto { get; set; }
        public string emp_Nombre { get; set; }
        public int emp_Numero { get; set; }
        public string emp_Direccion { get; set; }
        public string emp_Area { get; set; }
        public DateTime vis_FechaEntrada { get; set; }
        public DateTime vis_FechaSalida { get; set; }
        public int vis_Calificacion { get; set; }
        public string vis_Observacion { get; set; }
        public string tip_Descripcion { get; set; }
    }

    public class consultaEmpleado
    {
        public string visi_Nombre { get; set; }
        public string visi_Empresa { get; set; }
        public string vis_Asunto { get; set; }
        public string emp_Nombre { get; set; }
        public int emp_Numero { get; set; }
        public string emp_Direccion { get; set; }
        public string emp_Area { get; set; }
        public DateTime vis_FechaEntrada { get; set; }
        public DateTime vis_FechaSalida { get; set; }
        public int vis_Calificacion { get; set; }
        public string vis_Observacion { get; set; }
        public string tip_Descripcion { get; set; }
    }

    public class consultaFecha
    {
        public string visi_Nombre { get; set; }
        public string visi_Empresa { get; set; }
        public string vis_Asunto { get; set; }
        public string emp_Nombre { get; set; }
        public int emp_Numero { get; set; }
        public string emp_Direccion { get; set; }
        public string emp_Area { get; set; }
        public DateTime vis_FechaEntrada { get; set; }
        public DateTime? vis_FechaSalida { get; set; }
        public int? vis_Calificacion { get; set; }
        public string vis_Observacion { get; set; }
        public string tip_Descripcion { get; set; }
    }

    public class VisitasActivas
    {
        public string NombreVisitante { get; set; }
        public string Empresa { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int IdVisita { get; set; }
        public string Asunto { get; set; }
    }

    public class VisitasEspera
    {
        public string NombreVisitante { get; set; }
        public string Empresa { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int IdVisita { get; set; }
        public string Asunto { get; set; }
        public string Colaborador { get; set; }
        public string TipoVisitante { get; set; }
    }

}
