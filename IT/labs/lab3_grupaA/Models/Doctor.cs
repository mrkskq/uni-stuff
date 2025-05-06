using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3A.Models
{
	public class Doctor
	{
        public int Id { get; set; }

        [Display(Name = "Doctor's Name")]
        public string Name { get; set; }

        public int HospitalId { get; set; }
        public virtual Hospital Hospital { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
