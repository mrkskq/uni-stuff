<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="aud4zad5.aspx.cs" Inherits="Primer.aud4zad5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="row">
        <div class="col">
            <div>
                Име на испит:
                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Полето за име е празно!" ControlToValidate="name" ForeColor="Red" Display="None"></asp:RequiredFieldValidator>
            </div>
            <div>
                Добиена оцена:
                 <asp:TextBox ID="grade" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Полето за оцена е празно!" ControlToValidate="grade" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Оцената не е во опсегот [5-10]!" ControlToValidate="grade" ForeColor="Red" MaximumValue="10" MinimumValue="5" Type="Integer" Display="None"></asp:RangeValidator>
            </div>
            <div>
                Датум на полагање:
                <asp:TextBox ID="date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Полето за датум е празно!" ControlToValidate="date" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Датумот НЕ е пред 05.05.2025 (ММ-ДД-ГГГГ)!" ControlToValidate="date" ForeColor="Red" Operator="LessThan" Type="Date" ValueToCompare="05.05.2025" Display="None"></asp:CompareValidator>
            </div>
            <div>
                <asp:Button ID="validacija" runat="server" Text="Валидирај" OnClick="validacija_Click" />
                <asp:Label ID="lb_valid" runat="server" Text=" "></asp:Label>
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    </div>
</div>
</asp:Content>
