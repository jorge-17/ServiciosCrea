using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using registroVisitantes.Modelos;

namespace registroVisitantes.Clases
{
    public class rVisitasPricipal
    {
        DataTable dataTable = new DataTable();
        public List<consultaFecha> ListaVisitas;
        public int NoVisitantes;
        public int pGeneral;
        string connetionString = null;
        SqlConnection cnn;
        public rVisitasPricipal()
        {
            connetionString = "Data Source=inf-SQL16.Ciatec.Int;Initial Catalog=RegistroVisitas;User ID=uRVisitas;Password=CTCS0f1$";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ConsultaVistas()
        {
            var command = new SqlCommand("EXEC ConsultaVisitas;", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitas = new List<consultaFecha>();
            foreach (DataRow item in dataTable.Rows)
            {
                consultaFecha visita = new consultaFecha();
                visita.visi_Nombre = item["Nombre"].ToString();
                visita.visi_Empresa = item["Empresa"].ToString();
                visita.vis_Asunto = item["Asunto"].ToString();
                visita.emp_Nombre = item["Colaborador"].ToString();
                visita.emp_Numero = int.Parse(item["NoEmpleado"].ToString());
                visita.emp_Direccion = item["Direccion"].ToString();
                visita.emp_Area = item["Area"].ToString();
                visita.vis_FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                visita.vis_Observacion = item["Observacion"].ToString();
                visita.tip_Descripcion = item["TipoVisitante"].ToString();

                ListaVisitas.Add(visita);
            }

        }

        internal void ConsultaVistasEmpleados(string eNombre, int eNumero)
        {
            var command = new SqlCommand("EXEC ConsultaEmpleado @Nombre='" + eNombre + "',@Numero='" + eNumero + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitas = new List<consultaFecha>();
            foreach (DataRow item in dataTable.Rows)
            {
                consultaFecha visita = new consultaFecha();
                visita.visi_Nombre = item["Nombre"].ToString();
                visita.visi_Empresa = item["Empresa"].ToString();
                visita.vis_Asunto = item["Asunto"].ToString();
                visita.emp_Nombre = item["Colaborador"].ToString();
                visita.emp_Numero = int.Parse(item["NoEmpleado"].ToString());
                visita.emp_Direccion = item["Direccion"].ToString();
                visita.emp_Area = item["Area"].ToString();
                visita.vis_FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                visita.vis_Observacion = item["Observacion"].ToString();
                visita.tip_Descripcion = item["TipoVisitante"].ToString();

                ListaVisitas.Add(visita);
            }
        }

        

        public void ConsultaVistasAreas(string area1, string area2)
        {
            var command = new SqlCommand("EXEC ConsultaArea @Area1='" + area1 + "',@Area2='" + area2 +"';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitas = new List<consultaFecha>();
            foreach (DataRow item in dataTable.Rows)
            {
                consultaFecha visita = new consultaFecha();
                visita.visi_Nombre = item["Nombre"].ToString();
                visita.visi_Empresa = item["Empresa"].ToString();
                visita.vis_Asunto = item["Asunto"].ToString();
                visita.emp_Nombre = item["Colaborador"].ToString();
                visita.emp_Numero = int.Parse(item["NoEmpleado"].ToString());
                visita.emp_Direccion = item["Direccion"].ToString();
                visita.emp_Area = item["Area"].ToString();
                visita.vis_FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                visita.vis_Observacion = item["Observacion"].ToString();
                visita.tip_Descripcion = item["TipoVisitante"].ToString();

                ListaVisitas.Add(visita);
            }
        }

        public void ConsultaVistasDirecciones(string d1, string d2)
        {
            var command = new SqlCommand("EXEC ConsultaDireccion @Direccion1='" + d1 + "',@Direccion2='" + d2 + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitas = new List<consultaFecha>();
            foreach (DataRow item in dataTable.Rows)
            {
                consultaFecha visita = new consultaFecha();
                visita.visi_Nombre = item["Nombre"].ToString();
                visita.visi_Empresa = item["Empresa"].ToString();
                visita.vis_Asunto = item["Asunto"].ToString();
                visita.emp_Nombre = item["Colaborador"].ToString();
                visita.emp_Numero = int.Parse(item["NoEmpleado"].ToString());
                visita.emp_Direccion = item["Direccion"].ToString();
                visita.emp_Area = item["Area"].ToString();
                visita.vis_FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                visita.vis_Observacion = item["Observacion"].ToString();
                visita.tip_Descripcion = item["TipoVisitante"].ToString();

                ListaVisitas.Add(visita);
            }
        }

        public void ConsultaVistasFechas(DateTime FechaIni, DateTime FechaEnd)
        {
            string fechaI = FechaIni.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaE = FechaEnd.ToString("yyyy-MM-dd HH:mm:ss");
            //var command = new SqlCommand("EXEC ConsultaFechas @Desde='2008-11-11 13:23:44', @Hasta='2008-12-21 14:23:44';", cnn);
            var command = new SqlCommand("EXEC ConsultaFechas @Desde='" + fechaI + "', @Hasta='" + fechaE + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitas = new List<consultaFecha>();
            foreach(DataRow item in dataTable.Rows)
            {
                consultaFecha visita = new consultaFecha();
                visita.visi_Nombre = item["Nombre"].ToString();
                visita.visi_Empresa = item["Empresa"].ToString();
                visita.vis_Asunto = item["Asunto"].ToString();
                visita.emp_Nombre = item["Colaborador"].ToString();
                visita.emp_Numero = int.Parse(item["NoEmpleado"].ToString());
                visita.emp_Direccion = item["Direccion"].ToString();
                visita.emp_Area = item["Area"].ToString();
                visita.vis_FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                visita.vis_Observacion = item["Observacion"].ToString();
                visita.tip_Descripcion = item["TipoVisitante"].ToString();

                ListaVisitas.Add(visita);
            }
            
        }

        public void ConsultaNoVisitantes(DateTime FechaIni, DateTime FechaEnd)
        {
            string fechaI = FechaIni.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaE = FechaEnd.ToString("yyyy-MM-dd HH:mm:ss");

            var command = new SqlCommand("EXEC ConsultaNoVisitantes @Desde='" + fechaI + "', @Hasta='" + fechaE + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantes"].ToString());
        }

        public void ConsultaNoVisitantesActivos(DateTime Fecha)
        {
            string fechaI = Fecha.ToString("yyyy-MM-dd HH:mm:ss");

            var command = new SqlCommand("EXEC ConsultaNoVisitantesActivos  @Fecha='" + fechaI + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantesActivos"].ToString());
        }

        public void ConsultaPromedioG()
        {
            var command = new SqlCommand("EXEC ConsultaPromedioGral;", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            pGeneral = int.Parse(dataTable.Rows[0]["PromedioGeneral"].ToString());
        }

        public void ConsultaNoVisitantesDireccion(string d1, string d2)
        {
            var command = new SqlCommand("EXEC ContarVisitasDir @Direccion1='" + d1 + "',@Direccion2='" + d2 + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasDireccion"].ToString());
        }

        public void ConsultaNoVisitantesArea(string a1, string a2)
        {
            var command = new SqlCommand("EXEC ContarVisitasArea @Area1='" + a1 + "',@Area2='" + a2 + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasArea"].ToString());
        }

        public void ConsultaNoVisitantesCalif(int calificacion)
        {
            var command = new SqlCommand("EXEC ContarVisitantesCalif @Calif=" + calificacion + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString());
        }

        public void EliminarVisita(int id)
        {
            var command = new SqlCommand("EXEC BorrarVisita @ID=" + id + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();            
        }

        public void EliminarVisitante(int id)
        {
            var command = new SqlCommand("EXEC BorrarVisitante @ID=" + id + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();
        }

        public void EliminarTipoVisitante(int id)
        {
            var command = new SqlCommand("EXEC BorrarTipoVisitante @ID=" + id + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();
        }

        public void RegistroVisitaRecepcion(int id, DateTime fecha)
        {
            string fechaS = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            var command = new SqlCommand("EXEC AceptarVisitaRecepcion @ID=" + id + ",@Fecha='" + fechaS + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();
        }
        //TODO: Quedan pendientes los servicios de insert, debido al tema del fomateo de datos por parte de la aplicacion
    }
}
