<%@ Page Title="Admin Dashboard - Clientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdminClientes.aspx.vb" Inherits="Examen_2_Justin_Norori_II_46.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h1 class="mb-5 text-primary">Admin Dashboard - Clientes</h1>

        <asp:Button ID="btnIrAUsuarios" runat="server" Text="Ir a Usuarios" CssClass="btn btn-outline-primary mb-4"
            OnClick="btnIrAUsuarios_Click" />

        <!-- Sección Clientes -->
        <h2 class="text-primary mb-3">Gestión de Clientes</h2>
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="ClienteId"
            OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" OnRowDeleting="gvClientes_RowDeleting"
            AllowPaging="True" PageSize="5" OnPageIndexChanging="gvClientes_PageIndexChanging"
            CssClass="table table-striped table-bordered table-hover mb-4">
            <Columns>
                <asp:BoundField DataField="ClienteId" HeaderText="ID" ReadOnly="True" ItemStyle-Width="50px" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <asp:HiddenField ID="hfClienteId" runat="server" />
        <asp:Label ID="lblClienteMensaje" runat="server" ForeColor="red" CssClass="mb-3"></asp:Label>

        <div class="form-row mb-3">
            <div class="col-md-3 mb-2">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox>
            </div>
            <div class="col-md-3 mb-2">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox>
            </div>
            <div class="col-md-3 mb-2">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
            </div>
            <div class="col-md-3 mb-2">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Placeholder="Phone"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnGuardarCliente" runat="server" Text="Guardar Cliente" CssClass="btn btn-primary mr-2" OnClick="btnGuardarCliente_Click" />
        <asp:Button ID="btnCancelarCliente" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarCliente_Click" />

    </div>

</asp:Content>
