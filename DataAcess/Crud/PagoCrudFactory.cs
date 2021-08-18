﻿using DataAcess.Dao;
using DataAcess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Crud
{
    public class PagoCrudFactory : CrudFactory
    {

        PagoMapper mapper;

        public PagoCrudFactory() : base()
        {
            mapper = new PagoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {

            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        /* public override T Retrieve<T>(BaseEntity entity)
         {
             var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
             var dic = new Dictionary<string, object>();
             if (lstResult.Count > 0)
             {
                 dic = lstResult[0];
                 var objs = mapper.BuildObject(dic);
                 return (T)Convert.ChangeType(objs, typeof(T));
             }

             return default(T);
         }*/

        public override List<T> RetrieveAll<T>()
        {
            var lstPropiedades = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstPropiedades.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstPropiedades;
        }

        public  List<T> RetrieveAllID<T>(string id)
        {
            var lstPropiedades = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstPropiedades.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstPropiedades;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
