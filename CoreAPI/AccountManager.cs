using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreAPI
{
    public class AccountManager : BaseManager
    {
        private AccountCrudFactory crudAccount;
        private UsuarioCrudFactory crudUsuario;
        private Random rng = new Random();
        private SHA256 Hasher = SHA256.Create();

        public AccountManager()
        {
            crudAccount = new AccountCrudFactory();
            crudUsuario = new UsuarioCrudFactory();
        }


        public static bool EmailSend(string SenderEmail, string Subject, string Message, bool IsBodyHtml = false)
        {
            bool status = false;
            try
            {
                string HostAddress = ConfigurationManager.AppSettings["Host"].ToString();
                string FormEmailId = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();
                string Port = ConfigurationManager.AppSettings["Port"].ToString();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FormEmailId);
                mailMessage.Subject = Subject;
                mailMessage.Body = Message;
                mailMessage.IsBodyHtml = IsBodyHtml;
                mailMessage.To.Add(new MailAddress(SenderEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = mailMessage.From.Address;
                networkCredential.Password = Password;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = Convert.ToInt32(Port);
                smtp.Send(mailMessage);
                status = true;
                return status;
            }
            catch (Exception e)
            {
                return status;
            }
        }

        public Cuenta getAccount(string iD)
        {
            Cuenta result = new Cuenta();
            result = crudAccount.Retrieve<Cuenta>(iD);
            return result;
        }

        //public Cuenta ValidateDuplicate(Cuenta cuenta)
        //{
        //    bool u = false;
        //    Cuenta result = new Cuenta();
        //    try
        //    {
        //        u = crudAccount.ValidateDuplicate(cuenta);
        //        if (u == null)
        //        {
        //            throw new BussinessException(9);
        //        }
        //        else
        //        {
        //            if (!u)
        //            {
        //                result = crudAccount.Retrieve<Cuenta>(cuenta);
        //            }
        //            else
        //            {
        //                cuenta.Mensaje = "Cuenta Duplicada, por favor especifique otros valores";
        //                result = cuenta;
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionManager.GetInstance().Process(ex);
        //    }
        //    return result;
        //}

        public Cuenta ValidateAccount(Cuenta cuenta)
        {
            Cuenta u = null;
            try
            {
                u = crudAccount.Retrieve<Cuenta>(cuenta);
                if (u == null)
                {
                    throw new BussinessException(9);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return u;
        }

        public Cuenta Create(Cuenta cuenta)
        {
            Regex regexEmail = new Regex(@"([a-zA-ZÀ-ÿ\u00f1\u00d1\!0-9]+@[a-zA-Z\!0-9]+\.[a-zA-Z]+)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
            try
            {
                var u = (Usuario)cuenta;
                u = crudUsuario.Retrieve<Usuario>(u);
                int codigo_Celular = GenerarCodigo(rng);
                int codigo_Correo = GenerarCodigo(rng);
                bool email_Match = regexEmail.IsMatch(cuenta.EMAIL);
                bool contrasenna_Match = ValidatePassword(cuenta.CONTRASENNA);

                cuenta.COD_CEL = codigo_Celular;
                cuenta.COD_EMAIL = codigo_Correo;

                if (u != null)
                {
                    throw new BussinessException(1);
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
                    cuenta.CONTRASENNA = Hash_Function(cuenta.CONTRASENNA);
                    crudAccount.Create(cuenta);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return cuenta;
        }

        public List<Cuenta> RetrieveAll()
        {
            return crudAccount.RetrieveAll<Cuenta>();
        }

        public Cuenta RetrieveById(Cuenta cuenta)
        {
            Cuenta u = null;
            try
            {
                u = crudAccount.Retrieve<Cuenta>(cuenta);
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

        public void UpdateBanco(Cuenta cuenta)
        {
            var u = crudAccount.Retrieve<Cuenta>(cuenta.ID);
            if (u == null)
            {
                throw new BussinessException(1);
            }
            else
            {
                crudAccount.UpdateBanco(cuenta);
            }
        }

        public void Delete(Usuario usuario)
        {
            var u = crudAccount.Retrieve<Usuario>(usuario);
            if (u != null)
            {
                throw new BussinessException(1);
            }
            else
            {
                crudAccount.Delete(usuario);
            }
        }
        private int GenerarCodigo(Random rng)
        {
            int codigo = 0;
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
    }
}
