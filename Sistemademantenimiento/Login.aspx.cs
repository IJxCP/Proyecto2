using System;
using System.Web.UI;
using SistemaDeMantenimiento.Models;

namespace SistemaDeMantenimiento
{
    public partial class Login : Page
    {
        
        protected System.Web.UI.WebControls.TextBox Correo;
        protected System.Web.UI.WebControls.TextBox Contraseña; 
        protected System.Web.UI.WebControls.Label ErrorMessage; 

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string correo = Correo.Text;
            string contraseña = Contraseña.Text;

            
            bool esValido = Usuario.VerificarCredenciales(correo, contraseña);

            if (esValido)
            {
                
                Response.Redirect("PanelDeUsuario.aspx"); 
            }
            else
            {
               
                ErrorMessage.Text = "Correo o contraseña incorrectos. Si no tienes cuenta, por favor regístrate.";
                ErrorMessage.Visible = true;
            }
        }

        
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}
