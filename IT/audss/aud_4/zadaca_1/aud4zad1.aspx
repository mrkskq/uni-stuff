<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aud4zad1.aspx.cs" Inherits="Primer.aud4zad1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <div>
                    Внеси име:
                    <asp:TextBox ID="name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Полето за име не смее да е празно!" ControlToValidate="name"></asp:RequiredFieldValidator>
                </div>
                <div>
                    Внеси лозинка:
                    <asp:TextBox ID="pasw1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Немате внесено лозинка!" ControlToValidate="pasw1"></asp:RequiredFieldValidator>
                </div>
                <div>
                    Потврди ја лозинката:
                    <asp:TextBox ID="pasw2" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Немате внесено потврда за лозинката!" ControlToValidate="pasw2"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Лозинките не се совпаѓаат!" ControlToCompare="pasw2" ControlToValidate="pasw1"></asp:CompareValidator>
                </div>
                <div>
                    <asp:Button ID="register" runat="server" Text="Регистрирај се" OnClick="register_Click" />
                    <asp:Label ID="lb_reg" runat="server" Text=" "></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
