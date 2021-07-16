using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CoreAPI
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;
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
                usuario.Cod_Celular = codigo_Celular;
                usuario.Cod_Email = codigo_Correo;
                bool email_Match = regexEmail.IsMatch(usuario.Email);
                bool contrasenna_Match = ValidatePassword(usuario.Contrasenna);

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
            crudUsuario.Update(usuario);
        }

        public void Delete(Usuario usuario)
        {
            crudUsuario.Delete(usuario);
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
    }
}
