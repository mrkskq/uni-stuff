<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aud4zad3.aspx.cs" Inherits="Primer.aud4zad3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <div>
                    Име на испит:
                    <asp:TextBox ID="name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Полето за име е празно!" ControlToValidate="name" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div>
                    Добиена оцена:
                     <asp:TextBox ID="grade" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Оцената не е во опсегот [5-10]!" ControlToValidate="grade" ForeColor="Red" MaximumValue="10" MinimumValue="5" Type="Integer"></asp:RangeValidator>
                </div>
                <div>
                    Датум на полагање:
                    <asp:TextBox ID="date" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Датумот НЕ е пред 05.05.2025 (ММ-ДД-ГГГГ)!" ControlToValidate="date" ForeColor="Red" Operator="LessThan" Type="Date" ValueToCompare="05.05.2025"></asp:CompareValidator>
                </div>
                <div>
                    <asp:Button ID="validacija" runat="server" Text="Валидирај" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
