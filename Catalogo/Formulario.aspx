<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Catalogo.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>Soy el formulario</h1>

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
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 ">
                <label for="txtCategoria" class="form-label">Categoria</label>
                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="col-4">
            <div class="mb-3 ">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 ">
                <label for="txtImagen" class="form-label">Imagen</label>
                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3 ">
                <asp:Image ID="imgProductoNuevo" runat="server" ImageUrl="..." />
            </div>
            <asp:Button ID="btnAceptar" class="btn btn-primary" runat="server" Text="Aceptar" />
            <a href="#" class="btn btn-secondary">Cancelar</a>
        </div>

        <div class="col-2"></div>
    </div>


</asp:Content>
