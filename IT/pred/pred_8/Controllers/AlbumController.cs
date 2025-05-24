using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult ListArtistAlbums()
        {
            var artist = new Artist() { Name = "Prodigy" };

            var albums = new List<Album>();
            albums.Add(new Album { Title = "Experience" });
            albums.Add(new Album { Title = "Music of the Jilted Generation" });
            albums.Add(new Album { Title = "The Fat of the Land" });
            albums.Add(new Album { Title = "Always Outnumbered, Never Outgunned" });
            albums.Add(new Album { Title = "Invaders Must Die" });
            albums.Add(new Album { Title = "The Day Is My Enemy" });

            var viewModel = new ArtistAlbumsViewModel
            {
                Artist = artist,
                Albums = albums
            };

            return View(viewModel);
        }
    }
}
