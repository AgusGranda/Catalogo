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
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            MarcaNegocio marca = new MarcaNegocio();


            Session.Add("articulos", negocio.listar());
            dgvArticulos.DataSource = Session["articulos"];
            dgvArticulos.DataBind();

            if (!IsPostBack)
            {
                ddlCriterio.Items.Add("Nombre");
                ddlCriterio.Items.Add("Precio");
                ddlCriterio.Items.Add("Marca");
                ddlCriterio.Items.Add("Categoria");
            }
            if (chFiltroAvanzado.Checked)
                txtFiltroRapido.Enabled = false;
            else
                txtFiltroRapido.Enabled=true;

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

      

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtroRapido = txtFiltroRapido.Text;
                List<Articulo> lista = (List<Articulo>)Session["articulos"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtroRapido.ToUpper()));
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }


      
        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (ddlCriterio.SelectedValue.ToString() == "Nombre")
            {
                txtFiltroAvanzado.Enabled = true;
                ddlSubcriterio.Items.Clear();
                ddlSubcriterio.Items.Add("Contiene");
                ddlSubcriterio.Items.Add("Comienza con");
                ddlSubcriterio.Items.Add("Termina con");

            }
            else if (ddlCriterio.SelectedValue.ToString() == "Precio")
            {
                txtFiltroAvanzado.Enabled = true;
                ddlSubcriterio.Items.Clear();
                ddlSubcriterio.Items.Add("Mayor a");
                ddlSubcriterio.Items.Add("Menor a");
                ddlSubcriterio.Items.Add("Igual a");
            }
            else if (ddlCriterio.SelectedValue.ToString() == "Marca")
            {
                txtFiltroAvanzado.Enabled = false;
                MarcaNegocio marca = new MarcaNegocio();
                ddlSubcriterio.DataSource = marca.listar();
                ddlSubcriterio.DataBind();
            }
            else if (ddlCriterio.SelectedValue.ToString() == "Categoria")
            {
                txtFiltroAvanzado.Enabled = false;
                CategoriaNegocio categoria = new CategoriaNegocio();
                ddlSubcriterio.DataSource = categoria.listar();
                ddlSubcriterio.DataBind();
            }
        }

        protected void btnBuscarAvanzado_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            string criterio = ddlCriterio.SelectedItem.Value.ToString();
            string subcriterio = ddlSubcriterio.SelectedItem.Value.ToString();
            string filtroAvanzado = txtFiltroAvanzado.Text.ToString();
            
            dgvArticulos.DataSource = negocio.filtrar(criterio,subcriterio,filtroAvanzado);
            dgvArticulos.DataBind();
        }

        
    }
}