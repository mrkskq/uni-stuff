using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3A.Models
{
	public class Hospital
	{
        public int Id { get; set; }

        [Display(Name = "Hospital's Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; } // URL до слика

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
