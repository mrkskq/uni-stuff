<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Predmeti.aspx.cs" Inherits="aud5.Predmeti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td>
                <asp:ListBox ID="listaPredmeti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listaPredmeti_SelectedIndexChanged"></asp:ListBox>
                <asp:ListBox ID="listaOcenki" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listaOcenki_SelectedIndexChanged"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                Внесете оценка:
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="ocenka" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Оценката мора да е меѓу 5 и 10!" ControlToValidate="ocenka" ForeColor="Red" MaximumValue="10" MinimumValue="5" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="kopceOcenka" runat="server" Text="Внеси оценка" OnClick="kopceOcenka_Click"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="kopceProsek" runat="server" Text="Пресметај просек" OnClick="kopceProsek_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
