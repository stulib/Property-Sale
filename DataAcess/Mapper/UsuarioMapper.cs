using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    class UsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_TIPO_ID = "TIPO_ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDOS = "APELLIDOS";
        private const string DB_COL_FECHA_NAC = "FECHA_NAC";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_COD_EMAIL = "COD_EMAIL";
        private const string DB_COL_COD_CEL = "COD_CEL";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_ID_AGENCIA = "ID_AGENCIA";
        private const string DB_COL_VERIFICADO = "VERIFICADO";
        private const string DB_COL_NOMBRE_ROL = "NOMBRE_ROL";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);
            operation.AddVarcharParam(DB_COL_TIPO_ID, u.Tipo_Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDOS, u.Apellidos);
            operation.AddDateParam(DB_COL_FECHA_NAC, u.Fecha_Nac);
            operation.AddVarcharParam(DB_COL_CONTRASENNA, u.Contrasenna);
            operation.AddVarcharParam(DB_COL_EMAIL, u.Email);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);
            operation.AddIntParam(DB_COL_TELEFONO, u.Telefono);
            operation.AddIntParam(DB_COL_COD_EMAIL, u.Cod_Email);
            operation.AddIntParam(DB_COL_COD_CEL, u.Cod_Celular);
            operation.AddVarcharParam(DB_COL_ID_ROL, u.Id_Rol);
            operation.AddVarcharParam(DB_COL_ID_AGENCIA, u.Id_Agencia);
            operation.AddCharParam(DB_COL_VERIFICADO, u.Verificado);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "OBT_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);

            return operation;
        }

        public SqlOperation GetLoginStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "OBT_SESION_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, u.Email);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "OBT_USUARIOS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);
            operation.AddVarcharParam(DB_COL_TIPO_ID, u.Tipo_Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDOS, u.Apellidos);
            operation.AddDateParam(DB_COL_FECHA_NAC, u.Fecha_Nac);
            operation.AddVarcharParam(DB_COL_CONTRASENNA, u.Contrasenna);
            operation.AddVarcharParam(DB_COL_EMAIL, u.Email);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);
            operation.AddIntParam(DB_COL_TELEFONO, u.Telefono);
            operation.AddIntParam(DB_COL_COD_EMAIL, u.Cod_Email);
            operation.AddIntParam(DB_COL_COD_CEL, u.Cod_Celular);
            operation.AddVarcharParam(DB_COL_ID_ROL, u.Id_Rol);
            operation.AddVarcharParam(DB_COL_ID_AGENCIA, u.Id_Agencia);
            operation.AddCharParam(DB_COL_VERIFICADO, u.Verificado);

            return operation;
        }

        public SqlOperation GetUpdateProfileStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_PERFILUSUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);
            operation.AddVarcharParam(DB_COL_TIPO_ID, u.Tipo_Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, u.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDOS, u.Apellidos);
            operation.AddDateParam(DB_COL_FECHA_NAC, u.Fecha_Nac);
            operation.AddVarcharParam(DB_COL_EMAIL, u.Email);
            operation.AddVarcharParam(DB_COL_ESTADO, u.Estado);
            operation.AddIntParam(DB_COL_TELEFONO, u.Telefono);
            operation.AddVarcharParam(DB_COL_ID_ROL, u.Id_Rol);
            operation.AddVarcharParam(DB_COL_ID_AGENCIA, u.Id_Agencia);
            operation.AddCharParam(DB_COL_VERIFICADO, u.Verificado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ELI_USUARIO_PR" };

            var u = (Usuario)entity;
            operation.AddVarcharParam(DB_COL_ID, u.Id);
            return operation;
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

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario
            {
                Id = GetStringValue(row, DB_COL_ID),
                Tipo_Id = GetStringValue(row, DB_COL_TIPO_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellidos = GetStringValue(row, DB_COL_APELLIDOS),
                Fecha_Nac = GetDateValue(row, DB_COL_FECHA_NAC),
                Contrasenna = GetStringValue(row, DB_COL_CONTRASENNA),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Telefono = GetIntValue(row, DB_COL_TELEFONO),
                Cod_Email = GetIntValue(row, DB_COL_COD_EMAIL),
                Cod_Celular = GetIntValue(row, DB_COL_COD_CEL),
                Id_Rol = GetStringValue(row, DB_COL_ID_ROL),
                Id_Agencia = GetStringValue(row, DB_COL_ID_AGENCIA),
                Verificado = Convert.ToChar(GetStringValue(row, DB_COL_VERIFICADO)),
                Nombre_Rol = GetStringValue(row, DB_COL_NOMBRE_ROL)
            };

            return usuario;
        }

    }

}
