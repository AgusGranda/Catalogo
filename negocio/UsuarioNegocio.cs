using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool login(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setearProcedure("storedLogin");
				datos.cargarParametros("@email",usuario.Email);
				datos.cargarParametros("pass", usuario.Pass);

				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["Id"];

					if (!(datos.Lector["nombre"] is DBNull))
						usuario.Nombre = (string)datos.Lector["nombre"];

					if (!(datos.Lector["apellido"] is DBNull))
					usuario.Apellido = (string)datos.Lector["apellido"];

					if (!(datos.Lector["urlImagenPerfil"] is DBNull))
						usuario.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

					usuario.Admin = (bool)datos.Lector["admin"];

					return true;
				}
				return false;

			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }

		public bool filtrar(string email)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearProcedure("storedFiltroUsuario");
				datos.cargarParametros("@email",email);
				datos.ejecutarLectura();

				if (datos.Lector.Read())
					return true;
				else 
					return false;
				

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}


        public void registro(Usuario usuario)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{

				datos.setearProcedure("storedRegistro");
				datos.cargarParametros("@email",usuario.Email);
                datos.cargarParametros("@pass", usuario.Pass);
				datos.cargarParametros("@img", (object)usuario.UrlImagenPerfil ?? DBNull.Value);

				datos.ejecutarAccion();


            }
            catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
    }
}
