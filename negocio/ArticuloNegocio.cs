using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
      
        public List<Articulo> listarConSp()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setearProcedure("storedListar");
                data.ejecutarLectura();

                while (data.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)data.Lector["Id"];
                    aux.Codigo = (string)data.Lector["Codigo"];
                    aux.Nombre = (string)data.Lector["Nombre"];
                    aux.Descripcion = (string)data.Lector["Descripcion"];

                    if (!(data.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)data.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)data.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)data.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)data.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)data.Lector["Categoria"];
                    aux.Precio = (decimal)data.Lector["Precio"];


                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }





    }




}
