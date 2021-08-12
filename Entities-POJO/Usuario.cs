using System;
using System.ComponentModel.DataAnnotations;

namespace Entities_POJO
{
    public class Usuario : BaseEntity
    {
        public string Id { get; set; }
        public string Tipo_Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Fecha_Nac { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su contraseña.")]
        public string Contrasenna { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Dirección de correo inválida")]
        public string Email { get; set; }
        public string Estado { get; set; }
        public int Telefono { get; set; }
        public int Cod_Email { get; set; }
        public int Cod_Celular { get; set; }
        public string Id_Rol { get; set; }
        public string Id_Agencia { get; set; }
        public char Verificado { get; set; }
        public string Nombre_Rol { get; set; }
        public string Mensaje { get; set; }

        public Usuario() { }

        public Usuario(string[] info) {
            Id = info[0];
            Tipo_Id = info[1];
            Nombre = info[2];
            Apellidos = info[3];
            Fecha_Nac = DateTime.Parse(info[4]);
            Contrasenna = info[5];
            Email = info[6];
            Estado = info[7];
            Telefono = Convert.ToInt32(info[8]);
            Cod_Email = Convert.ToInt32(info[9]);
            Cod_Celular = Convert.ToInt32(info[10]);
            Id_Rol = info[11];
            Id_Agencia = info[12];
            Verificado = Convert.ToChar(info[13]);
            Nombre_Rol = info[14];
            Mensaje = info[15];
        }
        public enum TipoId
        {
            Física,
            Jurídica,
            Dimex
        }

        public static explicit operator Usuario(Cuenta v)
        {
            var usuario = new Usuario();

            {
                usuario.Id = v.ID;
                usuario.Tipo_Id = v.TIPO_ID;
                usuario.Nombre = v.NOMBRE;
                usuario.Apellidos = v.APELLIDOS;
                usuario.Fecha_Nac = v.FECHA_NAC;
                usuario.Contrasenna = v.CONTRASENNA;
                usuario.Email = v.EMAIL;
                usuario.Estado = v.ESTADO;
                usuario.Telefono = v.TELEFONO;
                usuario.Cod_Email = v.COD_EMAIL;
                usuario.Cod_Celular = v.COD_CEL;
                usuario.Id_Rol = v.ID_ROL;
                usuario.Id_Agencia = v.ID_AGENCIA;
                usuario.Verificado = Convert.ToChar(v.VERIFICADO);
                usuario.Nombre_Rol = v.Nombre_Rol;
            };

            return usuario;
        }
    }

    
}
