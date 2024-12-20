using System;
using System.Web.UI;
using SistemaDeMantenimiento.Models;

namespace SistemaDeMantenimiento
{
    public partial class Registro : Page
    {
        
        protected System.Web.UI.WebControls.TextBox Correo; 
        protected System.Web.UI.WebControls.TextBox Contraseña; 
        protected System.Web.UI.WebControls.Label ErrorMessage; 

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string correo = Correo.Text;
            string contraseña = Contraseña.Text;

            
            if (Usuario.ExisteCorreo(correo))
            {
                ErrorMessage.Text = "Este correo ya está registrado.";
                ErrorMessage.Visible = true;
            }
            else
            {
                
                Usuario nuevoUsuario = new Usuario
                {
                    Correo = correo,
                    Contraseña = contraseña
                };
                Usuario.RegistrarUsuario(nuevoUsuario);

                
                Response.Redirect("Login.aspx");
            }
        }
    }
}
