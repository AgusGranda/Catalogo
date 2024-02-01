<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Catalogo.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row pt-5">

        <div class="col-3"></div>

        <div class="col">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" type="email" placeholder="usuario@usuario.com"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingrese un email" ControlToValidate="txtEmail" runat="server" style="color:red; font-size:13px;"/>
                <asp:RegularExpressionValidator ErrorMessage="Formato de email erroneo" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" style="color:red; font-size:13px;" runat="server" />
                <asp:Label ID="lblError" runat="server" Text="" style="color:red; font-size:13px;"></asp:Label> 
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox ID="txtPass" class="form-control" runat="server" type="password" placeholder="*****"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Ingrese una contraseña" ControlToValidate="txtPass" runat="server" style="color:red; font-size:13px;" />
            </div>
            <div class="mb-3">
                <label for="imgPerfil" class="form-label">Foto Perfil</label>
                <input type="file" id="imgPerfil" class="form-control" runat="server" />
            </div>
            <div class="text-center">
                <asp:Button ID="btnRegistro" class="btn btn-primary text-center" runat="server" Text="Registrarme" OnClick="btnRegistro_Click" />
                
            </div>
        </div>

        <div class="col-3"></div>

    </div>
</asp:Content>
