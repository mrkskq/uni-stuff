using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aud5
{
	public partial class Katalog : System.Web.UI.Page
	{

        string[] iminja = {"Техничка литература" ,
                "Научна фантастика","Автомобили"};

        protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proizvodi.aspx?id=1&ime=" + iminja[0]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proizvodi.aspx?id=2&ime=" + iminja[1]);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proizvodi.aspx?id=3&ime=" + iminja[2]);
        }
    }
}
