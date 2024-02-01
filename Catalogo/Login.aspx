<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Catalogo.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row pt-5">
        <div class="col-3"></div>

        <div class="col">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" placeholder="usuario@usuario.com"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingrese un email" ControlToValidate="txtEmail" style="color:red; font-size:13px;" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox ID="txtPass" class="form-control" runat="server" placeholder="*****"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingrese una contraseña" ControlToValidate="txtPass" style="color:red; font-size:13px;" runat="server" />
            </div>
            <div class="text-center">

            <asp:Button ID="btnIngresar" class="btn btn-primary text-center" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
            </div>
        </div>

        <div class="col-3"></div>
    </div>


</asp:Content>
