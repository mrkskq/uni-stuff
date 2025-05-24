using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace laniKolokviumska
{
    public partial class Glasaj : System.Web.UI.Page
    {
        List<List<ListItem>> lista = new List<List<ListItem>>();


        List<ListItem> DS_predmeti = new List<ListItem>
        {
            new ListItem("AOK", "AOK"),
            new ListItem("Mrezi", "Mrezi"),
            new ListItem("DM", "DM"),
        };

        List<ListItem> VD_predmeti = new List<ListItem>
        {
            new ListItem("OS", "OS"),
            new ListItem("IM", "IM"),
            new ListItem("Kalkulus", "Kalkulus"),
        };

        List<ListItem> KM_predmeti = new List<ListItem>
        {
            new ListItem("OS", "OS"),
            new ListItem("Mrezi", "Mrezi"),
            new ListItem("VP", "VP"),
        };

        List<ListItem> MJ_predmeti = new List<ListItem>
        {
            new ListItem("BS", "BS"),
            new ListItem("Evlada", "Evlada"),
            new ListItem("DM", "DM"),
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void lstProfesori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProfesori.SelectedItem.Text == "Дејан Спасов")
            {
                lstPredmeti.DataSource = DS_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Весна Димитрова")
            {
                lstPredmeti.DataSource = VD_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Костадин Мишев")
            {
                lstPredmeti.DataSource = KM_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Методија Јанчески")
            {
                lstPredmeti.DataSource = MJ_predmeti;
                lstPredmeti.DataBind();
            }
        }

        protected void kopceGlasaj_Click(object sender, EventArgs e)
        {
            if (lstPredmeti.SelectedIndex != -1)
            {
                Session["predmet"] = lstPredmeti.SelectedItem.Text;
                Response.Redirect("UspeshnoGlasanje.aspx");
            }
        }

        protected void dodadiProf_Click(object sender, EventArgs e)
        {
            lstProfesori.Items.Add(profesorr.Text);
        }

        protected void dodadiPredmet_Click(object sender, EventArgs e)
        {
            if (lstProfesori.SelectedItem.Text == "Дејан Спасов")
            {
                DS_predmeti.Add(new ListItem(predmett.Text, predmett.Text));
                lstPredmeti.DataSource = VD_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Весна Димитрова")
            {
                VD_predmeti.Add(new ListItem(predmett.Text, predmett.Text));
                lstPredmeti.DataSource = VD_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Костадин Мишев")
            {
                KM_predmeti.Add(new ListItem(predmett.Text, predmett.Text));
                lstPredmeti.DataSource = KM_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Методија Јанчески")
            {
                MJ_predmeti.Add(new ListItem(predmett.Text, predmett.Text));
                lstPredmeti.DataSource = MJ_predmeti;
                lstPredmeti.DataBind();
            }
        }

        protected void izbrisiPredmet_Click(object sender, EventArgs e)
        {

            if (lstProfesori.SelectedItem.Text == "Дејан Спасов")
            {

                DS_predmeti.RemoveAt(lstPredmeti.SelectedIndex);
                lstPredmeti.DataSource = DS_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Весна Димитрова")
            {
                VD_predmeti.RemoveAt(lstPredmeti.SelectedIndex);
                lstPredmeti.DataSource = VD_predmeti;
                lstPredmeti.DataBind();

            }
            if (lstProfesori.SelectedItem.Text == "Костадин Мишев")
            {
                KM_predmeti.RemoveAt(lstPredmeti.SelectedIndex);
                lstPredmeti.DataSource = KM_predmeti;
                lstPredmeti.DataBind();
            }
            if (lstProfesori.SelectedItem.Text == "Методија Јанчески")
            {
                MJ_predmeti.RemoveAt(lstPredmeti.SelectedIndex);
                lstPredmeti.DataSource = MJ_predmeti;
                lstPredmeti.DataBind();
            }



        }
    }
}
