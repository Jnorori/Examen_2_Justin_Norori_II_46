<%@ Page Title="CRUD CLIENTES" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="Examen_2_Justin_Norori_II_46.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <h2 class="mb-4 text-primary">Clientes CRUD</h2>

        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="ClienteId"
            OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" OnRowDeleting="gvClientes_RowDeleting"
            AllowPaging="True" PageSize="5" OnPageIndexChanging="gvClientes_PageIndexChanging"
            CssClass="table table-striped table-bordered table-hover">
            <Columns>
                <asp:BoundField DataField="ClienteId" HeaderText="ID" ReadOnly="True" ItemStyle-Width="50px" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <h3 class="mt-5 mb-3 text-secondary">Cliente Details</h3>

        <asp:HiddenField ID="hfClienteId" runat="server" />

        <asp:Label ID="lblMensaje" runat="server" ForeColor="red" CssClass="mb-3"></asp:Label><br />

        <div class="form-group">
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Placeholder="First Name"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Placeholder="Last Name"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Placeholder="Phone"></asp:TextBox>
        </div>

        <asp:Button ID="btnGuardar" runat="server" Text="Save" OnClick="btnGuardar_Click" CssClass="btn btn-primary mr-2" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancel" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />

    </div>

</asp:Content>
