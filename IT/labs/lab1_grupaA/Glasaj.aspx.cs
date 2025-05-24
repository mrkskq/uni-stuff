using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1A
{
	public partial class Glasaj : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void glasajKopce_Click(object sender, EventArgs e)
        {
            Response.Redirect("UspeshnoGlasanje.aspx");
        }

	
 	//listite da se megjusebno linkuvani 
 	//t.e. aku stegnam na prviot item od prvata lista, avtomatski da se selektirat prviot item od vtorata lista, i obratno
 
        protected void lbPredmeti_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AutoPostBack da e staveno na true kaj listata so predmeti
            lbKrediti.SelectedIndex = lbPredmeti.SelectedIndex;
	    lblProfesor.Text = "Проф. д-р ";
            lblProfesor.Text += lbPredmeti.SelectedItem.Value;
        }

        protected void lbKrediti_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AutoPostBack da e staveno na true kaj listata so krediti
            lbPredmeti.SelectedIndex = lbKrediti.SelectedIndex;
            lblProfesor.Text = "Проф. д-р ";
            lblProfesor.Text += lbPredmeti.SelectedItem.Value;
        }
    }
}
