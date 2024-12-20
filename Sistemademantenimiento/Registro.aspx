<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="SistemaDeMantenimiento.Registro" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro de Usuario</title>
    <link href="styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="login-container">
        <form id="formRegistro" runat="server" class="login-form">
            <h2>Registro</h2>

            <!-- Mensaje de error -->
            <asp:Label ID="ErrorMessage" runat="server" CssClass="error-message" Visible="false" />

            <!-- Campo Correo -->
            <div class="form-group">
                <input type="email" id="Correo" runat="server" class="input-field" placeholder="Correo electrónico" required />
            </div>

            <!-- Campo Contraseña -->
            <div class="form-group">
                <input type="password" id="Contraseña" runat="server" class="input-field" placeholder="Contraseña" required />
            </div>

            <!-- Campo Confirmar Contraseña -->
            <div class="form-group">
                <input type="password" id="ConfirmarContraseña" runat="server" class="input-field" placeholder="Confirmar contraseña" required />
            </div>

            <!-- Botón de registro -->
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn-login" OnClick="btnRegistrar_Click" />

            <!-- Enlace al login -->
            <div class="form-group" style="text-align:center; margin-top:10px;">
                <a href="Login.aspx">¿Ya tienes cuenta? Inicia sesión aquí</a>
            </div>
        </form>
    </div>
</body>
</html>
