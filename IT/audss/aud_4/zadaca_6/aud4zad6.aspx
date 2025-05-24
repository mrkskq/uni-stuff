<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aud4zad6.aspx.cs" Inherits="Primer.aud4zad6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <div>
                    Валидација 1:
                    <asp:TextBox ID="val1" runat="server" ValidationGroup="grupa1"></asp:TextBox>
                    <asp:Button ID="group1" runat="server" Text="Група 1" ValidationGroup="grupa1" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Првото поле е задолжително!" ControlToValidate="val1" ForeColor="Red" ValidationGroup="grupa1"></asp:RequiredFieldValidator>
                </div>
                <div>
                    Валидација 2:
                    <asp:TextBox ID="val2" runat="server" ValidationGroup="grupa2"></asp:TextBox>
                    <asp:Button ID="group2" runat="server" Text="Група 2" ValidationGroup="grupa2" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Второто поле е задолжително!" ControlToValidate="val2" ForeColor="Red" ValidationGroup="grupa2"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
