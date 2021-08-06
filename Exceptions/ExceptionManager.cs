using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Exceptions
{
    public class ExceptionManager
    {

        public string PATH = "";

        private static ExceptionManager instance;

        private static Dictionary<int, ApplicationMessage> messages = new Dictionary<int, ApplicationMessage>();

        private ExceptionManager()
        {
            LoadMessages();
            PATH = ConfigurationManager.AppSettings.Get("LOG_PATH");
        }

        public static ExceptionManager GetInstance()
        {
            if (instance == null)
                instance = new ExceptionManager();

            return instance;
        }

        public void Process(Exception ex)
        {

            var bex = new BussinessException();


            if (ex.GetType() == typeof(BussinessException))
            {
                bex = (BussinessException)ex;
                bex.ExceptionDetails = GetMessage(bex).Message;
            }
            else
            {
                bex = new BussinessException(0, ex);
            }

            ProcessBussinesException(bex);

        }

        private void ProcessBussinesException(BussinessException bex)
        {       
            var today = DateTime.Now.ToString("yyyyMMdd_HH");
            var logName = PATH + today + "_" + "log.txt";

            var message = bex.ExceptionDetails + "\n" + bex.StackTrace + "\n";
            using (StreamWriter w = File.AppendText(logName))
            {
                Log(message, w);
            }

            bex.AppMessage = GetMessage(bex);

            throw bex;

        }

        public ApplicationMessage GetMessage(BussinessException bex)
        {

            var appMessage = new ApplicationMessage
            {
                Message = "Message not found!"
            };

            if (messages.ContainsKey(bex.ExceptionId))
                appMessage = messages[bex.ExceptionId];

            return appMessage;

        }

        private void LoadMessages()
        {
            messages.Add(0, new ApplicationMessage { Id = 0, Message = "Ha ocurrido un problema!"});
            messages.Add(1, new ApplicationMessage { Id = 1, Message = "Cliente ya registrado"});
            messages.Add(2, new ApplicationMessage { Id = 2, Message = "El cliente debe ser mayor de edad."});
            messages.Add(3, new ApplicationMessage { Id = 3, Message = "Por favor ingrese un correo válido."});
            messages.Add(4, new ApplicationMessage { Id = 4, Message = "Por favor ingrese una contraseña válida."});
            messages.Add(5, new ApplicationMessage { Id = 5, Message = "Cliente no encontrado."});
            messages.Add(6, new ApplicationMessage { Id = 6, Message = "Contraseña incorrecta."});
            messages.Add(7, new ApplicationMessage { Id = 7, Message = "Acceso revocado. Por favor contacte al administrador del sistema." });
            messages.Add(8, new ApplicationMessage { Id = 8, Message = "Propiedad no encontrada." });
            messages.Add(9, new ApplicationMessage { Id = 9, Message = "Propiedad ya registrada." });
            messages.Add(10, new ApplicationMessage { Id = 10, Message = "Cuenta no verificada. Por favor active su cuenta para iniciar sesión." });
            /*var crudMessages = new AppMessagesCrudFactory();
            var lstMessages = crudMessages.RetrieveAll<ApplicationMessage>();

            foreach (var appMessage in lstMessages) { 
            
                messages.Add(appMessage.Id, appMessage);
            }*/
        }

        private void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

    }
}
