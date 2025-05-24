<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="laniKolokviumska.Glasaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <div>
           <asp:Image ID="Image1" runat="server" src="https://www.finki.ukim.mk/sites/default/files/styles/large/public/default_images/finki_52_1_2_1_62_0.png?itok=miZDgQ_6"/>
   </div>

    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtOcenka" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Оценка: од 5 до 10!" MinimumValue="5" MaximumValue="10" ControlToValidate="txtOcenka" ForeColor="Red" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="lstProfesori" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lstProfesori_SelectedIndexChanged">
                    <asp:ListItem>Дејан Спасов</asp:ListItem>
                    <asp:ListItem>Весна Димитрова</asp:ListItem>
                    <asp:ListItem>Костадин Мишев</asp:ListItem>
                    <asp:ListItem>Методија Јанчески</asp:ListItem>
                </asp:ListBox>
                <asp:ListBox ID="lstPredmeti" runat="server" AutoPostBack="True"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Button ID="kopceGlasaj" runat="server" Text="Гласајте" OnClick="kopceGlasaj_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Додади професор
                <asp:TextBox ID="profesorr" runat="server"></asp:TextBox>
                <asp:Button ID="dodadiProf" runat="server" Text="Додади" OnClick="dodadiProf_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Додади предмет
                <asp:TextBox ID="predmett" runat="server"></asp:TextBox>
                <asp:Button ID="dodadiPredmet" runat="server" Text="Додади" OnClick="dodadiPredmet_Click" />
                <asp:Button ID="izbrisiPredmet" runat="server" Text="Избриши предмет" OnClick="izbrisiPredmet_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
