using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccinationApp.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"[0-9]{13}$", ErrorMessage = "ЕМБГ мора да биде точно 13 цифри")]
        public string Embg { get; set; }

        [Required(ErrorMessage = "Името е задолжително")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Презимето е задолжително")]
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Patient Phone")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //Еден пациент може да прима повеќе дози од вакцина
        public virtual List<Vaccine> Vaccines { get; set; }

    }
}
