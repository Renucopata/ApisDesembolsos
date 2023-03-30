﻿using ApisDesembolsos.Models;
using System.Data;
using System.Data.SqlClient;

namespace ApisDesembolsos.Handlers
{
    public class Procedures
    {

        /*public bool CargaDatos(ModeloDesembolso desembolso, string correoP, string nombre)
        {
            bool resp = false;
            try
            {
                var cn = new ConnectionBuros();
                using (var conexion = new SqlConnection(cn.get_cadConexionBuros()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SP_INSERT_SOLICITUD", conexion);
                    cmd.Parameters.AddWithValue("NOMBRE_OFICIAL", nombre);
                    cmd.Parameters.AddWithValue("AGENCIA", desembolso.AGENCIA);
                    cmd.Parameters.AddWithValue("SUCURSAL", desembolso.SUCURSAL);
                    cmd.Parameters.AddWithValue("NPRESTAMO", desembolso.NPRESTAMO);
                    cmd.Parameters.AddWithValue("PRIMERA_FECHA", desembolso.PRIMERA_FECHA);
                    cmd.Parameters.AddWithValue("CORREO_PLATAFORMA", correoP);
                    cmd.Parameters.AddWithValue("CORREO_OFICIAL", "DCORONEL@BANCOECOFUTURO.COM.BO");
                    cmd.Parameters.AddWithValue("TICKET", desembolso.TICKET);
                    cmd.Parameters.AddWithValue("MONTO", 0.0);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resp = true;
            }
            catch (Exception ex)
            {
                resp = false;
                string mensaje = ex.Message.ToString();
            }
            return resp;
        }*/

        public SpResponse SpTraerSoliEnvios(REQUEST_ID data)
        {

            var response = new SpResponse();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                using (var cmd = new SqlCommand("SP_TRAER_SOLIICITUD_ENVIOS", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_solicitud", data.id);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                var row = dt.Rows[0];
                                response.Nomb_oficial = Convert.ToString(row["NOMBRE_OFICIAL"]);
                                response.Agencia = Convert.ToString(row["AGENCIA"]);
                                response.Sucursal = Convert.ToString(row["SUCURSAL"]);
                                response.NPrestamo = Convert.ToInt64(row["NPRESTAMO"]);
                                response.ticket = Convert.ToInt64(row["TICKET"]);
                                response.PrimFecha = Convert.ToString(row["PRIMERA_FECHA"]);
                                response.CorreoPlataforma = Convert.ToString(row["CORREO_PLATAFORMA"]);
                                response.CorreoOficial = Convert.ToString(row["CORREO_OFICIAL"]);
                                response.Id_Solicitud = Convert.ToInt64(row["ID_SOLICITUD"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                        }
                    }
                }
                return response;
            }
        }

        //SP´s faltantes

