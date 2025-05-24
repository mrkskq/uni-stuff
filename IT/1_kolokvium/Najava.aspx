<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="aud5.Najava" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<table>
    <tr>
        <td>
            Име
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="ime" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Немате внесено име!" ControlToValidate="ime" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="ime" Display="None" ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
        </td>
        
    </tr>
    <tr>
        <td>
            Лозинка
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="lozinka" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Немате внесено лозинка!" ControlToValidate="lozinka" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="lozinka" Display="None" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
        </td>
        
    </tr>
    <tr>
        <td>
            Е-адреса
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="mail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Немате внесено е-маил!" ControlToValidate="mail" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Емаил-от не е во правилен формат!" ControlToValidate="mail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
        
    </tr>

    <tr>
        <td>
            <asp:Button ID="kopceMat" runat="server" Text="Математика" BackColor="#0066FF" OnClick="kopceMat_Click" />
            <asp:Button ID="kopceFiz" runat="server" Text="Физика" BackColor="#0066FF" OnClick="kopceFiz_Click" />
            <asp:Button ID="kopceInf" runat="server" Text="Информатика" BackColor="#0066FF" OnClick="kopceInf_Click" />
        </td>
    </tr>
</table>

</asp:Content>
