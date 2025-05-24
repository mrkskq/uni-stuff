<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="Lab1A.Glasaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col text-center">
                <asp:Image ID="Image1" runat="server" src="https://www.finki.ukim.mk/sites/default/files/styles/large/public/default_images/finki_52_1_2_1_62_0.png?itok=miZDgQ_6"/>
                <div>
                    <asp:Label ID="lblProfesor" runat="server" Text="Проф. д-р "> </asp:Label>
                </div>
                <div>
                    <asp:ListBox ID="lbPredmeti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbPredmeti_SelectedIndexChanged">
                        <asp:ListItem Value="Гоце Арменски">Интернет технологии</asp:ListItem>
                        <asp:ListItem Value="Костадин Мишев">Оперативни системи</asp:ListItem>
                        <asp:ListItem Value="Дејан Ѓорѓевиќ">Софтверско инженерство</asp:ListItem>
                        <asp:ListItem Value="Смилка Јанеска Саркањац">Маркетинг</asp:ListItem>
                    </asp:ListBox>
                    <asp:ListBox ID="lbKrediti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbKrediti_SelectedIndexChanged">
                        <asp:ListItem Value="6it">6</asp:ListItem>
                        <asp:ListItem Value="6os">6</asp:ListItem>
                        <asp:ListItem Value="5.5si">5.5</asp:ListItem>
                        <asp:ListItem Value="5.5ma">5.5</asp:ListItem>
                    </asp:ListBox>
                </div>
                <asp:Button ID="glasajKopce" runat="server" Text="Гласајте" OnClick="glasajKopce_Click" />
            </div>
        </div>
    </div>
</asp:Content>
