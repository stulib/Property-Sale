using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CoreAPI
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;
        private SHA256 Hasher = SHA256.Create();
        private Random rng = new Random();

        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }

        public void Create(Usuario usuario)
        {
            Regex regexEmail = new Regex(@"([a-zA-ZÀ-ÿ\u00f1\u00d1\!0-9]+@[a-zA-Z\!0-9]+\.[a-zA-Z]+)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            try
            {
                var u = crudUsuario.Retrieve<Usuario>(usuario);
                int codigo_Celular = GenerarCodigo(rng);
                int codigo_Correo = GenerarCodigo(rng);
                bool email_Match = regexEmail.IsMatch(usuario.Email);
                bool contrasenna_Match = ValidatePassword(usuario.Contrasenna);
                DateTime fechaNac = (DateTime)usuario.Fecha_Nac;
                TimeSpan tm = DateTime.Now - fechaNac;
                double edad = (tm.Days / 365.242);

                usuario.Cod_Celular = codigo_Celular;
                usuario.Cod_Email = codigo_Correo;

                if (u != null)
                {
                    throw new BussinessException(1);
                }
                else if (edad < 18)
                {
                    throw new BussinessException(2);
                }
                else if (email_Match == false)
                {
                    throw new BussinessException(3);
                }
                else if (contrasenna_Match == false)
                {
                    throw new BussinessException(4);
                }
                else
                {
                    usuario.Contrasenna = Hash_Function(usuario.Contrasenna);
                    Correo(usuario.Cod_Email, usuario.Email, usuario.Nombre).GetAwaiter();
                    Mensaje(usuario.Cod_Celular, usuario.Telefono);
                    crudUsuario.Create(usuario);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }

        public Usuario RetrieveById(Usuario usuario)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.Retrieve<Usuario>(usuario);
                if (u == null)
                {
                    throw new BussinessException(5);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return u;
        }

        public void Update(Usuario usuario)
        {
            var u = crudUsuario.Retrieve<Usuario>(usuario);
            if (u == null)
            {
                throw new BussinessException(5);
            }
            else
            {
                crudUsuario.Update(usuario);
            }
        }

        public void Delete(Usuario usuario)
        {
            var u = crudUsuario.Retrieve<Usuario>(usuario);
            if (u == null)
            {
                throw new BussinessException(5);
            }
            else
            {
                crudUsuario.Delete(usuario);
            }
        }

        public Usuario ValidateUser(Usuario user)
        {
            Usuario u = null;
            try
            {
                u = crudUsuario.LoginData<Usuario>(user);
                string pwd_To_Match = Hash_Function(user.Contrasenna);

                if (u == null)
                {
                    throw new BussinessException(5);
                }
                else if (u.Verificado.Equals("N") | u.Verificado.Equals("n"))
                {
                    throw new BussinessException(10);
                }
                else if (u.Estado.Equals("Inactivo"))
                {
                    throw new BussinessException(7);
                }
                else if (u.Contrasenna.Equals(pwd_To_Match) == false)
                {
                    throw new BussinessException(6);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return u;
        }

        private int GenerarCodigo(Random rng)
        {
            int codigo;
            codigo = rng.Next(100000, 1000000);
            return codigo;
        }

        private bool ValidatePassword(string password)
        {
            var input = password;
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinChars = new Regex(@".{6,}");
            var hasNumber = new Regex(@"[0-9]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                return false;
            }
            else if (!hasMinChars.IsMatch(input))
            {
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string Hash_Function(string password)
        {

            string hashed_Pwd;
            byte[] hashed_Middle = Hasher.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringbuilder = new StringBuilder();
            for (int i = 0; i < hashed_Middle.Length; i++)
            {
                stringbuilder.Append(hashed_Middle[i].ToString("x2"));
            }
            hashed_Pwd = stringbuilder.ToString();
            return hashed_Pwd;
        }

        private static async Task Correo(int cod_Verificacion_Email, string correo, string nombre)
        {
            string codigo_Texto = cod_Verificacion_Email.ToString();
            var apiKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jzunigas@ucenfotec.ac.cr", "TechHouse");
            var subject = "Código de verificación de cuenta";
            var to = new EmailAddress(correo, "Nuevo usuario de TechHouse");
            var plainTextContent = codigo_Texto;
            var htmlContent = nombre +", gracias por registrarse con TechHouse. Su código de verificación es:" +
                "<strong>" + codigo_Texto + "</strong><br><br>" +
                "Bienvenido.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        private static void Mensaje(int cod_Verificacion_Cel, int numero_Cel)
        {
            string accountSid = Environment.GetEnvironmentVariable("TwilioID");
            string authToken = Environment.GetEnvironmentVariable("TwilioToken");
            string numero = numero_Cel.ToString();

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Su código de verificación para registrarse con TechHouse es " + cod_Verificacion_Cel + ".",
                from: new Twilio.Types.PhoneNumber("+16178924006"),
                to: new Twilio.Types.PhoneNumber("+506"+numero)
            );
        }
    }
}
