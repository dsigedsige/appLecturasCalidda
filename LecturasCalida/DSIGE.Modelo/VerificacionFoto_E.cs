using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIGE.Modelo
{
    public class VerificacionFoto_E
    {
 
        public bool checkeado { get; set; }
        public int id_TipoServicio { get; set; }
        public string nombre_tiposervicio { get; set; }
        public int estado { get; set; }  

        public int id_Operario { get; set; }
        public string desc_operario { get; set; }
        public string foto { get; set; }
        public string url { get; set; }

        public string Sector { get; set; }

        public int id_Observacion { get; set; }
        public string descripcion_observacion { get; set; }      
                
        public int id_Lectura { get; set; }  
        public string suministro_lectura { get; set; }  
        public string medidor_lectura { get; set; }
        public string id_Operario_Lectura { get; set; }
        public string operario { get; set; }
        public string token { get; set; }          

        public string fotourl  { get; set; }  
        public string latitud_lectura  { get; set; }
        public string longitud_lectura { get; set; }
        public string lectura_movil { get; set; }
        public int id_fotoLectura { get; set; }     

        public bool existeFoto { get; set; }

        public int id_ubicacion { get; set; }
        public string ubicacion_medidor { get; set; }

    }


    public class HistorialFotos_sumistro
    {
         public int  idLectura { get; set; }
         public string  idCorte { get; set; }
         public string  fechaAsignacion { get; set; }
         public string  desripcionServicio { get; set; }
         public string  suministro { get; set; }
         public string  lecturaMovil { get; set; }
         public string descripcionObservacion { get; set; }
         public string  fechaMovil { get; set; }
         public string  fotoUrl { get; set; }
         public string  latitud { get; set; }
         public string longitud { get; set; } 

    }

}
