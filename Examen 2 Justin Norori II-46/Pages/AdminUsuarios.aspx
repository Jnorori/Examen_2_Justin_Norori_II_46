<%@ Page Title="Admin Dashboard - Usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdminUsuarios.aspx.vb" Inherits="Examen_2_Justin_Norori_II_46.AdminUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h1 class="mb-5 text-danger">Admin Dashboard - Usuarios</h1>

        <asp:Button ID="btnIrAClientes" runat="server" Text="Ir a Clientes" CssClass="btn btn-outline-danger mb-4"
            OnClick="btnIrAClientes_Click" />

        <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesión" CssClass="btn btn-outline-secondary mb-4 float-right"
            OnClick="btnLogout_Click" />

        <h2 class="text-danger mb-3">Gestión de Usuarios</h2>
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="UsuarioId"
            OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged" OnRowDeleting="gvUsuarios_RowDeleting"
            AllowPaging="True" PageSize="5" OnPageIndexChanging="gvUsuarios_PageIndexChanging"
            CssClass="table table-striped table-bordered table-hover mb-4">
            <Columns>
                <asp:BoundField DataField="UsuarioId" HeaderText="ID" ReadOnly="True" ItemStyle-Width="50px" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Role" HeaderText="Role" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <asp:HiddenField ID="hfUsuarioId" runat="server" />
        <asp:Label ID="lblUsuarioMensaje" runat="server" ForeColor="red" CssClass="mb-3"></asp:Label>

        <div class="form-row mb-3">
            <div class="col-md-4 mb-2">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="Username"></asp:TextBox>
            </div>
            <div class="col-md-4 mb-2">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Password"></asp:TextBox>
            </div>
            <div class="col-md-4 mb-2">
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Admin">Admin</asp:ListItem>
                    <asp:ListItem Value="User">User</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <asp:Button ID="btnGuardarUsuario" runat="server" Text="Guardar Usuario" CssClass="btn btn-danger mr-2" OnClick="btnGuardarUsuario_Click" />
        <asp:Button ID="btnCancelarUsuario" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarUsuario_Click" />

    </div>

</asp:Content>
