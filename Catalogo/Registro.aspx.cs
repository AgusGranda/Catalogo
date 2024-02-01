using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                    Random random = new Random();
                    string numeroRandom = random.Next(1,1000).ToString();

                    string ruta = Server.MapPath("./Images/Usuarios/");
                    string nombreFoto = "perfil-" + numeroRandom + "-" + nuevo.Email + ".jpg";

                    imgPerfil.PostedFile.SaveAs(ruta + nombreFoto);
                    nuevo.UrlImagenPerfil = nombreFoto;
                }

                if (!(usuarioNegocio.filtrar(nuevo.Email)))
                {
                    usuarioNegocio.registro(nuevo);
                    Response.Redirect("Index.aspx", false);

                }
                else
                    lblError.Text = "Este usuario ya existe";

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    
    }
}