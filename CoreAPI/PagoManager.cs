using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class PagoManager : BaseManager
    {
        private PagoCrudFactory crudPago;
    
        public PagoManager()
        {
            crudPago = new PagoCrudFactory();
        }

        public List<Pago> RetrieveAll()
        {
            return crudPago.RetrieveAll<Pago>();
        }

        public List<Pago> RetrieveById(String id)
        {

            return crudPago.RetrieveAllID<Pago>(id);
        }

    }

}
