<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Catalogo.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col-4">

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox ID="txtCodigo" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 ">
                <label for="exampleCheck1" class="form-label">Descripcion</label>
                <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 ">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server"></asp:DropDownList>

            </div>
            <div class="mb-3 ">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

        </div>
        <div class="col-4">
            <div class="mb-3 ">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 ">
                <label for="txtImagen" class="form-label">Imagen</label>
                <input ID="txtImagen" type="File" class="form-control" runat="server" />
            </div>
            <div class="mb-3 ">
                <asp:Image ID="imgProductoNuevo" runat="server" ImageUrl="..." />
            </div>
            <asp:Button ID="btnAceptar" class="btn btn-primary" runat="server" Text="Aceptar" />
            <a href="Administracion.aspx" class="btn btn-secondary">Cancelar</a>
        </div>

        <div class="col-2"></div>
    </div>


</asp:Content>
