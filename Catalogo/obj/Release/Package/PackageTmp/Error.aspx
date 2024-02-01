<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Catalogo.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    


    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="card text-bg-dark">
                <img src="https://st2.depositphotos.com/3272603/5832/v/450/depositphotos_58322461-stock-illustration-sick-computer-icon.jpg" class="card-img" alt="ImagenError" style="max-height:600px; object-fit:cover;">
                <div class="card-img-overlay">
                    <h5 class="card-title" style="color:black">Uppss!!</h5>
                    <asp:Label CssClass="card-text mb-3" ID="lblError" runat="server" Text="" style="color:black; font-size:20px;"></asp:Label> <br />
                    <a href="Index.aspx" class="btn btn-secondary card-text">Regresar</a>
                </div>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
