using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    class SuscripcionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_CANTIDAD_ANUNCIOS = "CANTIDAD_ANUNCIOS";
        private const string DB_COL_PERIODO_FACTURACION = "PERIODO_FACTURACION";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_SUSCRIPCION_PR" };

            var s = (Suscripcion)entity;
            operation.AddVarcharParam(DB_COL_ID, s.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, s.Nombre);
            operation.AddIntParam(DB_COL_CANTIDAD_ANUNCIOS, s.Cantidad_Anuncios);
            operation.AddVarcharParam(DB_COL_PERIODO_FACTURACION, s.Periodo_Facturacion);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "OBT_SUSCRIPCION_PR" };

            var s = (Suscripcion)entity;
            operation.AddVarcharParam(DB_COL_ID, s.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "OBT_SUSCRIPCIONES_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_SUSCRIPCION_PR" };

            var s = (Suscripcion)entity;
            operation.AddVarcharParam(DB_COL_ID, s.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, s.Nombre);
            operation.AddIntParam(DB_COL_CANTIDAD_ANUNCIOS, s.Cantidad_Anuncios);
            operation.AddVarcharParam(DB_COL_PERIODO_FACTURACION, s.Periodo_Facturacion);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ELI_SUSCRIPCION_PR" };

            var s = (Suscripcion)entity;
            operation.AddVarcharParam(DB_COL_ID, s.Id);
            return operation;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var suscripcion = BuildObject(row);
                lstResults.Add(suscripcion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var suscripcion = new Suscripcion
            {
                Id = GetStringValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Cantidad_Anuncios = GetIntValue(row, DB_COL_CANTIDAD_ANUNCIOS),
                Periodo_Facturacion = GetStringValue(row, DB_COL_PERIODO_FACTURACION)

            };
            return suscripcion;
        }

   

    }
}
