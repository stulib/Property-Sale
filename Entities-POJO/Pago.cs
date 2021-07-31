using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Pago : BaseEntity
    {
        
            public string Id { get; set; }
            public string Nombre { get; set; }
            public string Tipo { get; set; }
            public string Url_Paypal { get; set; }
            public string Telefono_Sinpe { get; set; }
            public string Id_Cliente { get; set; }

            public Pago() { }

            public Pago(string[] info)
            {
                Id = info[0];
                Nombre = info[1];
                Tipo = info[2];
                Url_Paypal = info[3];
                Telefono_Sinpe = info[4];
                Id_Cliente = info[5];
            }
        
    }
}
