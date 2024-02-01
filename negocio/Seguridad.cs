using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using dominio;
using System.Runtime.Remoting.Messaging;

namespace negocio
{
    public static class Seguridad
    {
        public static bool usuarioLogueado(object usuario)
        {

            Usuario user = (Usuario)usuario != null ? (Usuario)usuario : null;

            if (user != null)
                return true;
            else
                return false;

        }
        public static bool usuarioAdmin(object user)
        {

            Usuario usuario = (Usuario)user != null ? (Usuario)user : null;

            if (usuario != null && usuario.Admin)
                return true;
            else
                return false;
                
            

        }
    }
}
