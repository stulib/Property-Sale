using System;
using System.ComponentModel.DataAnnotations;

namespace Entities_POJO
{
    public class Cuenta : BaseEntity
    {

        public string TIPO_ID { get; set; }

        public string ID { get; set; }

        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }

        public DateTime? FECHA_NAC { get; set; }
        public string CONTRASENNA { get; set; }

        [Display(Name = "Direccion de Correo")]
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Direccion de correo inválida")]
        public string EMAIL { get; set; }
        public string ESTADO { get; set; }
        public int TELEFONO { get; set; }
        public int COD_EMAIL { get; set; }
        public int COD_CEL { get; set; }
        public string ID_ROL { get; set; }
        public string Mensaje { get; set; }
        public string ID_AGENCIA { get; set; }
        public string VERIFICADO { get; set; }
        public string Nombre_Rol { get; set; }

        public Cuenta() { }
        
        public Cuenta(string[] info)
        {
            ID = info[0];
            TIPO_ID = info[1];
            NOMBRE = info[2];
            APELLIDOS = info[3];
            FECHA_NAC = DateTime.Parse(info[4]);
            CONTRASENNA = info[5];
            EMAIL = info[6];
            ESTADO = info[7];
            TELEFONO = Convert.ToInt32(info[8]);
            COD_EMAIL = Convert.ToInt32(info[9]);
            COD_CEL = Convert.ToInt32(info[10]);
            ID_ROL = info[11];
            Mensaje = info[12];
            ID_AGENCIA = info[13];
            VERIFICADO = info[14];
            Nombre_Rol = info[15];

        }



    }
}

