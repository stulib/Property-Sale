using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    internal class AgenciaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_LOGO = "LOGO";
        private const string DB_COL_ESTADO = "ESTADO";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var agencia = new Agencia
            {
                Id = GetStringValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                Id_Usuario = GetStringValue(row, DB_COL_ID_USUARIO),
                Logo = GetStringValue(row, DB_COL_LOGO),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };
            return agencia;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_AGENCIA_PR" };

            var u = (Agencia)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_TIPO, u.Tipo);
            operation.AddVarcharParam(DB_COL_ID_USUARIO, u.Id_Usuario);
            operation.AddVarcharParam(DB_COL_LOGO, u.Logo);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ELI_AGENCIA_PR" };

            var u = (Agencia)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "OBT_AGENCIAS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "OBT_AGENCIA_PR" };

            var u = (Agencia)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}