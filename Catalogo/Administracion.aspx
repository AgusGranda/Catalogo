<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Catalogo.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Listado de productos</h2>
    <hr />

    <div class="row">
        <div class="col row g-3">
            <div class="col-auto">
                <input type="text" readonly class="form-control-plaintext" id="staticEmail2" value="Filtro de Articulos">
            </div>
            <div class="col-auto">
                <label for="inputPassword2" class="visually-hidden">Password</label>
                <input type="password" class="form-control" id="inputPassword2" placeholder="Articulo">
            </div>
            <div class="col-auto">
                <asp:Button ID="btnFiltroRapido" CssClass="btn btn-primary mb-4" runat="server" Text="Buscar" />
            </div>
        </div>
    </div>









    <div class="row">
        <div class="col">

            <asp:GridView ID="dgvArticulos" CssClass="table" runat="server" AutoGenerateColumns="false"
                DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5"
                >
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Accion" SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
            <a href="Formulario.aspx" class="btn btn-primary">Agregar</a>
        </div>
    </div>



</asp:Content>
