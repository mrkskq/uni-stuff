using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aud5
{
    public partial class Proizvodi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);
            string ime = Request.QueryString["ime"];

            imeKategorija.Text = ime;

            if (!IsPostBack)
            {
                string[] tehnickaLiteratura = {
                    "Beginning ASP.NET 2.0 in C# From Novice To Professional",
                    "Introduction To Automata Theory, Languages and Computation",
                    "Cisco CCNA 3.0 Study Guide",
                    "Broadband Teleceommunications Handbook" };
                string[] tehnickaLiteraturaCeni = { "2300", "1280", "4920", "3090" };

                string[] naucnaFantastika = {
                    "Star Wars, Jedi vs. Sith: The Essential",
                    "Harry Potter and the Prisoner of Azkaban",
                    "Ghosts of Onyx",
                    "Fleet of Worlds" };
                string[] naucnaFantastikaCeni = { "1400", "2930", "2500", "1300" };

                string[] avtomobili ={
                    "The Art of the Sports Car: The Greatest Designs of the 20th Century",
                    "Automobile, September 2007 Issue",
                    "New Car Buying Guide 2007",
                    "The New Illustrated Encyclopedia of Automobiles " };
                string[] avtomobiliCeni = { "2300", "4100", "2010", "2210" };

                string[] proizvodi;
                string[] ceni;

                if (id == 1)
                {
                    proizvodi = tehnickaLiteratura;
                    ceni = tehnickaLiteraturaCeni;
                }
                else if (id == 2)
                {
                    proizvodi = naucnaFantastika;
                    ceni = naucnaFantastikaCeni;
                }
                else
                {
                    proizvodi = avtomobili;
                    ceni = avtomobiliCeni;
                }

                listaProizvodi.DataSource = proizvodi;
                listaCeni.DataSource = ceni;

                listaProizvodi.DataBind();
                listaCeni.DataBind();

                prikaziBrojac();
                prikaziKosnicka();

            }

        }


            protected void kopceKatalog_Click(object sender, EventArgs e)
        {
            Response.Redirect("Katalog.aspx");
        }

        protected void listaProizvodi_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaCeni.SelectedIndex = listaProizvodi.SelectedIndex;

            if (Session["brPromeni"] == null)
            {
                Session["brPromeni"] = 1;
            }
            else
            {
                Session["brPromeni"] = (int)Session["brPromeni"] + 1;
                prikaziBrojac();
            }
        }

        private void prikaziBrojac()
        {
            if (Session["brPromeni"] == null)
            {
                return;
            }
            broj.Text = ((int)Session["brPromeni"]).ToString();
        }

        protected void kopceKocnicka_Click(object sender, EventArgs e)
        {
            if (Session["kosnicka"] == null)
            {
                Session["kosnicka"] = new List<ListItem>() { };
            }

            List<ListItem> kosnicka = (List<ListItem>)Session["kosnicka"];

            String ime = listaProizvodi.SelectedValue;
            String cena = listaCeni.SelectedValue;

            kosnicka.Add(new ListItem(ime, cena));

            Session["kosnicka"] = kosnicka;
            prikaziKosnicka();
        }

        private void prikaziKosnicka()
        {
            if (Session["kosnicka"] == null)
            {
                Session["kosnicka"] = new List<ListItem>() { };
            }

            List<ListItem> dataSource = (List<ListItem>)Session["kosnicka"];
            listaKosnicka.DataValueField = "Value";
            listaKosnicka.DataTextField = "Text";
            listaKosnicka.DataSource = dataSource;
            listaKosnicka.DataBind();

        }
    }
}
