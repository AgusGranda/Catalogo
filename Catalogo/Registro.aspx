<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Catalogo.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">

        <div class="col-4"></div>
        <div class="col">
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" placeholder="usuario"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" placeholder="usuario@usuario.com"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox ID="txtPass" class="form-control" runat="server" placeholder="*****"></asp:TextBox>
            </div>
            <div class="text-center">

                <asp:Button ID="btnRegistro" class="btn btn-primary text-center" runat="server" Text="Registrarme" />
            </div>
        </div>
        <div class="col-4"></div>

    </div>

</asp:Content>
