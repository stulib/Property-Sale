﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Usuario : BaseEntity
    {
        public string Id { get; set; }
        public string Tipo_Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Contrasenna { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public int Telefono { get; set; }
        public int Cod_Email { get; set; }
        public int Cod_Celular { get; set; }
        public string Id_Suscripcion { get; set; }
        public string Id_Rol { get; set; }
        public string Id_Agencia { get; set; }
        public char Verificado { get; set; }
        public string Rol { get; set; }

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
            Id_Suscripcion = info[11];
            Id_Rol = info[12];
            Id_Agencia = info[13];
            Verificado = Convert.ToChar(info[14]);
        }
    }
}
