using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace laniKolokviumska
{
	public partial class Najava : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void kopceNajava_Click(object sender, EventArgs e)
        {
			Session["ime"] = ime.Text;
			Session["mail"] = mail.Text;
			Response.Redirect("Glasaj.aspx");
        }
    }
}
