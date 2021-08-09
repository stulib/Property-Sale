using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class AccountMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Cuenta = new Cuenta
            {
                ID = GetStringValue(row, "ID"),
                TIPO_ID = GetStringValue(row, "TIPO_ID"),
                NOMBRE = GetStringValue(row, "NOMBRE"),
                CONTRASENNA = GetStringValue(row, "CONTRASENNA"),
                FECHA_NAC = GetDateValue(row, "FECHA_NAC"),
                EMAIL = GetStringValue(row, "EMAIL"),
                ESTADO = GetStringValue(row, "ESTADO"),
                TELEFONO = GetIntValue(row, "TELEFONO"),
                ID_ROL = GetStringValue(row, "ID_ROL"),
                VERIFICADO = GetStringValue(row, "VERIFICADO"),
            };

            return Cuenta;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACCOUNT_PR" };

            var u = (Cuenta)entity;
            operation.AddVarcharParam("ID", u.ID);
            operation.AddVarcharParam("IDAGencia", u.ID_AGENCIA);
            operation.AddVarcharParam("IDRol", u.ID_ROL);
            operation.AddVarcharParam("Nombre", u.NOMBRE);
            operation.AddIntParam("Tel", u.TELEFONO);
            operation.AddVarcharParam("TipoID", u.TIPO_ID);
            operation.AddVarcharParam("Verificado", u.VERIFICADO);
            operation.AddIntParam("Cod_Cel", u.COD_CEL);
            operation.AddIntParam("Cod_Email", u.COD_EMAIL);
            operation.AddVarcharParam("Contrasenna", u.CONTRASENNA);
            operation.AddVarcharParam("Email", u.EMAIL);
            operation.AddVarcharParam("Estado", u.ESTADO);
            operation.AddDateParam("FechaNa", u.FECHA_NAC);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACCOUNT_PR" };

            var u = (Cuenta)entity;
            operation.AddVarcharParam("ID", u.ID);
            operation.AddVarcharParam("IDAGencia", u.ID_AGENCIA);
            operation.AddVarcharParam("IDRol", u.ID_ROL);
            operation.AddVarcharParam("NOMBRE", u.NOMBRE);
            operation.AddIntParam("TEL", u.TELEFONO);
            operation.AddVarcharParam("TipoID", u.TIPO_ID);
            operation.AddVarcharParam("Verificado", u.VERIFICADO);
            operation.AddIntParam("COD_CEL", u.COD_CEL);
            operation.AddIntParam("COD_EMAIL", u.COD_EMAIL);
            operation.AddVarcharParam("CONTRASENNA", u.CONTRASENNA);
            operation.AddVarcharParam("Email", u.EMAIL);
            operation.AddVarcharParam("ESTADO", u.ESTADO);
            operation.AddDateParam("FechaNa", u.FECHA_NAC);
            return operation;
        }
        public SqlOperation GetRetriveStatement(String ID)
        {
            var operation = new SqlOperation { ProcedureName = "OBT_USUARIO_PR" };

            operation.AddVarcharParam("ID", ID);
            return operation;
        }

        public SqlOperation ValidateDuplicate(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "VAL_ACCOUNT_PR" };

            var u = (Cuenta)entity;
            operation.AddVarcharParam("ID", u.ID);
            operation.AddVarcharParam("Correo", u.EMAIL);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_USUARIO_PR" };

            var u = (Cuenta)entity;
            operation.AddVarcharParam("ID", u.ID);
            operation.AddVarcharParam("IDAGencia", u.ID_AGENCIA);
            operation.AddVarcharParam("IDRol", u.ID_ROL);
            operation.AddVarcharParam("NOMBRE", u.NOMBRE);
            operation.AddIntParam("TEL", u.TELEFONO);
            operation.AddVarcharParam("TipoID", u.TIPO_ID);
            operation.AddVarcharParam("Verificado", u.VERIFICADO);
            operation.AddIntParam("COD_CEL", u.COD_CEL);
            operation.AddIntParam("COD_EMAIL", u.COD_EMAIL);
            operation.AddVarcharParam("CONTRASENNA", u.CONTRASENNA);
            operation.AddVarcharParam("Email", u.EMAIL);
            operation.AddVarcharParam("ESTADO", u.ESTADO);
            operation.AddDateParam("FechaNa", u.FECHA_NAC);
            return operation;
        }
    }
}
