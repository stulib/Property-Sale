using System;

namespace Entities_POJO
{
     public class Propiedad : BaseEntity
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string Opcion_Compra { get; set; }
        public DateTime Fecha_Publicacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion_Exacta{ get; set; }
        public string Destacado { get; set; }
        public string Programado { get; set; }
        public int Visitas { get; set; }

        public Propiedad() { }

        public Propiedad(string[] info )
        {
            Id = info[0];
            Tipo = info[1];
            Opcion_Compra = info[2];
            Fecha_Publicacion = DateTime.Parse(info[3]);
            Latitud = info[4];
            Longitud = info[5];
            Precio = Convert.ToDouble(info[6]);
            Estado = info[7];
            Provincia = info[8];
            Canton = info[9];
            Distrito = info[10];
            Direccion_Exacta = info[11];
            Destacado = info[12];
            Programado = info[13];
            Visitas = Convert.ToInt32(info[14]);
        }
    }
}
