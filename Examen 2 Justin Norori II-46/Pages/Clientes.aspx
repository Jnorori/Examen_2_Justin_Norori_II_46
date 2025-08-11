<%@ Page Title="Clientes - Vista" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="Examen_2_Justin_Norori_II_46.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">

        <div class="card shadow-sm">
            <div class="card-header bg-primary text-white d-flex align-items-center">
                <i class="bi bi-people-fill fs-3 me-2"></i>
                <h3 class="mb-0">Listado de Clientes</h3>
            </div>
            <div class="card-body">

                <p class="lead text-muted">Aquí puedes ver la información básica de tus clientes. Para más opciones, contacta a un administrador.</p>

                <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="ClienteId"
                    AllowPaging="True" PageSize="5" OnPageIndexChanging="gvClientes_PageIndexChanging"
                    CssClass="table table-striped table-bordered table-hover table-responsive">
                    <Columns>
                        <asp:BoundField DataField="ClienteId" HeaderText="ID" ReadOnly="True" ItemStyle-Width="50px" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    </Columns>
                </asp:GridView>

            </div>
            <div class="card-footer text-muted text-center">
                <small>© 2025 ClientesApp</small>
            </div>
        </div>

    </div>

</asp:Content>
