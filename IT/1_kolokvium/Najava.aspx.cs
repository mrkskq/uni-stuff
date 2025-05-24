using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aud5
{
	public partial class Najava : System.Web.UI.Page
	{
        string [] iminja = {"Математика", "Физика", "Информатика"};
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void kopceMat_Click(object sender, EventArgs e)
        {
            Session["ime"] = ime.Text;
            Session["mail"] = mail.Text;
            Response.Redirect("Predmeti.aspx?id=1&predmet=" + iminja[0]);
        }

        protected void kopceFiz_Click(object sender, EventArgs e)
        {
            Session["ime"] = ime.Text;
            Session["mail"] = mail.Text;
            Response.Redirect("Predmeti.aspx?id=2&predmet=" + iminja[1]);
        }

        protected void kopceInf_Click(object sender, EventArgs e)
        {
            Session["ime"] = ime.Text;
            Session["mail"] = mail.Text;
            Response.Redirect("Predmeti.aspx?id=3&predmet=" + iminja[2]);
        }
    }
}
