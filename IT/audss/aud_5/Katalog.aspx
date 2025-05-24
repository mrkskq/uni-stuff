<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Katalog.aspx.cs" Inherits="aud5.Katalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Техничка литература" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Научна фантастика" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Автомобили" OnClick="Button3_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
