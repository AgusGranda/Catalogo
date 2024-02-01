using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace Catalogo
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public bool LogueadoAdmin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is Administracion || Page is Formulario)
            {
                if (!(negocio.Seguridad.usuarioAdmin(Session["usuario"])))
                {
                    
                    Session.Add("error", "No tienes los permisos requeridos");
                    Response.Redirect("Error.aspx");
                }
            }
            administracion();
            actualizarFotoNav();



        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Response.Redirect("Index.aspx");
        }

        protected void administracion()
        {
            if (!(negocio.Seguridad.usuarioAdmin(Session["usuario"])))
                LogueadoAdmin = false;
            else
                LogueadoAdmin = true;

        }
        protected void actualizarFotoNav()
        {
            if ((Usuario)Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                imgPerfil.ImageUrl = usuario.UrlImagenPerfil != null ? "~/Images/Usuarios/" + usuario.UrlImagenPerfil : "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
            }
            else
                imgPerfil.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
        }
    }
}