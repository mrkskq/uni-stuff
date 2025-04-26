using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.ViewModels
{
	public class ArtistAlbumsViewModel
	{
        public Artist Artist { get; set; }
        public List<Album> Albums { get; set; }
        public string ChosenAlbum { get; set; }
    }
}
