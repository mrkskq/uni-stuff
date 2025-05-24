using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1B
{
	public partial class Najava : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void najavaKopce_Click(object sender, EventArgs e)
        {
			Response.Redirect("Glasaj.aspx");
        }
    }
}
