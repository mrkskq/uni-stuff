using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1V
{
	public partial class UspeshnoGlasanje : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string ime = (string)Session["ime"];
			string mail = (string)Session["mail"];
			tekst.Text = ime + ", Ви благодариме за учеството во акцијата за избор на најинтересен предмет на ФИНКИ. Резултатите од гласањето ќе ги добиете по електронска пошта, на Е-MAIL: " + mail;
		}
	}
}
