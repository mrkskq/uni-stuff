using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3A.Models
{
	public class Patient
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задолжително")]
        public string Name { get; set; }

        [Display(Name = "Код на пациентот")]
        [Range(10000, 99999, ErrorMessage = "Кодот мора да има точно 5 цифри")]
        public int PatientCode { get; set; }

        public string Gender { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
