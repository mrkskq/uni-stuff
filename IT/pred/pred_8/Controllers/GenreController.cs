using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Create()
        {
            return View();
        }
    }
}
