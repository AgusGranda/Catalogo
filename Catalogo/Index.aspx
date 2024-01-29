﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Catalogo.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">
          <% foreach (dominio.Articulo elemento in lista)
      {  %>

        <div class="col">
            <div class="card" style="width: 18rem;">
                <img src="<%=elemento.ImagenUrl %>" class="card-img-top" alt="ImagenProducto">
                <div class="card-body">
                    <h5 class="card-title"><%: elemento.Nombre %></h5>
                    <p class="card-text"><%: elemento.Descripcion %></p>
                    <a href="Detalle.aspx?id=<%:elemento.Id %>" class="btn btn-primary">Detalle</a>
                </div>
            </div>
        </div>
      


        <%} %>
    </div>

</asp:Content>
