<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Examen_2_Justin_Norori_II_46.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Clientes App</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .login-container {
            margin-top: 100px;
            max-width: 400px;
            padding: 30px;
            background: white;
            border-radius: 8px;
            box-shadow: 0 0 15px rgba(0,0,0,0.1);
        }
        .login-header {
            margin-bottom: 25px;
            text-align: center;
            font-weight: 600;
            color: #343a40;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="d-flex justify-content-center">
        <div class="login-container">
            <h2 class="login-header">Login</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="red" CssClass="mb-3 d-block text-center"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mb-3" Placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-4" TextMode="Password" Placeholder="Password"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100" Text="Sign In" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>

