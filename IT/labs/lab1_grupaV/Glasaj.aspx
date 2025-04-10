<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="Lab1V.Glasaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Image ID="Image1" runat="server" src="https://upload.wikimedia.org/wikipedia/mk/6/60/%D0%9B%D0%BE%D0%B3%D0%BE-%D0%A4%D0%98%D0%9D%D0%9A%D0%98.jpg"/>

    <table>
        <tr>
            <td>
                <asp:Label ID="lbProfesor" runat="server" Text="Проф. "></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="lbPredmeti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbPredmeti_SelectedIndexChanged"></asp:ListBox>
            </td>
            <td>
                <asp:ListBox ID="lbKrediti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbKrediti_SelectedIndexChanged"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="kopceGlasaj" runat="server" Text="Гласајте" OnClick="kopceGlasaj_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Предмет:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="lbPredmet" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Кредити:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="lbKredit" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="kopceDodadi" runat="server" Text="Додади" OnClick="kopceDodadi_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="kopceIzbrisi" runat="server" Text="Избриши" OnClick="kopceIzbrisi_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
