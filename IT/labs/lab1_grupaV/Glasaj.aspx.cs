using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1V
{
	public partial class Glasaj : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				List<ListItem> predmeti = new List<ListItem>();
				predmeti.Add(new ListItem("АОК", "Дејан Спасов"));
				predmeti.Add(new ListItem("ДС2", "Марија Михова"));
				predmeti.Add(new ListItem("ООАИД", "Кире Триводалиев"));

				List<ListItem> krediti = new List<ListItem>();
                krediti.Add(new ListItem("6", "6"));
                krediti.Add(new ListItem("5", "5"));
                krediti.Add(new ListItem("4", "4"));

                lbPredmeti.DataSource = predmeti;
                lbPredmeti.DataValueField = "Value"; 
                lbPredmeti.DataTextField = "Text";
                lbPredmeti.DataBind();

                lbKrediti.DataSource = krediti;
                lbKrediti.DataValueField = "Value";
                lbKrediti.DataTextField = "Text";
                lbKrediti.DataBind();
            }
		}

        protected void kopceGlasaj_Click(object sender, EventArgs e)
        {
            if(lbPredmeti.SelectedIndex != -1)
            {
                Response.Redirect("UspeshnoGlasanje.aspx");
            }
            
        }

        protected void kopceDodadi_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbPredmet.Text) && !string.IsNullOrEmpty(lbKredit.Text))
            {
                lbPredmeti.Items.Add(lbPredmet.Text);
                lbKrediti.Items.Add(lbKredit.Text);
            }
            
        }

        protected void kopceIzbrisi_Click(object sender, EventArgs e)
        {
            if (lbPredmeti.SelectedIndex != -1)
            {
                lbPredmeti.Items.Remove(lbPredmeti.SelectedItem);
                lbKrediti.Items.Remove(lbKrediti.SelectedItem);
                lbProfesor.Text = "Проф. ";
            }
        }

        protected void lbPredmeti_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbProfesor.Text = " ";
            lbProfesor.Text += "Проф. " + lbPredmeti.SelectedItem.Value;
            lbKrediti.SelectedIndex = lbPredmeti.SelectedIndex;
        }

        protected void lbKrediti_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbPredmeti.SelectedIndex = lbKrediti.SelectedIndex;
            lbProfesor.Text = " ";
            lbProfesor.Text += "Проф. " + lbPredmeti.SelectedItem.Value;
          
        }
    }
}