        public SpResponseNsoli SpInsertSolPCCU(REQUEST_TICKET_AND_IDPERSONA data)
        {
            var response = new SpResponseNsoli();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                using (var cmd = new SqlCommand("SP_INSERT_SOLICITUD_PCCU", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TICKET", data.ticket);
                    cmd.Parameters.AddWithValue("@IDPERSONA", data.id);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                var row = dt.Rows[0];

                                response.N_Solicitud = Convert.ToInt64(row["N_SOLICITUD"]);

                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                        }
                    }
                }
            }
            return response;
        }

        public bool SpInsertSol(REQUEST_INFO_INSER_SOL data)
        {

            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                using (var cmd = new SqlCommand("SP_INSERT_SOLICITUD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE_OFICIAL", data.NOMB_OFICIAL);
                    cmd.Parameters.AddWithValue("@AGENCIA", data.AGENCIA);
                    cmd.Parameters.AddWithValue("@SUCURSAL", data.SUCURSAL);
                    cmd.Parameters.AddWithValue("@NPRESTAMO", data.NPRESTAMO);
                    cmd.Parameters.AddWithValue("@PRIMERA_FECHA", data.PRIMERA_FECHA);
                    cmd.Parameters.AddWithValue("@CORREO_PLATAFORMA", data.CORREO_PLATAFORMA);
                    cmd.Parameters.AddWithValue("@CORREO_OFICIAL", data.CORREO_OFICIAL);
                    cmd.Parameters.AddWithValue("@TICKET", data.TICKET);
                    cmd.Parameters.AddWithValue("@MONTO", data.MONTO);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {

                            return true;

                            //Siempre devuelve true, comfirmar que es necesario llenar los parametros
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                }
            }

        }

        public SpResponse SpSolFallida()
        {
            var response = new SpResponse();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                using (var cmd = new SqlCommand("SP_TRAER_SOLIICITUD_FALLIDA", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                var row = dt.Rows[0];
                                response.Nomb_oficial = Convert.ToString(row["NOMBRE_OFICIAL"]);
                                response.Agencia = Convert.ToString(row["AGENCIA"]);
                                response.Sucursal = Convert.ToString(row["SUCURSAL"]);
                                response.NPrestamo = Convert.ToInt64(row["NPRESTAMO"]);
                                response.ticket = Convert.ToInt64(row["TICKET"]);
                                response.PrimFecha = Convert.ToString(row["PRIMERA_FECHA"]);
                                response.CorreoPlataforma = Convert.ToString(row["CORREO_PLATAFORMA"]);
                                response.CorreoOficial = Convert.ToString(row["CORREO_OFICIAL"]);
                                response.Id_Solicitud = Convert.ToInt64(row["ID_SOLICITUD"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                        }
                    }
                }
                return response;
            }
        }
        public SpResponse SpTraerSol()
        {
            var response = new SpResponse();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                using (var cmd = new SqlCommand("SP_TRAER_SOLIICITUD", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                var row = dt.Rows[0];
                                response.Nomb_oficial = Convert.ToString(row["NOMBRE_OFICIAL"]);
                                response.Agencia = Convert.ToString(row["AGENCIA"]);
                                response.Sucursal = Convert.ToString(row["SUCURSAL"]);
                                response.NPrestamo = Convert.ToInt64(row["NPRESTAMO"]);
                                response.ticket = Convert.ToInt64(row["TICKET"]);
                                response.PrimFecha = Convert.ToString(row["PRIMERA_FECHA"]);
                                response.CorreoPlataforma = Convert.ToString(row["CORREO_PLATAFORMA"]);
                                response.CorreoOficial = Convert.ToString(row["CORREO_OFICIAL"]);
                                response.Id_Solicitud = Convert.ToInt64(row["ID_SOLICITUD"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                        }
                    }
                }
                return response;
            }
        }

        public SpResponseNsoli SpInsertPrest(REQUEST_INFO_INSER_PREST data)
        {
            var response = new SpResponseNsoli();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                using (var cmd = new SqlCommand("SP_INSERT_PRESTAMO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NPRESTAMO", data.NPRESTAMO);
                    cmd.Parameters.AddWithValue("@NCLIENTE", data.NCLIENTE);
                    cmd.Parameters.AddWithValue("@CI", data.CI);
                    cmd.Parameters.AddWithValue("@NOMBRE", data.NOMBRE);
                    cmd.Parameters.AddWithValue("@NCUENTA", data.NCUENTA);
                    cmd.Parameters.AddWithValue("@APTO", "Verificando");
                    cmd.Parameters.AddWithValue("@MON_AP", 0);
                    cmd.Parameters.AddWithValue("@NTRANSACCION", 0);
                    cmd.Parameters.AddWithValue("@TIPO_PRESTAMO", data.TIPO_PRESTAMO);


                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                var row = dt.Rows[0];
                                response.N_Solicitud = Convert.ToInt64(row["ID_PRESTAMO"]);

                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                        }
                    }
                }
            }
            return response;
        }

        public SpFullInfoPrestamoResponse SpUpdatePrestApto(REQUEST_INFO_UPDATE_PREST_APTO data)
        {
            var response = new SpFullInfoPrestamoResponse();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                using (var cmd = new SqlCommand("SP_UPDATE_PRESTAMO_APTO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PRESTAMO", data.ID_PRESTAMO);
                    cmd.Parameters.AddWithValue("@APTO", data.APTO);
                    cmd.Parameters.AddWithValue("@NTRANSACCION", data.NTRANSACCION);
                    cmd.Parameters.AddWithValue("@MON_AP", data.MON_AP);
                    cmd.Parameters.AddWithValue("@TIPO_PRESTAMO", data.TIPO_PRESTAMO);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                var row = dt.Rows[0];
                                response.ID_PRESTAMO = Convert.ToInt64(row["ID_PRESTAMO"]);
                                response.NPRESTAMO = Convert.ToInt64(row["NPRESTAMO"]);
                                response.NCLIENTE = Convert.ToInt64(row["NCLIENTE"]);
                                response.CI = Convert.ToString(row["CI"]);
                                response.NOMBRE = Convert.ToString(row["NOMBRE"]);
                                response.NCUENTA = Convert.ToInt64(row["NCUENTA"]);
                                response.APTO = Convert.ToString(row["APTO"]);
                                response.MON_AP = Convert.ToInt64(row["MON_AP"]);
                                response.NTRANSACCION = Convert.ToInt64(row["NTRANSACCION"]);
                                response.TIPO_PRESTAMO = Convert.ToString(row["TIPO_PRESTAMO"]);
                                response.ID_SOLICITUD = Convert.ToInt64(row["ID_SOLICITUD"]);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception
                        }
                    }
                }
                return response;
            }
        }

        public ResponseModel SpUpdateSol() //EL SP NO SE ENCUENTRA !!!
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_UPDATE_SOLICITUD", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Datos.TICKET = Convert.ToInt64(dr["TICKET"]);
                        Datos.NPRESTAMO = Convert.ToInt64(dr["NPRESTAMO"]);
                        Datos.RES_BUROS = Convert.ToString(dr["RES_BUROS"]);
                        Datos.RES_PCCU = Convert.ToString(dr["RES_PCCU"]);
                    }
                }
            }
            return Datos;
        }
        //----------------
        public Int64? SolicitudPccu()
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                string sql = "select TICKET from SOLICITUD_PCCU where  PROCESADO='NO' AND TICKET NOT IN (SELECT TICKET FROM SOLICITUD_PCCU WHERE ESTADO='PENDIENTE') GROUP BY   TICKET";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Datos.TICKET = Convert.ToInt64(reader["TICKET"]);
                            //Datos.NPRESTAMO = Convert.ToInt64(reader["NPRESTAMO"]);
                            //Datos.RES_BUROS = Convert.ToString(reader["RES_BUROS"]);
                            //Datos.RES_PCCU = Convert.ToString(reader["RES_PCCU"]);
                        }
                    }
                }
            }
            return Datos.TICKET;
        }

        public bool insertPlan(REQUEST_TICKET data)
        {
            bool resp = false;
            // var queryData = data.ToString();
            string sqlText = "INSERT INTO [PLAN] (TICKET,PLAN_DE_PAGOS,VOUCHER,ESTADO) VALUES ('" + data.ticket + "','','','ESPERA')";
            try
            {
                var cn = new ConnectionDesembolsos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    SqlCommand sqlCmd = new SqlCommand(sqlText, conexion);
                    int j = sqlCmd.ExecuteNonQuery();
                }
                resp = true;
            }
            catch (Exception ex)
            {
                resp = false;
                string mensaje = ex.Message.ToString();
            }
            return resp;
        }

        public ResponseModel PccuPendiente(REQUEST_TICKET_AS_INT data)
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                string sql = "SELECT ESTADO FROM SOLICITUD_PCCU WHERE TICKET='" + data.ticket + "' AND (ESTADO='NO' or ESTADO='OK') AND PROCESADO='NO'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            /*Datos.TICKET = Convert.ToInt64(reader["TICKET"]);
                            Datos.NPRESTAMO = Convert.ToInt64(reader["NPRESTAMO"]);
                            Datos.RES_BUROS = Convert.ToString(reader["RES_BUROS"]);
                            Datos.RES_PCCU = Convert.ToString(reader["RES_PCCU"]);*/
                        }
                    }
                }
            }
            return Datos;
        }

        public ResponseModel PccuACEPTADO(REQUEST_TICKET_AS_INT data)
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                string sql = "UPDATE SOLICITUD  SET  RES_PCCU='ACEPTADO' WHERE TICKET ='" + data.ticket + "'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Datos.TICKET = Convert.ToInt64(reader["TICKET"]);
                            Datos.NPRESTAMO = Convert.ToInt64(reader["NPRESTAMO"]);
                            Datos.RES_BUROS = Convert.ToString(reader["RES_BUROS"]);
                            Datos.RES_PCCU = Convert.ToString(reader["RES_PCCU"]);
                        }
                    }
                }
            }
            return Datos;
        }

        public ResponseModel PccuProcesado(REQUEST_TICKET_AS_INT data)
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                string sql = "UPDATE SOLICITUD_PCCU  SET  PROCESADO = 'SI' WHERE TICKET ='" + data.ticket + "'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Datos.TICKET = Convert.ToInt64(reader["TICKET"]);
                            Datos.NPRESTAMO = Convert.ToInt64(reader["NPRESTAMO"]);
                            Datos.RES_BUROS = Convert.ToString(reader["RES_BUROS"]);
                            Datos.RES_PCCU = Convert.ToString(reader["RES_PCCU"]);
                        }
                    }
                }
            }
            return Datos;
        }

        public ResponseModel PccuError(REQUEST_TICKET_AS_INT data)
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                string sql = "UPDATE SOLICITUD  SET   RES_PCCU='FALLIDO' WHERE TICKET ='" + data.ticket + "'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Datos.TICKET = Convert.ToInt64(reader["TICKET"]);
                            Datos.NPRESTAMO = Convert.ToInt64(reader["NPRESTAMO"]);
                            Datos.RES_BUROS = Convert.ToString(reader["RES_BUROS"]);
                            Datos.RES_PCCU = Convert.ToString(reader["RES_PCCU"]);
                        }
                    }
                }
            }
            return Datos;
        }

        public ResponseModel solicitudCompara(REQUEST_TICKET_AND_CI data)
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                string sql = "UPDATE SOLICITUD set COMPARA_CI='" + data.ci + "'  where ticket ='" + data.ticket + "'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Datos.TICKET = Convert.ToInt64(reader["TICKET"]);
                            Datos.NPRESTAMO = Convert.ToInt64(reader["NPRESTAMO"]);
                            Datos.RES_BUROS = Convert.ToString(reader["RES_BUROS"]);
                            Datos.RES_PCCU = Convert.ToString(reader["RES_PCCU"]);
                        }
                    }
                }
            }
            return Datos;
        }

        public ResponseModel solicitudProcesado(REQUEST_ID data)
        {
            var Datos = new ResponseModel();
            var cn = new ConnectionDesembolsos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                string sql = "update SOLICITUD set ESTADO='PROCESADO' WHERE ID_SOLICITUD='" + data.id + "'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Datos.TICKET = Convert.ToInt64(reader["TICKET"]);
                            Datos.NPRESTAMO = Convert.ToInt64(reader["NPRESTAMO"]);
                            Datos.RES_BUROS = Convert.ToString(reader["RES_BUROS"]);
                            Datos.RES_PCCU = Convert.ToString(reader["RES_PCCU"]);
                        }
                    }
                }
            }
            return Datos;
        }

        //ApisBuros

        public bool SpInserReconGrp(REQUEST_INSER_RECONSULTA_GRUPO data)
        {

            var cn = new ConnectionBuros();
            using (var conexion = new SqlConnection(cn.get_cadConexionBuros()))
            {
                using (var cmd = new SqlCommand("INSERT_RECONSULTA_GRUPO", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ticket", data.TICKET);
                    cmd.Parameters.AddWithValue("@para_correo", data.PARA_CORREO);
                    cmd.Parameters.AddWithValue("@usuario", data.USUARIO);
                    cmd.Parameters.AddWithValue("@agencia", data.AGENCIA);
                    cmd.Parameters.AddWithValue("@id_solicitud", data.ID_SOLICITUD);


                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        try
                        {

                            return true;

                            //Siempre devuelve true, comfirmar que es necesario llenar los parametros
                        }
                        catch (Exception ex)
                        {
                            return false;
                        }
                    }
                }
            }

        }

        public List<SpSlctConPccu> SpSelecConsPccu(REQUEST_TICKET_AS_INT data)
        {
            {

                List<SpSlctConPccu> responseList = new List<SpSlctConPccu>();
                var cn = new ConnectionBuros();
                using (var conexion = new SqlConnection(cn.get_cadConexionBuros()))
                {
                    using (var cmd = new SqlCommand("SP_SELECT_CONSULTA_PCCU", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TICKET", data.ticket);

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            try
                            {
                                var dt = new DataTable();
                                adapter.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        var response = new SpSlctConPccu();
                                        response.TIKET = Convert.ToInt64(dt.Rows[i]["TIKET"]);
                                        response.ID_PERSONA = Convert.ToInt64(dt.Rows[i]["ID_PERSONA"]);
                                        response.PATERNO = Convert.ToString(dt.Rows[i]["PATERNO"]);
                                        response.MATERNO = Convert.ToString(dt.Rows[i]["MATERNO"]);
                                        response.AP_CASADA = Convert.ToString(dt.Rows[i]["AP_CASADA"]);
                                        response.NOMBRE = Convert.ToString(dt.Rows[i]["NOMBRE"]);
                                        response.NOMBRE = Convert.ToString(dt.Rows[i]["NOMBRE"]);
                                        response.CI = Convert.ToString(dt.Rows[i]["CI"]);
                                        response.usuario = Convert.ToString(dt.Rows[i]["usuario"]);
                                        response.para_correo = Convert.ToString(dt.Rows[i]["para_correo"]);
                                        response.agencia = Convert.ToString(dt.Rows[i]["agencia"]);
                                        responseList.Add(response);
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                // Handle the exception
                            }
                        }
                    }
                    return responseList;
                }
            }
        }

        public CI_RESPONSE getCiPersona(REQUEST_TICKET_AS_INT data)
        {
            var response = new CI_RESPONSE();
            var cn = new ConnectionBuros();
            using (var conexion = new SqlConnection(cn.get_cadConexionBuros()))
            {
                conexion.Open();
                string sql = "select CI from PERSONA where tipo='TITULAR' and tiket ='" + data.ticket + "'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ci = Convert.ToString(reader["CI"]);

                        }
                    }
                }
            }
            return response;
        }

        public CI_RESPONSE getCiPersona2(REQUEST_TICKET_AS_INT data)
        {
            var response = new CI_RESPONSE();
            var cn = new ConnectionBuros();
            using (var conexion = new SqlConnection(cn.get_cadConexionBuros()))
            {
                conexion.Open();
                string sql = "select CI from PERSONA where tipo<>'TITULAR' and tiket ='" + data.ticket + "'";
                using (SqlCommand command = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response.ci = Convert.ToString(reader["CI"]);

                        }
                    }
                }
            }
            return response;
        }
    }
}
