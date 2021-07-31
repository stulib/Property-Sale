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
                var u = crudAgencia.Retrieve<Agencia>(agencia);
                if (u != null)
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
    }
}
