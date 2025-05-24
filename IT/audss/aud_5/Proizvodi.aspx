<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proizvodi.aspx.cs" Inherits="aud5.Proizvodi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="imeKategorija" runat="server" Text=" "></asp:Label>
    
    <table>
        <tr>
            <td>
                Производи
            </td>
            <td>
                Цени
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="listaProizvodi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listaProizvodi_SelectedIndexChanged"></asp:ListBox>
            </td>
            <td>
                <asp:ListBox ID="listaCeni" runat="server" AutoPostBack="True"></asp:ListBox>
                <asp:Label ID="broj" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Button ID="kopceKatalog" runat="server" Text="Каталог" OnClick="kopceKatalog_Click" BackColor="#CC33FF" />
                 <asp:Button ID="kopceKocnicka" runat="server" Text="Додади во кошничка" OnClick="kopceKocnicka_Click" BackColor="#CCCCCC" />
            </td>
        </tr>
        <tr>
            <td>
                 <asp:ListBox ID="listaKosnicka" runat="server"></asp:ListBox>
            </td>
        </tr>
    </table>

</asp:Content>
