using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Suscripcion : BaseEntity
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad_Anuncios { get; set; }
        public string Periodo_Facturacion { get; set; }
        public string Estado { get; set; }

        public Suscripcion() { }

        public Suscripcion(string[] info)
        {
            Id = info[0];
            Nombre = info[1];
            Cantidad_Anuncios = Convert.ToInt32(info[2]);
            Periodo_Facturacion = info[3];
            Estado = info[4];
        }
    }

   
}
