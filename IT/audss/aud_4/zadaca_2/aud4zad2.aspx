<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aud4zad2.aspx.cs" Inherits="Primer.aud4zad2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <asp:DropDownList ID="gradovi" runat="server">
                    <asp:ListItem>-град-</asp:ListItem>
                    <asp:ListItem Value="oh">Охрид</asp:ListItem>
                    <asp:ListItem Value="ve">Велес</asp:ListItem>
                    <asp:ListItem Value="te">Тетово</asp:ListItem>
                    <asp:ListItem Value="sk">Скопје</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Изберете град!" ControlToValidate="gradovi" ForeColor="Red" InitialValue="-град-"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Button ID="registracija" runat="server" Text="Регистрирај се" />
            </div>
        </div>
    </div>
</asp:Content>
