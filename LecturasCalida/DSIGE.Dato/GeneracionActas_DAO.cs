using DSIGE.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIGE.Dato
{
   public class GeneracionActas_DAO
    {
       string cadenaCnx = System.Configuration.ConfigurationManager.ConnectionStrings["dataSige"].ConnectionString;


       public List<GeneracionActas_E> Capa_Dato_Servicios()
       {
           try
           {
               List<GeneracionActas_E> list_obj = new List<GeneracionActas_E>();
               string ruta = ConfigurationManager.AppSettings["servidor-foto-lectura"];

               using (SqlConnection cn = new SqlConnection(cadenaCnx))
               {
                   cn.Open();

                   using (SqlCommand cmd = new SqlCommand("SP_S_ACTAS_SERVICIOS", cn))
                   {
                       cmd.CommandTimeout = 0;
                       cmd.CommandType = CommandType.StoredProcedure;

                       DataTable dt_detalle = new DataTable();
                       using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                       {
                           da.Fill(dt_detalle);
                           foreach (DataRow Fila in dt_detalle.Rows)
                           {
                               GeneracionActas_E obj_entidad = new GeneracionActas_E();

                               obj_entidad.id_TipoServicio = Convert.ToInt32(Fila["id_TipoServicio"].ToString());
                               obj_entidad.nombre_tiposervicio = Fila["nombre_tiposervicio"].ToString();
                               list_obj.Add(obj_entidad);
                           }
                       }
                   }
               }

               return list_obj;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public List<GeneracionActas_E> Capa_Dato_Servicios_all()
        {
            try
            {
                List<GeneracionActas_E> list_obj = new List<GeneracionActas_E>();
                string ruta = ConfigurationManager.AppSettings["servidor-foto-lectura"];

                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_CHECK_LIST_SERVICIOS", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                            foreach (DataRow Fila in dt_detalle.Rows)
                            {
                                GeneracionActas_E obj_entidad = new GeneracionActas_E();

                                obj_entidad.id_TipoServicio = Convert.ToInt32(Fila["id_TipoServicio"].ToString());
                                obj_entidad.nombre_tiposervicio = Fila["nombre_tiposervicio"].ToString();
                                list_obj.Add(obj_entidad);
                            }
                        }
                    }
                }

                return list_obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<GeneracionActas_E> Capa_Dato_Mostrando_informacion_general(int servicio, int operario, string fecha)
       {
           try
           {
               List<GeneracionActas_E> ListArchivos = new List<GeneracionActas_E>();
               string ruta = ConfigurationManager.AppSettings["servidor-foto-lectura"];

               using (SqlConnection cn = new SqlConnection(cadenaCnx))
               {
                   cn.Open();

                   using (SqlCommand cmd = new SqlCommand("SP_S_ACTAS_LISTAR_NEW", cn))
                   {
                       cmd.CommandTimeout = 0;
                       cmd.CommandType = CommandType.StoredProcedure;
                       cmd.Parameters.Add("@id_servicio", SqlDbType.Int).Value = servicio;
                       cmd.Parameters.Add("@id_operario", SqlDbType.Int).Value = operario;
                       cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;

                       DataTable dt_detalle = new DataTable();
                       using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                       {
                           da.Fill(dt_detalle);
                           foreach (DataRow Fila in dt_detalle.Rows)
                           {
                               GeneracionActas_E obj_entidad = new GeneracionActas_E();


                                if (servicio == 3)
                                {
                                    obj_entidad.id_TipoServicio = Convert.ToInt32(Fila["id_TipoServicio"].ToString());
                                    obj_entidad.fecha = Fila["fecha"].ToString();
                                    obj_entidad.hora = Fila["hora"].ToString();
                                    obj_entidad.fechaLecturaMovil_corte = Fila["fechaLecturaMovil_corte"].ToString();
                                    obj_entidad.cliente_suministro = Fila["cliente_suministro"].ToString();
                                    obj_entidad.instalacion = Fila["instalacion"].ToString();
                                    obj_entidad.medidor = Fila["medidor"].ToString();


                                    obj_entidad.ubicacion_medidor_interno = Fila["ubicacion_medidor_interno"].ToString();
                                    obj_entidad.ubicacion_medidor_externo = Fila["ubicacion_medidor_externo"].ToString();

                                    obj_entidad.nombre_cliente = Fila["nombre_cliente"].ToString();
                                    obj_entidad.direccion_suministro = Fila["direccion_suministro"].ToString();

                                    obj_entidad.distrito = Fila["distrito"].ToString();
                                    obj_entidad.nombre_personal = Fila["nombre_personal"].ToString();
                                    obj_entidad.dni_personal = Fila["dni_personal"].ToString();
                                    obj_entidad.lectura_cierre = Fila["lectura_cierre"].ToString();

                                    obj_entidad.motivo_cierre_deuda = Fila["motivo_cierre_deuda"].ToString();
                                    obj_entidad.motivo_cierre_fuga_gas = Fila["motivo_cierre_fuga_gas"].ToString();
                                    obj_entidad.motivo_cierre_pedido_cliente = Fila["motivo_cierre_pedido_cliente"].ToString();
                                    obj_entidad.motivo_cierre_seguridad = Fila["motivo_cierre_seguridad"].ToString();

                                    obj_entidad.resultado_cierre_ejecutado = Fila["resultado_cierre_ejecutado"].ToString();
                                    obj_entidad.resultado_cierre_ausente = Fila["resultado_cierre_ausente"].ToString();
                                    obj_entidad.resultado_cierre_acceso = Fila["resultado_cierre_acceso"].ToString();
                                    obj_entidad.resultado_cierre_resistencia = Fila["resultado_cierre_resistencia"].ToString();

                                    obj_entidad.observaciones = Fila["observaciones"].ToString();

                                    obj_entidad.ruta_foto_1 = ruta + Fila["ruta_foto_1"].ToString();
                                    obj_entidad.ruta_foto_2 = ruta + Fila["ruta_foto_2"].ToString();
                                    obj_entidad.ruta_foto_3 = ruta + Fila["ruta_foto_3"].ToString();
                                    obj_entidad.ruta_foto_4 = ruta + Fila["ruta_foto_4"].ToString();
                                }
                                else {

                                    obj_entidad.id_TipoServicio = Convert.ToInt32(Fila["id_TipoServicio"].ToString());
                                    obj_entidad.fecha = Fila["fecha"].ToString();
                                    obj_entidad.hora = Fila["hora"].ToString();
                                    obj_entidad.fechaLecturaMovil_corte = Fila["fechaLecturaMovil_corte"].ToString();
                                    obj_entidad.cliente_suministro = Fila["cliente_suministro"].ToString();
                                    obj_entidad.instalacion = Fila["instalacion"].ToString();
                                    obj_entidad.medidor = Fila["medidor"].ToString();


                                    obj_entidad.ubicacion_medidor_interno = Fila["ubicacion_medidor_interno"].ToString();
                                    obj_entidad.ubicacion_medidor_externo = Fila["ubicacion_medidor_externo"].ToString();

                                    obj_entidad.nombre_cliente = Fila["nombre_cliente"].ToString();
                                    obj_entidad.direccion_suministro = Fila["direccion_suministro"].ToString();

                                    obj_entidad.distrito = Fila["distrito"].ToString();
                                    obj_entidad.nombre_personal = Fila["nombre_personal"].ToString();
                                    obj_entidad.dni_personal = Fila["dni_personal"].ToString();
                                    obj_entidad.lectura_cierre = Fila["lectura_cierre"].ToString();

                                    obj_entidad.motivo_deuda = Fila["motivo_deuda"].ToString();
                                    obj_entidad.motivo_apc = Fila["motivo_apc"].ToString();
                                    obj_entidad.motivo_tecnico = Fila["motivo_tecnico"].ToString();
                                    obj_entidad.motivo_otros = Fila["motivo_otros"].ToString();

                                    obj_entidad.recone_exitosa = Fila["recone_exitosa"].ToString();
 
                                    obj_entidad.artefac_cocina = Fila["artefac_cocina"].ToString();
                                    obj_entidad.artefac_terma = Fila["artefac_terma"].ToString();
                                    obj_entidad.artefac_secadora = Fila["artefac_secadora"].ToString();
                                    obj_entidad.artefac_estufa = Fila["artefac_estufa"].ToString();
   
                                    obj_entidad.recone_infrutuosa = Fila["recone_infrutuosa"].ToString();
                                    obj_entidad.motivo_cliente_ausente = Fila["motivo_cliente_ausente"].ToString();
                                    obj_entidad.motivo_cliente_impide = Fila["motivo_cliente_impide"].ToString();

                                    obj_entidad.motivo_cliente_otros = Fila["motivo_cliente_otros"].ToString();
                                    obj_entidad.primera_visita_recone = Fila["primera_visita_recone"].ToString();
                                    obj_entidad.proxima_visita_fecha_check = Fila["proxima_visita_fecha_check"].ToString();
                                    obj_entidad.proxima_visita_fecha = Fila["proxima_visita_fecha"].ToString();
                                    obj_entidad.proxima_visita_hora = Fila["proxima_visita_hora"].ToString();
                                    obj_entidad.proxima_visita_solicita = Fila["proxima_visita_solicita"].ToString();

                                    obj_entidad.observaciones = Fila["observaciones"].ToString();

                                    if (verificarExisteFile(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/foto/foto/" +  Fila["ruta_foto_1"].ToString())))
                                    {
                                        obj_entidad.ruta_foto_1 = ruta + Fila["ruta_foto_1"].ToString();
                                    }
                                    else {
                                        obj_entidad.ruta_foto_1 = ruta + "Firm(O)_vacio.jpg";
                                    }

                                    if (verificarExisteFile(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/foto/foto/" +  Fila["ruta_foto_2"].ToString())))
                                    {
                                        obj_entidad.ruta_foto_2 = ruta + Fila["ruta_foto_2"].ToString();
                                    }
                                    else
                                    {
                                        obj_entidad.ruta_foto_2 = ruta + "Firm(C)_vacio.jpg";
                                    }

                                    obj_entidad.nombre_usuario = Fila["nombre_usuario"].ToString();
                                    obj_entidad.nroDoc_usuario = Fila["nroDoc_usuario"].ToString();

                                }
                            ListArchivos.Add(obj_entidad);
                           }
                       }
                   }
               }

               return ListArchivos;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }



        public List<GeneracionActas_E> Capa_Dato_Mostrando_informacion_Actas_masivas(int servicio, int operario, string fecha, string id_fecha_final)
        {
            try
            {
                List<GeneracionActas_E> ListArchivos = new List<GeneracionActas_E>();
                string ruta = ConfigurationManager.AppSettings["servidor-foto-lectura"];

                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_ACTAS_LISTAR_MASIVOS", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_servicio", SqlDbType.Int).Value = servicio;
                        cmd.Parameters.Add("@id_operario", SqlDbType.Int).Value = operario;
                        cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;
                        cmd.Parameters.Add("@fecha_final", SqlDbType.VarChar).Value = id_fecha_final;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                            foreach (DataRow Fila in dt_detalle.Rows)
                            {
                                GeneracionActas_E obj_entidad = new GeneracionActas_E();


                                if (servicio == 3)
                                {

                                    obj_entidad.id_Corte = Convert.ToInt32(Fila["id_Corte"].ToString());
                                    obj_entidad.id_TipoServicio = Convert.ToInt32(Fila["id_TipoServicio"].ToString());
                                    obj_entidad.fecha = Fila["fecha"].ToString();
                                    obj_entidad.hora = Fila["hora"].ToString();
                                    obj_entidad.fechaLecturaMovil_corte = Fila["fechaLecturaMovil_corte"].ToString();
                                    obj_entidad.cliente_suministro = Fila["cliente_suministro"].ToString();
                                    obj_entidad.instalacion = Fila["instalacion"].ToString();
                                    obj_entidad.medidor = Fila["medidor"].ToString();

                                    obj_entidad.ubicacion_medidor_interno = Fila["ubicacion_medidor_interno"].ToString();
                                    obj_entidad.ubicacion_medidor_externo = Fila["ubicacion_medidor_externo"].ToString();

                                    obj_entidad.nombre_cliente = Fila["nombre_cliente"].ToString();
                                    obj_entidad.direccion_suministro = Fila["direccion_suministro"].ToString();

                                    obj_entidad.distrito = Fila["distrito"].ToString();
                                    obj_entidad.nombre_personal = Fila["nombre_personal"].ToString();
                                    obj_entidad.dni_personal = Fila["dni_personal"].ToString();
                                    obj_entidad.lectura_cierre = Fila["lectura_cierre"].ToString();

                                    obj_entidad.motivo_cierre_deuda = Fila["motivo_cierre_deuda"].ToString();
                                    obj_entidad.motivo_cierre_fuga_gas = Fila["motivo_cierre_fuga_gas"].ToString();
                                    obj_entidad.motivo_cierre_pedido_cliente = Fila["motivo_cierre_pedido_cliente"].ToString();
                                    obj_entidad.motivo_cierre_seguridad = Fila["motivo_cierre_seguridad"].ToString();

                                    obj_entidad.resultado_cierre_ejecutado = Fila["resultado_cierre_ejecutado"].ToString();
                                    obj_entidad.resultado_cierre_ausente = Fila["resultado_cierre_ausente"].ToString();
                                    obj_entidad.resultado_cierre_acceso = Fila["resultado_cierre_acceso"].ToString();
                                    obj_entidad.resultado_cierre_resistencia = Fila["resultado_cierre_resistencia"].ToString();

                                    obj_entidad.observaciones = Fila["observaciones"].ToString();
                                    obj_entidad.ruta_foto_1 = ruta + Fila["ruta_foto_1"].ToString();
                                }
                                else
                                {

                                    obj_entidad.id_Corte = Convert.ToInt32(Fila["id_Corte"].ToString());
                                    obj_entidad.id_TipoServicio = Convert.ToInt32(Fila["id_TipoServicio"].ToString());
                                    obj_entidad.fecha = Fila["fecha"].ToString();
                                    obj_entidad.hora = Fila["hora"].ToString();
                                    obj_entidad.fechaLecturaMovil_corte = Fila["fechaLecturaMovil_corte"].ToString();
                                    obj_entidad.cliente_suministro = Fila["cliente_suministro"].ToString();
                                    obj_entidad.instalacion = Fila["instalacion"].ToString();
                                    obj_entidad.medidor = Fila["medidor"].ToString();


                                    obj_entidad.ubicacion_medidor_interno = Fila["ubicacion_medidor_interno"].ToString();
                                    obj_entidad.ubicacion_medidor_externo = Fila["ubicacion_medidor_externo"].ToString();

                                    obj_entidad.nombre_cliente = Fila["nombre_cliente"].ToString();
                                    obj_entidad.direccion_suministro = Fila["direccion_suministro"].ToString();

                                    obj_entidad.distrito = Fila["distrito"].ToString();
                                    obj_entidad.nombre_personal = Fila["nombre_personal"].ToString();
                                    obj_entidad.dni_personal = Fila["dni_personal"].ToString();
                                    obj_entidad.lectura_cierre = Fila["lectura_cierre"].ToString();

                                    obj_entidad.motivo_deuda = Fila["motivo_deuda"].ToString();
                                    obj_entidad.motivo_apc = Fila["motivo_apc"].ToString();
                                    obj_entidad.motivo_tecnico = Fila["motivo_tecnico"].ToString();
                                    obj_entidad.motivo_otros = Fila["motivo_otros"].ToString();

                                    obj_entidad.recone_exitosa = Fila["recone_exitosa"].ToString();

                                    obj_entidad.artefac_cocina = Fila["artefac_cocina"].ToString();
                                    obj_entidad.artefac_terma = Fila["artefac_terma"].ToString();
                                    obj_entidad.artefac_secadora = Fila["artefac_secadora"].ToString();
                                    obj_entidad.artefac_estufa = Fila["artefac_estufa"].ToString();

                                    obj_entidad.recone_infrutuosa = Fila["recone_infrutuosa"].ToString();
                                    obj_entidad.motivo_cliente_ausente = Fila["motivo_cliente_ausente"].ToString();
                                    obj_entidad.motivo_cliente_impide = Fila["motivo_cliente_impide"].ToString();

                                    obj_entidad.motivo_cliente_otros = Fila["motivo_cliente_otros"].ToString();
                                    obj_entidad.primera_visita_recone = Fila["primera_visita_recone"].ToString();
                                    obj_entidad.proxima_visita_fecha_check = Fila["proxima_visita_fecha_check"].ToString();
                                    obj_entidad.proxima_visita_fecha = Fila["proxima_visita_fecha"].ToString();
                                    obj_entidad.proxima_visita_hora = Fila["proxima_visita_hora"].ToString();
                                    obj_entidad.proxima_visita_solicita = Fila["proxima_visita_solicita"].ToString();

                                    obj_entidad.observaciones = Fila["observaciones"].ToString();

                                    if (verificarExisteFile(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/foto/foto/" + Fila["ruta_foto_1"].ToString())))
                                    {
                                        obj_entidad.ruta_foto_1 = ruta + Fila["ruta_foto_1"].ToString();
                                    }
                                    else
                                    {
                                        obj_entidad.ruta_foto_1 = ruta + "Firm(O)_vacio.jpg";
                                    }

                                    if (verificarExisteFile(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/foto/foto/" + Fila["ruta_foto_2"].ToString())))
                                    {
                                        obj_entidad.ruta_foto_2 = ruta + Fila["ruta_foto_2"].ToString();
                                    }
                                    else
                                    {
                                        obj_entidad.ruta_foto_2 = ruta + "Firm(C)_vacio.jpg";
                                    }

                                }
                                ListArchivos.Add(obj_entidad);
                            }
                        }
                    }
                }

                return ListArchivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool verificarExisteFile(string rutaFile) {

            if (File.Exists(rutaFile))
            {
                return true;
            }
            else {
                return false;
            }
        }



        public List<Inspecciones_E> Capa_Dato_Mostrando_informacion_Inspecciones(int servicio, int operario, string fecha, int tipoReporte)
        {
            try
            {
                List<Inspecciones_E> ListArchivos = new List<Inspecciones_E>();
                string ruta = ConfigurationManager.AppSettings["servidor-foto-lectura"];

                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("PROC_CKECK_LIST_CAB", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_servicio", SqlDbType.Int).Value = servicio;
                        cmd.Parameters.Add("@id_operario", SqlDbType.Int).Value = operario;
                        cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;
                        cmd.Parameters.Add("@tipoReporte", SqlDbType.Int).Value = tipoReporte;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                            foreach (DataRow Fila in dt_detalle.Rows)
                            {
                                Inspecciones_E obj_entidad = new Inspecciones_E();
 
                                obj_entidad.id_Inspeccion = Convert.ToInt32(Fila["id_Inspeccion"].ToString());
                                obj_entidad.id_Operario_Lectura = Convert.ToInt32(Fila["id_Operario_Lectura"].ToString());
                                obj_entidad.nro_Inspeccion = Fila["nro_Inspeccion"].ToString();
                                obj_entidad.fecha_inspeccion = Fila["fecha_inspeccion"].ToString();
                                obj_entidad.operario = Fila["operario"].ToString();
                                ListArchivos.Add(obj_entidad);
                            }
                        }
                    }
                }

                return ListArchivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable Capa_Dato_Mostrando_informacion_InspeccionesMasivas(int servicio, int operario, string fecha, string fechaFinal, int tipoReporte)
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("PROC_S_REPORTE_INSPECCIONES_EPP_MASIVO", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_servicio", SqlDbType.Int).Value = servicio;
                        cmd.Parameters.Add("@id_operario", SqlDbType.Int).Value = operario;
                        cmd.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha;
                        cmd.Parameters.Add("@fechaFinal", SqlDbType.VarChar).Value = fechaFinal;
                        cmd.Parameters.Add("@tipoReporte", SqlDbType.Int).Value = tipoReporte;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                    }
                }
                return dt_detalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Capa_dato_get_generacionPdf_inspecciones(int id_inspeccion, int tipoReporte)
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("DSIGE_Reporte_Inspeccion", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_inspeccion", SqlDbType.Int).Value = id_inspeccion;
                        cmd.Parameters.Add("@tipo_Reporte", SqlDbType.Int).Value = tipoReporte;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);                      
                        }
                    }
                }
                return dt_detalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
         
         

        public DataTable Capa_dato_get_generacionPdf_checkList(int id_inspeccion, int tipoReporte)
        {
            DataTable dt_detalle = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("PROC_S_REPORTE_INSPECCIONES_EPP", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_inspeccion", SqlDbType.Int).Value = id_inspeccion;
                        cmd.Parameters.Add("@tipo_Reporte", SqlDbType.Int).Value = tipoReporte;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                        }
                    }
                }
                return dt_detalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Inspecciones_E> Capa_Dato_getAreas()
        {
            try
            {
                List<Inspecciones_E> list_obj = new List<Inspecciones_E>();
                using (SqlConnection cn = new SqlConnection(cadenaCnx))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_S_AREAS", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dt_detalle = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt_detalle);
                            foreach (DataRow Fila in dt_detalle.Rows)
                            {
                                Inspecciones_E obj_entidad = new Inspecciones_E();

                                obj_entidad.id_Area = Convert.ToInt32(Fila["id_Area"].ToString());
                                obj_entidad.nombre_area = Fila["nombre_area"].ToString();
                                list_obj.Add(obj_entidad);
                            }
                        }
                    }
                }

                return list_obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
