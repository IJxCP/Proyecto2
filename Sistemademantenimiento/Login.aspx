<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaDeMantenimiento.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        .login-container {
            background-color: white;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 300px;
        }
        .login-container h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        .login-container input {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 14px;
        }
        .login-container input[type="password"] {
            -webkit-text-security: disc; 
        }
        .login-container input[type="button"], .login-container button {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }
        .login-container input[type="button"]:hover, .login-container button:hover {
            background-color: #45a049;
        }
        .error-message {
            color: red;
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Iniciar sesión</h2>
            <div>
                <label for="Correo">Correo:</label>
                <asp:TextBox ID="Correo" runat="server" placeholder="Correo electrónico" />
            </div>
            <div>
                <label for="Contraseña">Contraseña:</label>
                <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" placeholder="Contraseña" />
            </div>
            <div>
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" OnClick="btnLogin_Click" />
            </div>
            <div>
                <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red" CssClass="error-message" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
