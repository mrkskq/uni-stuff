using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1B
{
	public partial class Glasaj : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lbPredmeti.Items.Add(new ListItem("Интернет технологии","Гоце Арменски"));
				lbPredmeti.Items.Add(new ListItem("Оперативни системи","Сашо Граматиков"));
				lbPredmeti.Items.Add(new ListItem("Софтверско инженерство","Дејан Ѓорѓевиќ"));
				lbPredmeti.Items.Add(new ListItem("Бизнис статистика","Александра Поповска Митровиќ"));

				lbKrediti.Items.Add(new ListItem("5","5it"));
				lbKrediti.Items.Add(new ListItem("6","6os"));
				lbKrediti.Items.Add(new ListItem("6","6si"));
				lbKrediti.Items.Add(new ListItem("5.5","5.5bs"));
			}


		}
        protected void dodadiKopce_Click(object sender, EventArgs e)
        {
			if (predmet.Text.Length != 0 && krediti.Text.Length != 0)
			{
                lbPredmeti.Items.Add(new ListItem(predmet.Text, "[profesor]"));
                lbKrediti.Items.Add(new ListItem(krediti.Text, "[krediti]"));
            }
        }

        protected void izbrisiKopce_Click(object sender, EventArgs e)
        {
			lbPredmeti.Items.Remove(lbPredmeti.SelectedItem);
			lbKrediti.Items.Remove(lbKrediti.SelectedItem);
            lbProfesor.Text = "Проф. д-р. ";
        }

        protected void lbPredmeti_SelectedIndexChanged(object sender, EventArgs e)
        {
			//AutoPostBack da e staveno na true kaj listata so predmeti

			lbKrediti.SelectedIndex = lbPredmeti.SelectedIndex;
			lbProfesor.Text = "Проф. д-р. ";
			lbProfesor.Text += lbPredmeti.SelectedItem.Value;

        }

        protected void lbKrediti_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AutoPostBack da e staveno na true kaj listata so krediti

            lbPredmeti.SelectedIndex = lbKrediti.SelectedIndex;
            lbProfesor.Text = "Проф. д-р. ";
            lbProfesor.Text += lbPredmeti.SelectedItem.Value;
        }

        protected void glasajKopce_Click(object sender, EventArgs e)
        {
			Response.Redirect("UspeshnoGlasanje.aspx");
        }
    }
}
