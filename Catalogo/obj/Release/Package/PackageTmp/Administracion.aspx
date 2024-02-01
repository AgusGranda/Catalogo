<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="Catalogo.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Listado de productos</h2>
    <hr />




    <div class="row align-items-end">
        <div class="col-6">
            <label for="txtFiltro" class="form-label">Filtro de Articulos</label>
            <div class="mb-3">
                <asp:TextBox ID="txtFiltroRapido" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="col-6">

            <div class="mb-3">
                <asp:CheckBox ID="chFiltroAvanzado" runat="server" AutoPostBack="true" />
                <label for="chFiltroAvanzado">Filtro Avanzado</label>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <%if (chFiltroAvanzado.Checked)
                {  %>
            <div class="row">

                <div class="col-3">
                    <label for="ddlCriterio" class="form-label">Criterio</label>
                    <div class="mb-3">
                        <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <label for="ddlSubcriterio" class="form-label">Subcriterio</label>
                    <div class="mb-3">
                        <asp:DropDownList ID="ddlSubcriterio" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <label for="txtFiltroAvanzado" class="form-label">Filtro</label>
                    <div class="mb-3">
                        <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-3">
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button ID="btnBuscarAvanzado" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarAvanzado_Click" />
                    </div>
                </div>

            </div>

            <%} %>


            <div class="row">
                <div class="col">

                    <asp:GridView ID="dgvArticulos" CssClass="table" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                        OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5">
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



        </ContentTemplate>
    </asp:UpdatePanel>









</asp:Content>
