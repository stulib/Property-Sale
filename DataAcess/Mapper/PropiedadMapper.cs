using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    class PropiedadMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_Opcion_Compra = "OPCION_COMPRA";
        private const string DB_COL_Fecha_Publicacion = "FECHA_PUBLICACION";
        private const string DB_COL_Latitud = "LATITUD";
        private const string DB_COL_Longitud = "LONGITUD";
        private const string DB_COL_Precio = "PRECIO";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_Provincia = "PROVINCIA";
        private const string DB_COL_Canton = "CANTON";
        private const string DB_COL_Distrito = "DISTRITO";
        private const string DB_COL_Direccion_Exacta = "DIRECCION_EXACTA";
        private const string DB_COL_Destacado = "DESTACADO";
        private const string DB_COL_Programado = "PROGRMADO";
        private const string DB_COL_Visitas = "VISITAS";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PROPIEDAD_PR" };
            var p = (Propiedad)entity;

            operation.AddVarcharParam(DB_COL_ID, p.Id);
            operation.AddVarcharParam(DB_COL_TIPO, p.Tipo);
            operation.AddVarcharParam(DB_COL_Opcion_Compra, p.Opcion_Compra);
            operation.AddDateParam(DB_COL_Fecha_Publicacion, p.Fecha_Publicacion);
            operation.AddVarcharParam(DB_COL_Latitud, p.Latitud);
            operation.AddVarcharParam(DB_COL_Longitud, p.Longitud);
            operation.AddDoubleParam(DB_COL_Precio, p.Precio);
            operation.AddVarcharParam(DB_COL_ESTADO, p.Estado);
            operation.AddVarcharParam(DB_COL_Provincia, p.Provincia);
            operation.AddVarcharParam(DB_COL_Canton, p.Canton);
            operation.AddVarcharParam(DB_COL_Distrito, p.Distrito);
            operation.AddVarcharParam(DB_COL_Direccion_Exacta, p.Direccion_Exacta);
            operation.AddVarcharParam(DB_COL_Destacado, p.Destacado);
            operation.AddVarcharParam(DB_COL_Programado, p.Programado);
            operation.AddIntParam(DB_COL_Visitas, p.Visitas);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "OBT_PROPIEDADES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "OBT_PROPIEDAD_PR" };

            var p = (Propiedad)entity;
            operation.AddVarcharParam(DB_COL_ID, p.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_PROPIEDAD_PR" };
            var p = (Propiedad)entity;

            operation.AddVarcharParam(DB_COL_ID, p.Id);
            operation.AddVarcharParam(DB_COL_TIPO, p.Tipo);
            operation.AddVarcharParam(DB_COL_Opcion_Compra, p.Opcion_Compra);
            operation.AddDateParam(DB_COL_Fecha_Publicacion, p.Fecha_Publicacion);
            operation.AddVarcharParam(DB_COL_Latitud, p.Latitud);
            operation.AddVarcharParam(DB_COL_Longitud, p.Longitud);
            operation.AddDoubleParam(DB_COL_Precio, p.Precio);
            operation.AddVarcharParam(DB_COL_ESTADO, p.Estado);
            operation.AddVarcharParam(DB_COL_Provincia, p.Provincia);
            operation.AddVarcharParam(DB_COL_Canton, p.Canton);
            operation.AddVarcharParam(DB_COL_Distrito, p.Distrito);
            operation.AddVarcharParam(DB_COL_Direccion_Exacta, p.Direccion_Exacta);
            operation.AddVarcharParam(DB_COL_Destacado, p.Destacado);
            operation.AddVarcharParam(DB_COL_Programado, p.Programado);
            operation.AddIntParam(DB_COL_Visitas, p.Visitas);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ELI_PROPIEDAD_PR" };

            var p = (Propiedad)entity;
            operation.AddVarcharParam(DB_COL_ID, p.Id);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var propiedad = BuildObject(row);
                lstResults.Add(propiedad);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var propiedad = new Propiedad
            {
                Id = GetStringValue(row, DB_COL_ID),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                Opcion_Compra = GetStringValue(row, DB_COL_Opcion_Compra),
                Fecha_Publicacion = (DateTime)GetDateValue(row, DB_COL_Fecha_Publicacion),
                Latitud = GetStringValue(row, DB_COL_Latitud),
                Longitud = GetStringValue(row, DB_COL_Longitud),
                Precio = GetDoubleValue(row, DB_COL_Precio),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Provincia = GetStringValue(row, DB_COL_Provincia),
                Canton = GetStringValue(row, DB_COL_Canton),
                Distrito = GetStringValue(row, DB_COL_Distrito),
                Direccion_Exacta = GetStringValue(row, DB_COL_Direccion_Exacta),
                Destacado = GetStringValue(row, DB_COL_Destacado),
                Programado = GetStringValue(row, DB_COL_Programado),
                Visitas = GetIntValue(row, DB_COL_Visitas)
            };

            return propiedad;
        }
    }
}
