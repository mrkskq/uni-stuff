using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aud5
{
	public partial class Predmeti : System.Web.UI.Page
	{

		string[] matematika = {"Дискретна математика", "Бизнис статистика", "Веројатност", "Калкулус"};
		string[] fizika = {"Физика 1", "Физика 2"};
		string[] informatika = {"Структурно програмирање", "Оперативни системи", "Алгоритми и податочни структури"};

        static int counter = 0;
        static int suma = 0;

		
		protected void Page_Load(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(Request.QueryString["id"]);
			string predmet = Request.QueryString["predmet"];

			if (!IsPostBack)
			{
                if (id == 1)
                {
                    listaPredmeti.DataSource = matematika;
                    listaPredmeti.DataBind();

                    for (int i = 0; i < matematika.Length; i++)
                    {
                        listaOcenki.Items.Add("Внеси " + (i + 1));
                    }
                }
                else if (id == 2)
                {
                    listaPredmeti.DataSource = fizika;
                    listaPredmeti.DataBind();

                    for (int i = 0; i < fizika.Length; i++)
                    {
                        listaOcenki.Items.Add("Внеси " + (i + 1));
                    }
                }
                else if (id == 3)
                {
                    listaPredmeti.DataSource = informatika;
                    listaPredmeti.DataBind();

                    for (int i = 0; i < informatika.Length; i++)
                    {
                        listaOcenki.Items.Add("Внеси " + (i + 1));
                    }
                }
                else
                {
                    return;
                }

               
            }

			
		}

        protected void kopceOcenka_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ocenka.Text))
            {
                listaOcenki.SelectedItem.Text = ocenka.Text;
                counter++;
                suma += Convert.ToInt32(ocenka.Text);
                ocenka.Text = "";
            }
        }

        protected void kopceProsek_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            if(id==1 && counter == matematika.Length)
            {
                Session["counter"] = counter;
                Session["suma"] = suma;
                Response.Redirect("Prosek.aspx");
            }
            else if(id==2 && counter == fizika.Length)
            {
                Session["counter"] = counter;
                Session["suma"] = suma;
                Response.Redirect("Prosek.aspx");
            }
            else if(id==3 && counter == informatika.Length)
            {
                Session["counter"] = counter;
                Session["suma"] = suma;
                Response.Redirect("Prosek.aspx");
            }
            else
            {
                return;
            }
			

        }

        protected void listaPredmeti_SelectedIndexChanged(object sender, EventArgs e)
        {
			listaOcenki.SelectedIndex = listaPredmeti.SelectedIndex;
        }

        protected void listaOcenki_SelectedIndexChanged(object sender, EventArgs e)
        {
			listaPredmeti.SelectedIndex = listaOcenki.SelectedIndex;
        }

        
    }
}
