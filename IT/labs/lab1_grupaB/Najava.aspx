<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="Lab1B.Najava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <div>
                    <asp:Label ID="lbIme" runat="server" Text="Име" Width="100px"></asp:Label>
                    <asp:TextBox ID="ime" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Внесете име" ControlToValidate="ime" ForeColor="Red" Width="200px"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="lbLozinka" runat="server" Text="Лозинка" Width="100px"></asp:Label>
                    <asp:TextBox ID="lozinka" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Внесете лозинка" ControlToValidate="lozinka" ForeColor="Red" Width="200px"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="lbEmail" runat="server" Text="е-маил" Width="100px"></asp:Label>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Невалиден формат" ControlToValidate="email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="email" ForeColor="Red" Width="200px" Display="None"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="najavaKopce" runat="server" Text="Најавете се" OnClick="najavaKopce_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
