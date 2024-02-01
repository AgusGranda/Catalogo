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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            
            try
            {
                Page.Validate();
                if (!(Page.IsValid))
                    return;
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario nuevo = new Usuario();

                nuevo.Email = txtEmail.Text;
                nuevo.Pass = txtPass.Text;

                if (imgPerfil.Value != "")
                {
                    string ruta = Server.MapPath("./Images/Usuarios/");
                    imgPerfil.PostedFile.SaveAs(ruta + "perfil-" + nuevo.Id + ".jpg");
                    nuevo.UrlImagenPerfil = "perfil-" + nuevo.Id + ".jpg";
                }


                usuarioNegocio.registro(nuevo);
                Response.Redirect("Index.aspx",false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}