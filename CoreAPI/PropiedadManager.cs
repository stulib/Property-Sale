using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class PropiedadManager : BaseManager
    {
        private PropiedadCrudFactory crudPropiedad;

        public PropiedadManager()
        {
            crudPropiedad = new PropiedadCrudFactory();
        }

        public void Create(Propiedad propiedad)
        {
            try
            {
                var p = crudPropiedad.Retrieve<Propiedad>(propiedad);
                if (p != null)
                {
                    throw new BussinessException(9);
                }
                else
                {
                    crudPropiedad.Create(propiedad);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Propiedad> RetrieveAll()
        {
            return crudPropiedad.RetrieveAll<Propiedad>();
        }

        public Propiedad RetrieveById(Propiedad propiedad)
        {
            Propiedad p = null;
            try
            {
                p = crudPropiedad.Retrieve<Propiedad>(propiedad);
                if (p == null)
                {
                    throw new BussinessException(8);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return p;
        }

        public void Update(Propiedad propiedad)
        {
            var u = crudPropiedad.Retrieve<Propiedad>(propiedad);
            if (u == null)
            {
                throw new BussinessException(8);
            }
            else
            {
                crudPropiedad.Update(propiedad);
            }
        }

        public void Delete(Propiedad propiedad)
        {
            var u = crudPropiedad.Retrieve<Propiedad>(propiedad);
            if (u == null)
            {
                throw new BussinessException(8);
            }
            else
            {
                crudPropiedad.Delete(propiedad);
            }
        }
    }
}
