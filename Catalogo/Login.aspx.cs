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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();

                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                
                if(usuarioNegocio.login(usuario))
                {
                    Session.Add("usuario",usuario);
                    Response.Redirect("Index.aspx" , false);
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
           



        }
    }
}