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
                int codigo_Celular = GenerarCodigo();
                int codigo_Correo = GenerarCodigo();
                usuario.Cod_Celular = codigo_Celular;
                usuario.Cod_Email = codigo_Correo;
                crudUsuario.Create(usuario);
                /*var u = crudUsuario.Retrieve<Usuario>(usuario); 
                if (u != null)
                {
                    throw new BussinessException(3);
                }*/
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
                    throw new BussinessException(4);
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

        public int GenerarCodigo()
        {
            int codigo = 0;
            Random rndm = new Random();
            codigo = rndm.Next(100000, 1000000);
            return codigo;
        }
    }
}
