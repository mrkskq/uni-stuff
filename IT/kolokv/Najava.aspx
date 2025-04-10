<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="laniKolokviumska.Najava" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<table>
    <tr>
        <td>Име</td>
        <td>
            <asp:TextBox ID="ime" runat="server"></asp:TextBox>

        
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Внесете име" ControlToValidate="ime" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="ime" Display="None" ValidationExpression="^[A-Za-z]+$" ForeColor="Red"></asp:RegularExpressionValidator>

        </td>
    </tr>

    <tr>
    <td>Лозинка</td>
    <td>
        <asp:TextBox ID="lozinka" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Внесете лозинка" ControlToValidate="lozinka" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="lozinka" Display="None" ValidationExpression="^[A-Za-z0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator>
    </td>
</tr>

    <tr>
    <td>е-адреса</td>
    <td>
        <asp:TextBox ID="mail" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Display="None" ControlToValidate="mail" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Невалиден формат" ControlToValidate="mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
    </td>
</tr>
    <tr>
        <td>
            <asp:Button ID="kopceNajava" runat="server" Text="Најавете се" OnClick="kopceNajava_Click" />
        </td>
    </tr>
</table>


</asp:Content>
