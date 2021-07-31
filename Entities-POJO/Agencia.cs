using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Agencia : BaseEntity
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Id_Usuario { get; set; }
        public string Logo { get; set; }
        public string Estado { get; set; }

        public Agencia() { }

        public Agencia(string[] info)
        {
            Id = info[0];
            Nombre = info[1];
            Tipo = info[2];
            Id_Usuario = info[3];
            Logo = info[4];
            Estado = info[5];
        }
    }
}
