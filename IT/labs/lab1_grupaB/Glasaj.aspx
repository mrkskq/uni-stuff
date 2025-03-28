<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="Lab1B.Glasaj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col text-center">
                <asp:Image ID="Image1" runat="server" src="https://upload.wikimedia.org/wikipedia/mk/6/60/%D0%9B%D0%BE%D0%B3%D0%BE-%D0%A4%D0%98%D0%9D%D0%9A%D0%98.jpg" />
                <div>
                    <asp:Label ID="lbProfesor" runat="server" Text="Проф. "></asp:Label>
                    <div>
                        <asp:ListBox ID="lbPredmeti" runat="server" OnSelectedIndexChanged="lbPredmeti_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                        <asp:ListBox ID="lbKrediti" runat="server" OnSelectedIndexChanged="lbKrediti_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                    </div>
                    <asp:Button ID="glasajKopce" runat="server" Text="Гласајте" OnClick="glasajKopce_Click" />

                    <hr />

                    Предмет:
                    <div>
                        <asp:TextBox ID="predmet" runat="server"></asp:TextBox>
                    </div>

                    </br>

                    Кредити:
                    <div>
                        <asp:TextBox ID="krediti" runat="server"></asp:TextBox>
                    </div>

                    </br>

                    <div>
                        <asp:Button ID="dodadiKopce" runat="server" Text="Додади" OnClick="dodadiKopce_Click" />
                    </div>

                    </br>

                    <div>
                        <asp:Button ID="izbrisiKopce" runat="server" Text="Избриши" OnClick="izbrisiKopce_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
