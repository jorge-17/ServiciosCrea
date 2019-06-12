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
        public List<int> Calificaciones;
        public List<string> Areas;
        public List<TipoVisitante> ListaTipoVistantes;
        public List<VisitasActivas> ListaVisitasActivas;
        public List<VisitasEspera> ListaVisitasEspera;
        public int NoVisitantes;
        public int pGeneral;
        public string IdEmpleado;
        public string CorreoEmpleado;
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
                if (!string.IsNullOrEmpty(item["FechaSalida"].ToString()))
                {
                    visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                }
                if (!string.IsNullOrEmpty(item["Calificacion"].ToString()))
                {
                    visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                }
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
                if (!string.IsNullOrEmpty(item["FechaSalida"].ToString()))
                {
                    visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                }
                if (!string.IsNullOrEmpty(item["Calificacion"].ToString()))
                {
                    visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                }
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
                if (!string.IsNullOrEmpty(item["FechaSalida"].ToString()))
                {
                    visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                }
                if (!string.IsNullOrEmpty(item["Calificacion"].ToString()))
                {
                    visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                }
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
                if (!string.IsNullOrEmpty(item["FechaSalida"].ToString()))
                {
                    visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                }
                if (!string.IsNullOrEmpty(item["Calificacion"].ToString()))
                {
                    visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                }
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
                if (!string.IsNullOrEmpty(item["FechaSalida"].ToString()))
                {
                    visita.vis_FechaSalida = DateTime.Parse(item["FechaSalida"].ToString());
                }
                if (!string.IsNullOrEmpty(item["Calificacion"].ToString()))
                {
                    visita.vis_Calificacion = int.Parse(item["Calificacion"].ToString());
                }
                visita.vis_Observacion = item["Observacion"].ToString();
                visita.tip_Descripcion = item["TipoVisitante"].ToString();

                ListaVisitas.Add(visita);
            }
            
        }

        public void ConsultaNoVisitantes(DateTime FechaIni, DateTime FechaEnd)
        {
            NoVisitantes = 0;
            string fechaI = FechaIni.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaE = FechaEnd.ToString("yyyy-MM-dd HH:mm:ss");

            var command = new SqlCommand("EXEC ConsultaNoVisitantes @Desde='" + fechaI + "', @Hasta='" + fechaE + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantes"].ToString());
        }

        public void ConsultaNoVisitantesMes(int mes)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ConsultaNoVisitantesMes @Mes=" + mes + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantes"].ToString());
        }

        public void ConsultaNoVisitantesMesAnio(int mes, int anio)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ConsultaNoVisitantesMesAño @Mes=" + mes + ", @Año= " + anio + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantes"].ToString());
        }

        public void ConsultaNoVisitantesActivos()
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ConsultaNoVisitantesActivos;", cnn);
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

        public void ConsultaPromedioGMes(int mes)
        {
            var command = new SqlCommand("EXEC ConsultaPromedioGralMes @Mes=" + mes + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            pGeneral = int.Parse(dataTable.Rows[0]["PromedioGeneral"].ToString());
        }

        public void ConsultaPromedioGMesAnio(int mes, int anio)
        {
            var command = new SqlCommand("EXEC ConsultaPromedioGralMesAño @Mes=" + mes + ", @Año=" + anio + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            pGeneral = int.Parse(dataTable.Rows[0]["PromedioGeneral"].ToString());
        }

        public void ConsultaPromedioGFechas(DateTime FechaIni, DateTime FechaEnd)
        {
            string fechaI = FechaIni.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaE = FechaEnd.ToString("yyyy-MM-dd HH:mm:ss");
            var command = new SqlCommand("EXEC ConsultaPromedioGralFechas @Desde='" + fechaI + "', @Hasta='" + fechaE + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["PromedioGeneral"].ToString()))
            {
                pGeneral = int.Parse(dataTable.Rows[0]["PromedioGeneral"].ToString());
            }
            else
            {
                pGeneral = 0;
            }

            
        }

        public void ConsultaNoVisitantesDireccion(string d1, string d2)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitasDir @Direccion1='" + d1 + "',@Direccion2='" + d2 + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasDireccion"].ToString());
        }

        public void ConsultaNoVisitantesDireccionMes(string d1, string d2, int mes)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitasDirMes @Direccion1='" + d1 + "',@Direccion2='" + d2 + "', @Mes=" + mes + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["VisitasDireccion"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasDireccion"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }            
        }


        public void ConsultaNoVisitantesDireccionMesAnio(string d1, string d2, int mes, int anio)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitasDirMesAño @Direccion1='" + d1 + "',@Direccion2='" + d2 + "', @Mes=" + mes + ", @Año=" + anio + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["VisitasDireccion"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasDireccion"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesDireccionFechas(string d1, string d2, DateTime fechaInit, DateTime fechaEnd)
        {
            string fechaI = fechaInit.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaE = fechaEnd.ToString("yyyy-MM-dd HH:mm:ss");
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitasDirFechas @Direccion1='" + d1 + "',@Direccion2='" + d2 + "', @Desde='" + fechaI + "', @Hasta='" + fechaE + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["VisitasDireccion"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasDireccion"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesArea(string a1, string a2)
        {
            var command = new SqlCommand("EXEC ContarVisitasArea @Area1='" + a1 + "',@Area2='" + a2 + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();
            NoVisitantes = 0;
            if (!string.IsNullOrEmpty(dataTable.Rows[0]["VisitasArea"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasArea"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesAreaMes(string a1, string a2, int mes)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitasAreaMes @Area1='" + a1 + "',@Area2='" + a2 + "', @Mes=" + mes + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["VisitasArea"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasArea"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesAreaMesAnio(string a1, string a2, int mes, int anio)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitasAreaMesAño @Area1='" + a1 + "',@Area2='" + a2 + "', @Mes=" + mes + ", @Año=" + anio + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["VisitasArea"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasArea"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesAreaFechas(string a1, string a2, DateTime fechaInit, DateTime fechaEnd)
        {
            NoVisitantes = 0;
            string fechaI = fechaInit.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaE = fechaEnd.ToString("yyyy-MM-dd HH:mm:ss");

            var command = new SqlCommand("EXEC ContarVisitasAreaFechas @Area1='" + a1 + "',@Area2='" + a2 + "', @Desde='" + fechaI + "', @Hasta='" + fechaE + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["VisitasArea"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["VisitasArea"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesCalif(int calificacion)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitantesCalif @Calif=" + calificacion + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }           
        }

        public void ConsultaNoVisitantesCalifMes(int calificacion, int mes)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitantesCalifMes @Calif='" + calificacion + "', @Mes='" + mes + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesCalifMesAnio(int calificacion, int mes, int anio)
        {
            NoVisitantes = 0;
            var command = new SqlCommand("EXEC ContarVisitantesCalifMesAño @Calif='" + calificacion + "', @Mes=" + mes + ", @Año=" + anio + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaNoVisitantesCalifFechas(int calificacion, DateTime fechaInit, DateTime fechaEnd)
        {
            NoVisitantes = 0;
            string fechaI = fechaInit.ToString("yyyy-MM-dd HH:mm:ss");
            string fechaE = fechaEnd.ToString("yyyy-MM-dd HH:mm:ss");
            var command = new SqlCommand("EXEC ContarVisitantesCalifFechas @Calif='" + calificacion + "', @Desde='" + fechaI + "', @Hasta='" + fechaE + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            if (!string.IsNullOrEmpty(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString()))
            {
                NoVisitantes = int.Parse(dataTable.Rows[0]["NoVisitantesxCalificacion"].ToString());
            }
            else
            {
                NoVisitantes = 0;
            }
        }

        public void ConsultaCalificacionesVisitas()
        {
            Calificaciones = new List<int>();
            for(int i = 0; i <= 4; i++)
            {
                var command = new SqlCommand("EXEC ContarVisitantesCalif @Calif=" + (i+1) + ";", cnn);
                var data = new SqlDataAdapter(command);
                data.Fill(dataTable);
                Console.WriteLine(dataTable.Rows[i]["NoVisitantesxCalificacion"].ToString());
                int cal = int.Parse(dataTable.Rows[i]["NoVisitantesxCalificacion"].ToString());
                Calificaciones.Add(cal);
            }
            cnn.Close();
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

        public void insertarVisita(VisitaInsert visitaIns)
        {
            string fechaS = visitaIns.FechaEntrada.ToString("yyyy-MM-dd HH:mm:ss");
            var command = new SqlCommand("EXEC InsertarEntradaVisita @Nombre='" + visitaIns.Nombre + "',@Empresa='" + visitaIns.Empresa + "',@Asunto='" + visitaIns.Asunto +"',@Tipo=" + visitaIns.Tipo + ",@FechaEntrada='" + fechaS + "',@Empleado=" + visitaIns.Empleado + ";", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();
        }

        public void insertarSalidaVisita(VisitaSalidaInsert salidaVisita)
        {
            string fechaS = salidaVisita.FechaSalida.ToString("yyyy-MM-dd HH:mm:ss");
            var command = new SqlCommand("EXEC InsertarSalidaVisita @ID=" + salidaVisita.IdVisita + ",@FechaSalida='" + fechaS + "',@Calificacion=" + salidaVisita.Calificacion + ",@Observacion='" + salidaVisita.Observaciones + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();
        }

        public void GetIdEmpleado(string NombreEmpleado, string ApellidoEmpleado)
        {
            var command = new SqlCommand("EXEC EmpleadoID @Nombre='" + NombreEmpleado + "', @Apellido='"+ ApellidoEmpleado + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            IdEmpleado = dataTable.Rows[0]["EmpleadoID"].ToString();
            CorreoEmpleado = dataTable.Rows[0]["Correo"].ToString();
        }

        public void GetTipoVisitante()
        {
            var command = new SqlCommand("EXEC Tipo_ID;", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaTipoVistantes = new List<TipoVisitante>();
            foreach (DataRow item in dataTable.Rows)
            {
                TipoVisitante tipoVisitante = new TipoVisitante();
                tipoVisitante.tip_ID = int.Parse(item["ID"].ToString());
                tipoVisitante.tip_Descripcion = item["Tipo"].ToString();

                ListaTipoVistantes.Add(tipoVisitante);
            }
        }

        public void GetVisitasActivas()
        {
            var command = new SqlCommand("EXEC VisitasActivas;", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitasActivas = new List<VisitasActivas>();
            foreach (DataRow item in dataTable.Rows)
            {
                VisitasActivas visitaActiva = new VisitasActivas();
                visitaActiva.NombreVisitante = item["Nombre"].ToString();
                visitaActiva.Empresa = item["Empresa"].ToString();
                visitaActiva.IdVisita = int.Parse(item["ID"].ToString());
                visitaActiva.Asunto = item["Asunto"].ToString();
                if (!string.IsNullOrEmpty(item["FechaEntrada"].ToString()))
                {
                    visitaActiva.FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                }
                

                ListaVisitasActivas.Add(visitaActiva);
            }
        }

        public void PostVisitasActivasNombre(string nombreVisitante)
        {
            var command = new SqlCommand("EXEC BuscarVisitaActivaNombre @Nombre='" + nombreVisitante +"';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitasActivas = new List<VisitasActivas>();
            foreach (DataRow item in dataTable.Rows)
            {
                VisitasActivas visitaActiva = new VisitasActivas();
                visitaActiva.NombreVisitante = item["Nombre"].ToString();
                visitaActiva.Empresa = item["Empresa"].ToString();
                visitaActiva.IdVisita = int.Parse(item["ID"].ToString());
                visitaActiva.Asunto = item["Asunto"].ToString();
                if (!string.IsNullOrEmpty(item["FechaEntrada"].ToString()))
                {
                    visitaActiva.FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                }


                ListaVisitasActivas.Add(visitaActiva);
            }
        }


        public void GetVistasEspera()
        {
            var command = new SqlCommand("EXEC VisitasNOActivas;", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            ListaVisitasEspera = new List<VisitasEspera>();
            foreach (DataRow item in dataTable.Rows)
            {
                VisitasEspera visitaEspera = new VisitasEspera();
                visitaEspera.NombreVisitante = item["Nombre"].ToString();
                visitaEspera.Empresa = item["Empresa"].ToString();
                visitaEspera.IdVisita = int.Parse(item["ID"].ToString());
                if (!string.IsNullOrEmpty(item["FechaEntrada"].ToString()))
                {
                    visitaEspera.FechaEntrada = DateTime.Parse(item["FechaEntrada"].ToString());
                }
                visitaEspera.Asunto = item["Asunto"].ToString();
                visitaEspera.Colaborador = item["Colaborador"].ToString();
                visitaEspera.TipoVisitante = item["TipoVisitante"].ToString();


                ListaVisitasEspera.Add(visitaEspera);
            }
        }

        public void GetAreasxDireccion(string direccion)
        {
            var command = new SqlCommand("EXEC AreasPorDireccion @Direccion='" + direccion + "';", cnn);
            var data = new SqlDataAdapter(command);
            data.Fill(dataTable);
            cnn.Close();

            Areas = new List<string>();
            foreach (DataRow item in dataTable.Rows)
            {                
                string area = item["Area"].ToString();

                Areas.Add(area);
            }
        }
        //TODO: Quedan pendientes los servicios de insert, debido al tema del fomateo de datos por parte de la aplicacion
    }
}
