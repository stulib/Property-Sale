using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    class PagoMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_URL = "URL_PAYPAL";
        private const string DB_COL_TEL  = "TELEFONO_SINPE";
        private const string DB_COL_ID_CLIENTE = "ID_CLIENTE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var pago = new Pago
            {
                Id = GetStringValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                Url_Paypal = GetStringValue(row, DB_COL_URL),
                Telefono_Sinpe = GetStringValue(row, DB_COL_TEL),
                Id_Cliente = GetStringValue(row, DB_COL_ID_CLIENTE),
            };

            return pago;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var pago = BuildObject(row);
                lstResults.Add(pago);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "OBT_METODOS_PAGO_PR" };
            return operation;   
        }

        public SqlOperation GetRetriveStatement(String id)
        {
            var operation = new SqlOperation { ProcedureName = "OBT_METODO_PAGO_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
