using System;
using System.ComponentModel.DataAnnotations;

namespace Entities_POJO
{
    public class Cuenta : BaseEntity
    {

        public String TIPO_ID { get; set; }

        public String ID { get; set; }

        public String NOMBRE { get; set; }
        public String APELLIDOS { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? FECHA_NAC { get; set; }
        public String CONTRASENNA { get; set; }

        [Display(Name = "Direccion de Correo")]
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Direccion de correo inválida")]
        public String EMAIL { get; set; }
        public String ESTADO { get; set; }
        public int TELEFONO { get; set; }
        public int COD_EMAIL { get; set; }
        public int COD_CEL { get; set; }
        public String ID_ROL { get; set; }
        public String Mensaje { get; set; }
        public String ID_AGENCIA { get; set; }
        public string VERIFICADO { get; set; }
        public string Nombre_Rol { get; set; }

        public static explicit operator Cuenta(Usuario v)
        {
            var cuenta = new Cuenta();

            {
                cuenta.ID = v.Id;
                cuenta.TIPO_ID = v.Tipo_Id;
                cuenta.NOMBRE = v.Nombre;
                cuenta.APELLIDOS = v.Apellidos;
                cuenta.FECHA_NAC = v.Fecha_Nac;
                cuenta.CONTRASENNA = v.Contrasenna;
                cuenta.EMAIL = v.Email;
                cuenta.ESTADO = v.Estado;
                cuenta.TELEFONO = v.Telefono;
                cuenta.COD_EMAIL = v.Cod_Email;
                cuenta.COD_CEL = v.Cod_Celular;
                cuenta.ID_ROL = v.Id_Rol;
                cuenta.ID_AGENCIA = v.Id_Agencia;
                cuenta.VERIFICADO = v.Verificado.ToString();
                cuenta.Nombre_Rol = v.Nombre_Rol;
            };

            return cuenta;
        }
    }
}
