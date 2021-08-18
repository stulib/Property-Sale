using Entities_POJO;
using System;

namespace Exceptions
{
    public class BussinessException : Exception
    {
        public int ExceptionId;

        public string ExceptionDetails { get; set; }
        public ApplicationMessage AppMessage { get; set; }

        public BussinessException()
        {

        }

        public BussinessException(int exceptionId)
        {
            ExceptionManager excMang = ExceptionManager.GetInstance();

            BussinessException bexGet = new BussinessException
            {
                ExceptionId = exceptionId
            };

            BussinessException bex = new BussinessException
            {
                ExceptionId = exceptionId,
                AppMessage = excMang.GetMessage(bexGet)
            };

            throw bex;
        }

        public BussinessException(int exceptionId, Exception innerException)
        {
            ExceptionId = exceptionId;
        }
    }
}
