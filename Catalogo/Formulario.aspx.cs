using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Catalogo
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                cargarDesplegables();
            }

            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                int id = int.Parse(Request.QueryString["id"]);
                Articulo seleccionado = articuloNegocio.filtrarPorId(id);

                txtCodigo.Text = seleccionado.Codigo;
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                ddlMarca.SelectedValue= seleccionado.Marca.Id.ToString();
                ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                txtImagen.Text = seleccionado.ImagenUrl;
                txtPrecio.Text = seleccionado.Precio.ToString();
                txtImagen_TextChanged(sender, e);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {

                Articulo nuevo = new Articulo();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Precio = decimal.Parse(txtPrecio.Text);



                nuevo.ImagenUrl = txtImagen.Text;

                if (Request.QueryString["id"] != null)
                    articuloNegocio.modificar(nuevo,int.Parse(Request.QueryString["id"]));
                else
                    articuloNegocio.agregar(nuevo);
               
                Response.Redirect("Index.aspx");

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

            
        }

        protected void cargarDesplegables()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            ddlMarca.DataSource = marcaNegocio.listar();
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();

            ddlCategoria.DataSource = categoriaNegocio.listar();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgProductoNuevo.ImageUrl = txtImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.eliminar(id);

                Response.Redirect("Index.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}