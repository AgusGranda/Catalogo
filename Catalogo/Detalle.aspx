<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Catalogo.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row text-center">
        <div class="col">
            <h2><%: Seleccionado.Nombre %></h2>
        </div>
    </div>

    <div class="row">

        <div class="col-1"></div>

        <div class="col-6">
            <figure class="figure">

                <img src="..." class="figure-img img-fluid rounded" ID="imagenProductoSeleccionado" alt="ImagenProducto" style="height:300px;  object-fit:contain;" runat="server">
                <figcaption class="figure-caption">Imagen con fines ilustrativos.</figcaption>
            </figure>
        </div>
        <div class="col-4 gx-5" style="margin: auto;">
            <div class="card" style="width: 18rem;">
                <div class="card-body">
                    <h5 class="card-title">$$  <%:Seleccionado.Precio%></h5>
                    <h6 class="card-subtitle mb-2 text-body-secondary"><%: Seleccionado.Marca.Descripcion %></h6>
                    <p class="card-text"><%: Seleccionado.Descripcion %></p>
                </div>
            </div>
        </div>


        <div class="col-1"></div>



    </div>
</asp:Content>
