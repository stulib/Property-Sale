﻿using DataAcess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mapper
{
    public class UserProfileMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_USER_ID = "USER_ID";
        private const string DB_COL_USER_NAME = "USER_NAME";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_FULL_NAME = "FULL_NAME";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_PROFILE_PR" };

            var u = (UserProfile)entity;
            operation.AddVarcharParam(DB_COL_USER_NAME, u.UserName);
            operation.AddVarcharParam(DB_COL_PASSWORD, u.Password);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var user = BuildObject(row);
                lstResults.Add(user);
            }

            return lstResults;

        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var user = new UserProfile
            {
                UserId = GetStringValue(row, DB_COL_USER_ID),
                UserName = GetStringValue(row, DB_COL_USER_NAME),
                FullName = GetStringValue(row, DB_COL_FULL_NAME),
            };

            return user;

        }

    }
}

