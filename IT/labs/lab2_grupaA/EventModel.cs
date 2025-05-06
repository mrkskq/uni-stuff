using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2A.Models
{
	public class EventModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задолжително")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Локацијата е задолжителна")]
        public string Lokacija { get; set; }
    }
}
