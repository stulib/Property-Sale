using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class SuscripcionManager : BaseManager
    {
        private SuscripcionCrudFactory crudSuscripcion;

        public SuscripcionManager()
        {
            crudSuscripcion = new SuscripcionCrudFactory();
        }

        public void Create(Suscripcion suscripcion)
        {
            try
            {
                var s = crudSuscripcion.Retrieve<Suscripcion>(suscripcion);
                if (s != null)
                {
                    throw new BussinessException(9);
                }
                else
                {
                    crudSuscripcion.Create(suscripcion);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Suscripcion> RetrieveAll()
        {
            return crudSuscripcion.RetrieveAll<Suscripcion>();
        }

        public Suscripcion RetrieveById(Suscripcion suscripcion)
        {
            Suscripcion s = null;
            try
            {
                s = crudSuscripcion.Retrieve<Suscripcion>(suscripcion);
                if (s == null)
                {
                    throw new BussinessException(8);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return s;
        }
        public void Update(Suscripcion suscripcion)
        {
            var s = crudSuscripcion.Retrieve<Suscripcion>(suscripcion);
            if (s == null)
            {
                throw new BussinessException(8);
            }
            else
            {
                crudSuscripcion.Update(suscripcion);
            }
        }

        public void Delete(Suscripcion suscripcion)
        {
            var s = crudSuscripcion.Retrieve<Suscripcion>(suscripcion);
            if (s == null)
            {
                throw new BussinessException(8);
            }
            else
            {
                crudSuscripcion.Delete(suscripcion);
            }
        }
    }
}
