

using DSIGE.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSIGE.Web.Controllers
{
    public class VerificacionFotosController : Controller
    {
        //
        // GET: /CambioEstado/

        public ActionResult VerificacionFotos_index()
        {
            return View();
        }

        public ActionResult VerificacionFotos_CortesReconexion_index()
        {
            return View();
        }



        public static string _Serialize(object value, bool ignore = false)
        {
            var SerializerSettings = new JsonSerializerSettings()
            {
                MaxDepth = Int32.MaxValue,
                NullValueHandling = (ignore == true ? NullValueHandling.Ignore : NullValueHandling.Include)
            };
            return JsonConvert.SerializeObject(value, Formatting.Indented, SerializerSettings);
        }


        [HttpPost]
        public string ListandoServicios()
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaServicios();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListaHistoricoLectura(string suministro)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaHistoricoLectura(suministro);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string ListandoOperarios()
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaOperarios();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoSectores()
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaSector();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoObservaciones()
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaObservacion();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoFotosLecturas(string fecha, int servicio, int operario, int observacion  , int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaFotoLecturas(fecha, servicio, operario, observacion, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string Listando_historicoFotos_suministro(string suministro, string fechaInicial, string fechaFinal, int servicio )
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_get_historicoFotos_suministros(suministro, fechaInicial, fechaFinal, servicio );
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }




        [HttpPost]
        public string ListandoFotosLecturas_sinObs(string fecha, int servicio, int operario, int observacion, int id_supervisor, int id_operario_supervisor)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaFotoLecturas_SinObs(fecha, servicio, operario, observacion, id_supervisor, id_operario_supervisor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string VerificacionFotos(string lecturas)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_VerificacionLecturas(lecturas);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string VerificacionFotos_Inconsistencias(string lecturas)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_VerificacionLecturas_Inconsistencias(lecturas);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string EnviarFotosSinObservacion(string lecturas)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_EnviarFotosSinObservacion(lecturas);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string CambiarLectura(int id_lectura, string confirmacion_lectura)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_CambiarLectura(id_lectura, confirmacion_lectura);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }


        [HttpPost]
        public string Update_LecturaActual(int id_lectura, string lectura_actual)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_Update_LecturaActual(id_lectura, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, lectura_actual);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string MostrandoFotos(int id_lectura)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_MostrarFotos(id_lectura);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }
               
        [HttpPost]
        public string ListandoFotos_cortesReconexiones(string fecha, int servicio, int operario, int observacion, int opcion )
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListandoFotos_cortesReconexiones(fecha, servicio, operario, observacion, opcion);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string ListaHistorico_cortesReconexiones(string suministro)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_ListaHistorico_cortesReconexiones(suministro);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string Update_corteReconexionesActual(int id_lectura, string lectura_actual)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_Update_CorteReconexiones_Actual(id_lectura, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, lectura_actual);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string EnviarFotosSinObservacion_corteReconexion(int idCorte , int idFotoCorte)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_EnviarFotosSinObservacion_corteReconexion(idCorte, idFotoCorte);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        [HttpPost]
        public string VerificacionFotos_corteReconexion(int idCorte)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_Verificacion_corteReconexion(idCorte, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string listando_fotosReconexiones_ubicacionMedidor(string fecha, int servicio, int operario, int observacion, int opcion)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_listando_fotosReconexiones_ubicacionMedidor(fecha, servicio, operario, observacion, opcion);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


        [HttpPost]
        public string actualizar_ubicacionMedidor (int id_corte, string id_ubicacionMedidor)
        {
            object loDatos;
            try
            {
                VerificacionFotos_BL obj_negocio = new VerificacionFotos_BL();
                loDatos = obj_negocio.Capa_Negocio_actualizar_ubicacionMedidor(id_corte, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id, id_ubicacionMedidor);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

    }
}
