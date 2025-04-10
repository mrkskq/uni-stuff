using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace laniKolokviumska
{
	public partial class UspeshnoGlasanje : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string ime = (string)Session["ime"];
			string mail = (string)Session["mail"];
			string predmet = (string)Session["predmet"];

			tekst.Text = ime + ", Ви благодариме за учеството во анкетата на ФИНКИ. Вашиот избор беше " + predmet + ".Потврдата за пополнување на анкетата ќе ги добиете по електронска пошта, на " + mail;
		}
	}
}
