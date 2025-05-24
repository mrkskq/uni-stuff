<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aud4zad4.aspx.cs" Inherits="Primer.aud4zad4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                Внеси телефонски број:
                <asp:TextBox ID="number" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Невалиден формат на број!" ForeColor="Red" ControlToValidate="number" ValidationExpression="07[124567]\d{6}"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Button ID="validiraj" runat="server" Text="Валидирај" />
            </div>
        </div>
    </div>
</asp:Content>
