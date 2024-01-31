using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
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


        public List<Articulo> filtrar(string criterio, string subCriterio, string filtroAvanzado)
        {
            List<Articulo> listaFiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string consulta = "select ARTICULOS.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion Marca, CATEGORIAS.Descripcion Categoria, ARTICULOS.IdMarca IdMarca,ARTICULOS.IdCategoria IdCategoria ,ImagenUrl,Precio  from ARTICULOS inner join MARCAS on IdMarca = MARCAS.Id  inner join CATEGORIAS on IdCategoria = CATEGORIAS.id where ";

                if (criterio == "Precio")
                {
                    switch (subCriterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtroAvanzado;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtroAvanzado;
                            break;
                        default:
                            consulta += "Precio = " + filtroAvanzado;
                            break;
                    }
                }
                else if (criterio == "Nombre")
                {
                    switch (subCriterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtroAvanzado + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtroAvanzado + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtroAvanzado + "%'";
                            break;
                    }
                }
                else if (criterio == "Marca")
                {
                    consulta += "Marcas.Descripcion ='" + subCriterio + "'";
                }
                else
                {
                    consulta += "Categorias.Descripcion = '" + subCriterio + "'";
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    listaFiltrada.Add(aux);
                }

                return listaFiltrada;

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

        public Articulo filtrarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo articulo = new Articulo();

            try
            {
                datos.setearProcedure("storedFiltrarPorId");
                datos.cargarParametros("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    

                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                }
                    return articulo;

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
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedure("storedAltaArticulo");

                datos.cargarParametros("@codigo", nuevo.Codigo);
                datos.cargarParametros("@nombre", nuevo.Nombre);
                datos.cargarParametros("@descripcion", nuevo.Descripcion);
                datos.cargarParametros("@marca", nuevo.Marca.Id);
                datos.cargarParametros("@categoria", nuevo.Categoria.Id);
                datos.cargarParametros("@imagen", nuevo.ImagenUrl);
                datos.cargarParametros("@precio", nuevo.Precio);

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



        public void modificar(Articulo nuevo, int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedure("storedModificar");
                datos.cargarParametros("@id", id);
                datos.cargarParametros("@codigo", nuevo.Codigo);
                datos.cargarParametros("@nombre", nuevo.Nombre);
                datos.cargarParametros("@descripcion", nuevo.Descripcion);
                datos.cargarParametros("@marca", nuevo.Marca.Id);
                datos.cargarParametros("@categoria", nuevo.Categoria.Id);
                datos.cargarParametros("@imagen", nuevo.ImagenUrl);
                datos.cargarParametros("@precio", nuevo.Precio);


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


        public void eliminar(int id)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedure("storedEliminarArticulo");
                datos.cargarParametros("@id",id);

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
