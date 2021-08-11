using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class AgenciaManager : BaseManager
    {
        private AgenciaCrudFactory crudAgencia;

        public AgenciaManager()
        {
            crudAgencia = new AgenciaCrudFactory();
        }

        public void Create(Agencia agencia)
        {
             try
            {
                var a = crudAgencia.Retrieve<Agencia>(agencia);
                if (a != null)
                {
                    throw new BussinessException(9);
                }
                else
                {
                    crudAgencia.Create(agencia);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Agencia> RetrieveAll()
        {
            return crudAgencia.RetrieveAll<Agencia>();
        }

        public Agencia RetrieveById(Agencia agencia)
        {
            Agencia a = null;
            try
            {
                a = crudAgencia.Retrieve<Agencia>(agencia);
                if (a == null)
                {
                    throw new BussinessException(5);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return a;
        }

        public void Update(Agencia agencia)
        {
            var a = crudAgencia.Retrieve<Agencia>(agencia);
            if (a == null)
            {
                throw new BussinessException(5);
            }
            else
            {
                crudAgencia.Update(agencia);
            }
        }

        public void Delete(Agencia agencia)
        {
            var a = crudAgencia.Retrieve<Agencia>(agencia);
            if (a == null)
            {
                throw new BussinessException(5);
            }
            else
            {
                crudAgencia.Delete(agencia);
            }
        }
    }
}
