using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aud5
{
	public partial class Prosek : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string ime = (string)Session["ime"];
			string mail = (string)Session["mail"];
			int counter = (int)Session["counter"];
			int suma = (int)Session["suma"];

			tekst.Text = ime + ", Ви благодариме за учеството. Вашиот просек е "+(float)suma/counter+". Детали ќе добиете на вашиот меил: " + mail;
		}
	}
}
